using ChallengeAlkemy.Users.Entities;
using ChallengeAlkemy.Users.UsersDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ChallengeAlkemy.Users.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("auth/register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            var userExists = await _userManager.FindByNameAsync(registerUserDTO.Name);
            if (userExists != null) throw new Exception("Ya existe un usuario con ese nombre!!");
            var newUser = new User()
            {
                UserName = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(newUser, registerUserDTO.Password);
            if (!result.Succeeded)
            {
                var errores = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new Exception($"Ocurrio un error al intentar crear el nuevo usuario!!.\n {errores}");
            }
            return Ok("Usuario creado correctamente!!");
        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Name, loginUserDTO.Password, false, false);
            if (!result.Succeeded) throw new Exception("Ocurrio un error al intentar logearse!");

            var user = await _userManager.FindByNameAsync(loginUserDTO.Name);
            if (!user.IsActive) throw new Exception("El usuario que intenta logearse no esta activo!");

            return Ok(await GetToken(user));
        }
        private async Task<LoginRequestViewModel> GetToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            userClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecretaSuperLargaDeAUTORIZACION"));
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44339",
                audience: "https://localhost:44339",
                expires: DateTime.Now.AddHours(1),
                claims: userClaims,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256));

            return new LoginRequestViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }
    }
}

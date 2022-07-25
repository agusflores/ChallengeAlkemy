using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Users.UsersDTO
{
    public class RegisterUserDTO
    {

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class LoginUserDTO
    {

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class LoginRequestViewModel
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace ChallengeAlkemy.Users.Entities
{
    public class User : IdentityUser 
    {
       public bool IsActive { get; set; }


    }
}

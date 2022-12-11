using Microsoft.AspNetCore.Identity;

namespace Avtomoll.UsersRoles
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }
    }
}

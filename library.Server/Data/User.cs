#nullable disable

using Microsoft.AspNetCore.Identity;

namespace library.Server.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int ApplicationUserRoleId { get; set; } = 1;
    }
}
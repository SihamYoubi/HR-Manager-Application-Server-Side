using Microsoft.AspNetCore.Identity;

namespace HRManager.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }
        public DateOnly EntryDate { get; set; }
    }
}

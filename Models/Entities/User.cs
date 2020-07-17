using Microsoft.AspNetCore.Identity;

namespace programmersGuide.Models.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

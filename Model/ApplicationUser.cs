using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string type { get; set; }
        public virtual ICollection<Medcine> Medcines { get; set; }
    }

}
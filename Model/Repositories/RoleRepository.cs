using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly AppDbContext appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Role GetRole(String roleId)
        {
            return appDbContext.Roles.FirstOrDefault(r => r.Id == roleId);
        }

        public IEnumerable<Role> GetRoles()
        {
            return appDbContext.Roles;
        }
    }
}

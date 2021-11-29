using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRole(string roleId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    interface ISpecialiteRepository
    {
        IEnumerable<Specialite> GetSpecialites();
        Specialite GetSpecialite(int specialiteId);

    }
}

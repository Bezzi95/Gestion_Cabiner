using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface ISpecialiteRepository
    {
        Task<IEnumerable<Specialite>> GetSpecialites();
        Task<Specialite> GetSpecialite(int specialiteId);

    }
}

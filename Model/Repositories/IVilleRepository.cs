using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IVilleRepository
    {
        Task <IEnumerable<Ville>> GetVilles();
        Task <Ville> GetVille(int villeId);
    }
}

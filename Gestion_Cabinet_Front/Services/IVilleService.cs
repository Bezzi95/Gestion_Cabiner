using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public interface IVilleService
    {
        Task<IEnumerable<Ville>> GetVilles();
        Task<Ville> GetVille(int villeId);
    }
}

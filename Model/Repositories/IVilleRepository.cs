using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IVilleRepository
    {
        IEnumerable<Ville> GetVilles();
        Ville GetVille(int villeId);
    }
}

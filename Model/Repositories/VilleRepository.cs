using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class VilleRepository : IVilleRepository
    {
        private readonly AppDbContext appDbContext;

        public VilleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Ville GetVille(int villeId)
        {
            return appDbContext.Villes.FirstOrDefault(v => v.id == villeId);
        }

        public IEnumerable<Ville> GetVilles()
        {
            return appDbContext.Villes;
        }
    }
}

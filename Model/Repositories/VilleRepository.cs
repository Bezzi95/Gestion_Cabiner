using Microsoft.EntityFrameworkCore;
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

        async Task<Ville> IVilleRepository.GetVille(int villeId)
        {
            return await appDbContext.Villes.FirstOrDefaultAsync(v => v.id == villeId);
        }

        public async Task<IEnumerable<Ville>>GetVilles()
        {
            return await appDbContext.Villes.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class SpecialiteRepository : ISpecialiteRepository
    {
        private readonly AppDbContext appDbContext;

        public SpecialiteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        async Task<Specialite> ISpecialiteRepository.GetSpecialite(int specialiteId)
        {
          return await appDbContext.Specialites.FirstOrDefaultAsync(s => s.id == specialiteId);
        }

        public async Task<IEnumerable<Specialite>> GetSpecialites()
        {
            return await appDbContext.Specialites.ToListAsync();
        }
    }
}

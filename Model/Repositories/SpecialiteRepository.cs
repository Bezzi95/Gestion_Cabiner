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

        public Specialite GetSpecialite(int specialiteId)
        {
            return appDbContext.Specialites.FirstOrDefault(s => s.id == specialiteId);
        }

        public IEnumerable<Specialite> GetSpecialites()
        {
            return appDbContext.Specialites;
        }
    }
}

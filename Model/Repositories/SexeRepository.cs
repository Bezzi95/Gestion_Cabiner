using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class SexeRepository :ISexeRepository
    {
        private readonly AppDbContext appDbContext;

        public SexeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Sexe GetSexe(int sexeId)
        {
            return appDbContext.Sexes.FirstOrDefault(s => s.id == sexeId);
        }

        public IEnumerable<Sexe> GetSexes()
        {
            return appDbContext.Sexes;
        }
    }
}

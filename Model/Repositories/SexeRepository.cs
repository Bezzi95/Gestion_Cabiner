using Microsoft.EntityFrameworkCore;
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

        async Task<Sexe> ISexeRepository.GetSexe(int sexeId)
        {
            return  await appDbContext.Sexes.FirstOrDefaultAsync(s => s.id == sexeId);
        }

       public async Task<IEnumerable<Sexe>> GetSexes()
        {
            return await appDbContext.Sexes.ToListAsync() ;
        }
    }
}

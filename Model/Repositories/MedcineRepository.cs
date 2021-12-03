using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class MedcineRepository : IMedcineRepository
    {
        private readonly AppDbContext appDbContext;

        public MedcineRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Medcine> AddMedcine(Medcine medcine)
        {
            var result = await appDbContext.Medcines.AddAsync(medcine);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Medcine> DeleteMedcine(int medcineId)
        {

            var result = await appDbContext.Medcines.SingleOrDefaultAsync(m => m.id == medcineId);

            if (result != null)
            {
                appDbContext.Medcines.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Medcine> GetMedcine(int medcineId)
        {
            return await appDbContext.Medcines.
                Include(m => m.Sexe).
                Include(m => m.Specialite).
                Include(m => m.Ville).
                FirstOrDefaultAsync(m => m.id == medcineId);
        }






        public async Task<Medcine> GetMedcineByEmail(string email)

        {
            return await appDbContext.Medcines.FirstOrDefaultAsync(m => m.Email == email);
        }

        public async Task<IEnumerable<Medcine>> GetMedcines()
        {
            return await appDbContext.Medcines.ToListAsync();
        }

        public async Task<Medcine> UpdateMedcine(Medcine medcine)
        {

            var result = await appDbContext.Medcines.FirstOrDefaultAsync(m => m.id == medcine.id);

            if (result != null)
            {
                result.nom = medcine.nom;
                result.prenom = medcine.prenom;
                result.Email = medcine.Email;
                result.Adresse = medcine.Adresse;
                result.Telephone = medcine.Telephone;
                result.photo = medcine.photo;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;

        }
    }
}

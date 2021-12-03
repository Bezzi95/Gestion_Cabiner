using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class Rendez_VousRepository : IRendez_VousRepository
    {
        private readonly AppDbContext appDbContext;

        public Rendez_VousRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Rendez_vous> AddRendez_vous(Rendez_vous rendez_vous)
        {
            var result = await appDbContext.Rendez_Vous.AddAsync(rendez_vous);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Rendez_vous> DeleteRendez_vous(int rendez_vousId)
        {
            var result = await appDbContext.Rendez_Vous.SingleOrDefaultAsync(m => m.Id == rendez_vousId);

            if (result != null)
            {
                appDbContext.Rendez_Vous.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Rendez_vous> GetRendez_vous(int rendez_vousId)
        {
            return await appDbContext.Rendez_Vous.
                // Include(c => c.Medcine).
                // Include(c => c.Patient).
                 FirstOrDefaultAsync(c => c.Id == rendez_vousId);
        }

        public async Task<IEnumerable<Rendez_vous>> GetRendez_vousByDate(DateTime Date1, DateTime Date2)
        {
            return await appDbContext.Rendez_Vous.
              //  Include(c => c.Medcine).
               // Include(c => c.Patient).
                Where(c => c.Date_rendez_vous >= Date1 && c.Date_rendez_vous <= Date2).
                ToListAsync();
        }

        public async Task<IEnumerable<Rendez_vous>> GetRendez_vousByMedecin(int medecinId)
        {
            return await appDbContext.Rendez_Vous.
             //  Include(c => c.Medcine).
              // Include(c => c.Patient).
               Where(c => c.Medcineid == medecinId).
               ToListAsync();
        }

        public async Task<IEnumerable<Rendez_vous>> GetRendez_vousByPatient(int patientId)
        {
            return await appDbContext.Rendez_Vous.
             // Include(c => c.Medcine).
             // Include(c => c.Patient).
              Where(c => c.Patientid == patientId).
              ToListAsync();
        }

        public async Task<IEnumerable<Rendez_vous>> GetRendez_vouss()
        {
            return await appDbContext.Rendez_Vous.
             //   Include(c => c.Medcine).
              //  Include(c => c.Patient).
                ToListAsync();
        }

        public async Task<IEnumerable<Rendez_vous>> Search(string patientname, string medecinname, string status)
        {
            IQueryable<Rendez_vous> query = appDbContext.Rendez_Vous;

            if (!string.IsNullOrEmpty(patientname))
            {
                query = query.Where(e => e.Patient.nom.Contains(patientname) || e.Patient.prenom.Contains(patientname));
            }
            if (!string.IsNullOrEmpty(medecinname))
            {
                query = query.Where(e => e.Medcine.nom.Contains(medecinname) || e.Medcine.prenom.Contains(medecinname));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(e => e.Status.Equals(status) );
            }

            return await query.ToListAsync();
        }

        public async Task<Rendez_vous> UpdateRendez_vous(Rendez_vous Rendez_vous)
        {
            var result = await appDbContext.Rendez_Vous.FirstOrDefaultAsync(c => c.Id == Rendez_vous.Id);

            if (result != null)
            {
                result.Date_rendez_vous = Rendez_vous.Date_rendez_vous;
                result.Status = Rendez_vous.Status;
                result.Patient = Rendez_vous.Patient;
                result.Patientid = Rendez_vous.Patientid;
                result.Medcine = Rendez_vous.Medcine;
                result.Medcineid = Rendez_vous.Medcineid;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}

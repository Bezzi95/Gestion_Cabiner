using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly AppDbContext appDbContext;

        public ConsultationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Consultation> AddConsultation(Consultation consultation)
        {
            var result = await appDbContext.Consultations.AddAsync(consultation);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Consultation> DeleteConsultation(int consultationId)
        {
             var result = await appDbContext.Consultations.SingleOrDefaultAsync(m => m.id == consultationId);

            if (result != null)
            {
                appDbContext.Consultations.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Consultation> GetConsultation(int consultationId)
        {

            return await appDbContext.Consultations.
               // Include(c => c.Medecin).
               // Include(c => c.Patient).
                FirstOrDefaultAsync(c => c.id == consultationId);
        }

        public async Task<IEnumerable<Consultation>> GetConsultations()
        {
            return await appDbContext.Consultations.
             //  Include(c => c.Medecin).
             //  Include(c => c.Patient).
               ToListAsync();
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsByDate(DateTime Date1, DateTime Date2)
        {
            return await appDbContext.Consultations.
              //  Include(c => c.Medecin).
               // Include(c => c.Patient).
                Where(c => c.Date_Consult<= Date1 && c.Date_Consult >= Date2).
                ToListAsync();
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsByMedecin(int medecinId)
        {
            return await appDbContext.Consultations.
              //Include(c => c.Medecin).
             // Include(c => c.Patient).
              Where(c => c.Medecinid == medecinId).
              ToListAsync();

        }

        public async Task<IEnumerable<Consultation>> GetConsultationsByPatient(int patientId)
        {
            return await appDbContext.Consultations.
               // Include(c => c.Medecin).
              //  Include(c => c.Patient).
                Where(c => c.Patientid == patientId).
                ToListAsync();
        }

        public async Task<Consultation> UpdateConsultation(Consultation consultation)
        {
            var result = await appDbContext.Consultations.FirstOrDefaultAsync(c => c.id == consultation.id);

            if (result != null)
            {
                result.Date_Consult = consultation.Date_Consult;
                result.resultat = consultation.resultat;
                result.Patient = consultation.Patient;
                result.Patientid = consultation.Patientid;
                result.Medecin = consultation.Medecin;
                result.Medecinid = consultation.Medecinid;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Consultation>> Search(string patientname, string medecinname)
        {
            IQueryable<Consultation> query = appDbContext.Consultations;

            if (!string.IsNullOrEmpty(patientname))
            {
                query = query.Where(e => e.Patient.nom.Contains(patientname) || e.Patient.prenom.Contains(patientname));
            }
            if (!string.IsNullOrEmpty(medecinname))
            {
                query = query.Where(e => e.Medecin.nom.Contains(medecinname) || e.Medecin.prenom.Contains(medecinname));
            }

            return await query.ToListAsync();

        }


        }
    }

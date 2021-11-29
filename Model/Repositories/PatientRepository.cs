using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext appDbContext;

        public PatientRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var result = await appDbContext.Patients.AddAsync(patient);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Patient> DeletePatient(int patientId)
        {
            var result = await appDbContext.Patients.SingleOrDefaultAsync(p => p.id == patientId);
            if (result != null)
            {
                appDbContext.Patients.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Patient> GetPatient(int patientId)
        {
            return await appDbContext.Patients.FirstOrDefaultAsync(p => p.id == patientId);
        }

        public async Task<Patient> GetPatientByEmail(string email)
        {
            return await appDbContext.Patients.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await appDbContext.Patients.ToListAsync();
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var result = await appDbContext.Patients.SingleOrDefaultAsync(p => p.id == patient.id);

            if (result != null)
            {
                result.nom = patient.nom;
                result.prenom = patient.prenom;
                result.Email = patient.Email;
                result.Adresse = patient.Adresse;
                result.Telephone = patient.Telephone;
                result.photo = patient.photo;
                result.Date_naiss = patient.Date_naiss;
                await appDbContext.SaveChangesAsync();
                return result;

            }
            return null;

        }
    }
}

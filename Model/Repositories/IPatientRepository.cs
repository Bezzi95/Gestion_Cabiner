using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> GetPatient(int patientId);

        Task<Patient> AddPatient(Patient patient);

        Task<Patient> UpdatePatient(Patient patient);

        Task<Patient> DeletePatient(int patientId);

        Task<Patient> GetPatientByEmail(String email);

    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<HttpResponseMessage> UpdatePatient(Patient updatedPatient);
        Task<HttpResponseMessage> CreatePatient(Patient NewPatient);
        Task DeletePatient(int id);

    }

}


using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient httpClient;

        public PatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await httpClient.GetFromJsonAsync<Patient>($"api/Patients/{id}");
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
          return await httpClient.GetFromJsonAsync<Patient[]>("api/Patients");
        }
    }
}

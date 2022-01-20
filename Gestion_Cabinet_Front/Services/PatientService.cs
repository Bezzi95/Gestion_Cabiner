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

        public async Task<HttpResponseMessage> CreatePatient(Patient NewPatient)
        {
            return await httpClient.PostAsJsonAsync<Patient>("api/Patients", NewPatient);
        }

        public async Task DeletePatient(int id)
        {
            await httpClient.DeleteAsync($"api/Patients/{id}");
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await httpClient.GetFromJsonAsync<Patient>($"api/Patients/{id}");
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
          return await httpClient.GetFromJsonAsync<Patient[]>("api/Patients");
        }

        public async Task<HttpResponseMessage> UpdatePatient(Patient updatedPatient)
        {
            return await httpClient.PutAsJsonAsync<Patient>($"api/Patients/{updatedPatient.id}", updatedPatient);
        }
    }
}

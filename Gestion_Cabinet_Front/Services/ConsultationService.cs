using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class ConsultationService :IConsultationService
    {
        private readonly HttpClient httpClient;
        public ConsultationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> CreateConsultation(Consultation NewConsultation)
        {
            return await httpClient.PostAsJsonAsync<Consultation>("api/consultations", NewConsultation);

        }

        public async Task<HttpResponseMessage> DeleteConsultation(int id)
        {
             return await httpClient.DeleteAsync("api/consultations/{id}");
        }

        public async Task<Consultation> GetConsultation(int id)
        {
            return await httpClient.GetFromJsonAsync<Consultation>($"api/consultations/{id}");
        }

        public async Task<IEnumerable<Consultation>> GetConsultations()
        {
            return await httpClient.GetFromJsonAsync<Consultation[]>("api/consultations");
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsByPatient(int id)
        {
            return await httpClient.GetFromJsonAsync<Consultation[]>($"/api/consultations/getbyPatient/{id}");
        }

        public async Task<HttpResponseMessage> UpdateConsultation(Consultation updatedConsultation)
        {
            return await httpClient.PutAsJsonAsync<Consultation>("api/consultations/{updatedConsultation.id}", updatedConsultation);
        }
    }
}

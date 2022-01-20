using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class MedecinService : IMedecinService
    {
        private readonly HttpClient httpClient;

        public MedecinService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateMedecin(Medcine NewMedecin)
        {
            return await httpClient.PostAsJsonAsync<Medcine>("api/Medcines", NewMedecin);
        }

        public async Task DeleteMedecin(int id)
        {
            await httpClient.DeleteAsync($"api/Medcines/{id}");
        }

        public async Task<Medcine> GetMedecin(int id)
        {
            return await httpClient.GetFromJsonAsync<Medcine>($"api/Medcines/{id}");
        }

        public async Task<IEnumerable<Medcine>> GetMedecins()
        {
            return await httpClient.GetFromJsonAsync<Medcine[]>("api/Medcines");
        }

        public async  Task<HttpResponseMessage> UpdateMedecin(Medcine updatedMedcine)
        {
           
            return await httpClient.PutAsJsonAsync<Medcine>($"api/Medcines/{updatedMedcine.id}", updatedMedcine);
            
        }
    }
}

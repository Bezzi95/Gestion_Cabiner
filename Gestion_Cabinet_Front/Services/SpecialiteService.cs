using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class SpecialiteService : ISpecialiteService
    {
        private readonly HttpClient httpClient;

        public SpecialiteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Specialite> GetSpecialite(int id)
        {
            return await httpClient.GetFromJsonAsync<Specialite>($"api/Specialites/{id}");
        }

        public async Task<IEnumerable<Specialite>> GetSpecialites()
        {
            return await httpClient.GetFromJsonAsync<Specialite[]>("api/Specialites");
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class VilleService : IVilleService
    {
        private readonly HttpClient httpClient;

        public VilleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Ville> GetVille(int villeId)
        {
            return await httpClient.GetFromJsonAsync<Ville>($"api/villes/{villeId}");
        }

        public async Task<IEnumerable<Ville>> GetVilles()
        {
            return await httpClient.GetFromJsonAsync<Ville[]>("api/villes");
        }
    }
}

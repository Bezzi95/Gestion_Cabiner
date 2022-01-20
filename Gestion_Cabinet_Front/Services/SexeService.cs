using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public class SexeService : ISexeService
    {
        private readonly HttpClient httpClient;

        public SexeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Sexe> GetSexe(int sexeId)
        {
          return await httpClient.GetFromJsonAsync<Sexe>($"api/sexes/{sexeId}");
        }

        public async Task<IEnumerable<Sexe>> GetSexes()
        {
            return await httpClient.GetFromJsonAsync<Sexe[]>("api/sexes");
        }
    }
}

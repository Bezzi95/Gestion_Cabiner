using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public interface IMedecinService
    {
        Task<IEnumerable<Medcine>> GetMedecins();
        Task<Medcine> GetMedecin(int id);
        Task<HttpResponseMessage> CreateMedecin(Medcine NewMedecin);
        Task<HttpResponseMessage> UpdateMedecin(Medcine updatedMedcine);
        Task DeleteMedecin(int id);

    }
}

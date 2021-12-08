using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public interface IConsultationService
    {
        Task<IEnumerable<Consultation>> GetConsultations();
        Task<Consultation> GetConsultation(int id);
        Task<HttpResponseMessage> UpdateConsultation(Consultation updatedConsultation);
        Task<HttpResponseMessage> CreateConsultation(Consultation NewConsultation);
        Task DeleteConsultation(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IConsultationRepository
    {
        Task<IEnumerable<Consultation>> GetConsultations();

        Task<Consultation> GetConsultation(int consultationId);

        Task<Consultation> AddConsultation(Consultation consultation);

        Task<Consultation> UpdateConsultation(Consultation consultation);

        Task<Consultation> DeleteConsultation(int consultationId);

        Task<IEnumerable<Consultation>> GetConsultationsByPatient(int patientId);
        Task<IEnumerable<Consultation>> GetConsultationsByMedecin(int medecinId);

        Task<IEnumerable<Consultation>> GetConsultationsByDate(DateTime Date1,DateTime Date2);

        Task<IEnumerable<Consultation>> Search(string patientname, string medecinname);





    }
}

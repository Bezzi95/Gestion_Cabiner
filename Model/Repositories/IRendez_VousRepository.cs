using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IRendez_VousRepository
    {
        Task<IEnumerable<Rendez_vous>> GetRendez_vouss();

        Task<Rendez_vous> GetRendez_vous(int rendez_vousId);

        Task<Rendez_vous> AddRendez_vous(Rendez_vous Rendez_vous);

        Task<Rendez_vous> UpdateRendez_vous(Rendez_vous Rendez_vous);

        Task<Rendez_vous> DeleteRendez_vous(int rendez_vousId);

        Task<IEnumerable<Rendez_vous>> GetRendez_vousByPatient(int patientId);
        Task<IEnumerable<Rendez_vous>> GetRendez_vousByMedecin(int medecinId);

        Task<IEnumerable<Rendez_vous>> GetRendez_vousByDate(DateTime Date1, DateTime Date2);

        Task<IEnumerable<Rendez_vous>> Search(string patientname, string medecinname, string status);

        


    }
}

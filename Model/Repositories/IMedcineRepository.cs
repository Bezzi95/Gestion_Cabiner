using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface IMedcineRepository
    {
        Task<IEnumerable<Medcine>> GetMedcines();

        Task<Medcine> GetMedcine(int medcineId);

        Task<Medcine> AddMedcine(Medcine medcine);

        Task<Medcine> UpdateMedcine(Medcine medcine);

        Task<Medcine> DeleteMedcine(int medcineId);

        Task<Medcine> GetMedcineByEmail(String email);


    }
}

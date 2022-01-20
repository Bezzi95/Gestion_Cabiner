using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface ISexeRepository
    {
        Task<IEnumerable<Sexe>> GetSexes();
        Task <Sexe> GetSexe(int sexeId);
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public interface ISexeService
    {
        Task<IEnumerable<Sexe>> GetSexes();
        Task<Sexe> GetSexe(int sexeId);
    }
}

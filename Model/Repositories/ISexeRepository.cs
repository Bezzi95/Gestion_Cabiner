using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model.Repositories
{
    public interface ISexeRepository
    {
        IEnumerable<Sexe> GetSexes();
        Sexe GetSexe(int sexeId);
    }
}

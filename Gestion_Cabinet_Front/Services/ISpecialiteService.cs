using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Services
{
    public  interface ISpecialiteService
    {
        Task<IEnumerable<Specialite>> GetSpecialites();
        Task<Specialite> GetSpecialite(int id);
    }
}

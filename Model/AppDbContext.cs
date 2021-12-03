using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Medcine> Medcines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Sexe> Sexes { get; set; }
        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Rendez_vous> Rendez_Vous { get; set; }
        public DbSet<Consultation> Consultations { get; set; }



    }
}

using Microsoft.AspNetCore.Identity;
using GemeloVirtual.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GemeloVirtual.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admision_Hospital> Admisiones_Hospital { get; set; }
        public DbSet<Antecedentes_No_Patologicos> Antecedentes_No_Patologicos { get; set; }
        public DbSet<Antecedentes_Patologicos> Antecedentes_Patologicos { get; set;}
        public DbSet<Medicamentos_Dosis> Medicamentos_Dosis { get; set;}
        public DbSet<Reportes_Medicos> Reportes_Medicos{ get; set;}
        public DbSet<Sintomas> Sintomas{ get; set;}
        public DbSet<Unidad_Medida> unidad_Medidas { get; set;}
        public DbSet<Doctor> Doctors { get; set;}
        public DbSet<Hospital> Hospitals { get; set;}

    public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    public DbSet<GemeloVirtual.Web.Data.Entities.Doctor> Doctor { get; set; }

    public DbSet<GemeloVirtual.Web.Data.Entities.Paciente> Paciente { get; set; }
    }
}

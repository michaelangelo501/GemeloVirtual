using Microsoft.AspNetCore.Identity;
using GemeloVirtual.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GemeloVirtual.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Patient> Patients { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}

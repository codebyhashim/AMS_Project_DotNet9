
using AM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appoinments { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
    }
}


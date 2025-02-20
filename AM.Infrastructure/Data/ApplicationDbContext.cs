
using AM.ApplicationCore.Models;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SlotsModel>().HasData(

         new SlotsModel { Id = 1, StartTime = new TimeOnly(9, 0 ), EndTime = new TimeOnly(9, 15) },
        new SlotsModel { Id = 2, StartTime = new TimeOnly(9, 20 ), EndTime = new TimeOnly(9, 35) },
        new SlotsModel { Id = 3, StartTime = new TimeOnly(9, 40 ), EndTime = new TimeOnly(9, 55) },
        new SlotsModel { Id = 4, StartTime = new TimeOnly(10, 0 ), EndTime = new TimeOnly(10, 15) },
        new SlotsModel { Id = 5, StartTime = new TimeOnly(10, 20), EndTime = new TimeOnly(10, 35) },
        new SlotsModel { Id = 6, StartTime = new TimeOnly(10, 40), EndTime = new TimeOnly(10, 55) },
        new SlotsModel { Id = 7, StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(11, 15) },
        new SlotsModel { Id = 8, StartTime = new TimeOnly(11, 20), EndTime = new TimeOnly(11, 35) },
        new SlotsModel { Id = 9, StartTime = new TimeOnly(11, 40), EndTime = new TimeOnly(11, 55) },
        new SlotsModel { Id = 10, StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(12, 15) },
        new SlotsModel { Id = 11, StartTime = new TimeOnly(12, 20), EndTime = new TimeOnly(12, 35) },
        new SlotsModel { Id = 12, StartTime = new TimeOnly(12, 40), EndTime = new TimeOnly(12, 55) }
    


                );
        }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appoinments { get; set; }
        public DbSet<PatientModel> Patients { get; set; }

        public DbSet<SlotsModel> Slots { get; set; }

    }
}


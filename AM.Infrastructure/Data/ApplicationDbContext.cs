
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
            builder.Entity<TimeSlotsModel>().HasData(

         new TimeSlotsModel { Id = 1, StartTime = new TimeOnly(9,0 ), EndTime = new TimeOnly(9,30) },
        new TimeSlotsModel { Id = 2, StartTime = new TimeOnly(10,0 ), EndTime = new TimeOnly(10,30) },
        new TimeSlotsModel { Id = 3, StartTime = new TimeOnly(11,0 ), EndTime = new TimeOnly(11,30) },
        new TimeSlotsModel { Id = 4, StartTime = new TimeOnly(12,0 ), EndTime = new TimeOnly(12,30) },
        new TimeSlotsModel { Id = 5, StartTime = new TimeOnly(13,0), EndTime = new TimeOnly(13,30) },
        new TimeSlotsModel { Id = 6, StartTime = new TimeOnly(14,0), EndTime = new TimeOnly(14,30) },
        new TimeSlotsModel { Id = 7, StartTime = new TimeOnly(15,0), EndTime = new TimeOnly(15,30) },
        new TimeSlotsModel { Id = 8, StartTime = new TimeOnly(16,0), EndTime = new TimeOnly(16,30) }
        //new TimeSlotsModel { Id = 9, StartTime = new TimeOnly(17,0), EndTime = new TimeOnly(17,30) },
        //new TimeSlotsModel { Id = 10, StartTime = new TimeOnly(1,0), EndTime = new TimeOnly(12,15) },
        //new TimeSlotsModel { Id = 11, StartTime = new TimeOnly(12,20), EndTime = new TimeOnly(12,35) },
        //new TimeSlotsModel { Id = 12, StartTime = new TimeOnly(12,40), EndTime = new TimeOnly(12,55) },


        //new TimeSlotsModel { Id = 13, StartTime = new TimeOnly(14,0), EndTime = new TimeOnly(14,15) },
        //new TimeSlotsModel { Id = 14, StartTime = new TimeOnly(14,20), EndTime = new TimeOnly(14,35) },
        //new TimeSlotsModel { Id = 15, StartTime = new TimeOnly(14,40), EndTime = new TimeOnly(14,55) },
        //new TimeSlotsModel { Id = 16, StartTime = new TimeOnly(15,0), EndTime = new TimeOnly(15,15) },
        //new TimeSlotsModel { Id = 17, StartTime = new TimeOnly(15,20), EndTime = new TimeOnly(15,35) },
        //new TimeSlotsModel { Id = 18, StartTime = new TimeOnly(15,40), EndTime = new TimeOnly(15,55) },
        //new TimeSlotsModel { Id = 19, StartTime = new TimeOnly(16,0), EndTime = new TimeOnly(16,15) },
        //new TimeSlotsModel { Id = 20, StartTime = new TimeOnly(16,20), EndTime = new TimeOnly(16,35) },


        //new TimeSlotsModel { Id = 21, StartTime = new TimeOnly(16,40), EndTime = new TimeOnly(16,55) },
        //new TimeSlotsModel { Id = 22, StartTime = new TimeOnly(17,0), EndTime = new TimeOnly(17,15) },
        //new TimeSlotsModel { Id = 23, StartTime = new TimeOnly(17,20), EndTime = new TimeOnly(17,35) }







                );
        }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appoinments { get; set; }
        public DbSet<PatientModel> Patients { get; set; }

        public DbSet<TimeSlotsModel> Slots { get; set; }

    }
}



using System.Reflection.Emit;
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

            //    builder.Entity<TimeSlotsModel>()
            //.HasOne(ts => ts.Doctor)
            //.WithMany(d => d.TimeSlots)
            //.HasForeignKey(ts => ts.DoctorId)
            //.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TimeSlotsModel>().HasData(
    new TimeSlotsModel { Id = 1, StartTime = new TimeOnly(0, 0), EndTime = new TimeOnly(0, 15) },
    new TimeSlotsModel { Id = 2, StartTime = new TimeOnly(0, 15), EndTime = new TimeOnly(0, 30) },
    new TimeSlotsModel { Id = 3, StartTime = new TimeOnly(0, 30), EndTime = new TimeOnly(0, 45) },
    new TimeSlotsModel { Id = 4, StartTime = new TimeOnly(0, 45), EndTime = new TimeOnly(1, 0) },
    new TimeSlotsModel { Id = 5, StartTime = new TimeOnly(1, 0), EndTime = new TimeOnly(1, 15) },
    new TimeSlotsModel { Id = 6, StartTime = new TimeOnly(1, 15), EndTime = new TimeOnly(1, 30) },
    new TimeSlotsModel { Id = 7, StartTime = new TimeOnly(1, 30), EndTime = new TimeOnly(1, 45) },
    new TimeSlotsModel { Id = 8, StartTime = new TimeOnly(1, 45), EndTime = new TimeOnly(2, 0) },
    new TimeSlotsModel { Id = 9, StartTime = new TimeOnly(2, 0), EndTime = new TimeOnly(2, 15) },
    new TimeSlotsModel { Id = 10, StartTime = new TimeOnly(2, 15), EndTime = new TimeOnly(2, 30) },
    new TimeSlotsModel { Id = 11, StartTime = new TimeOnly(2, 30), EndTime = new TimeOnly(2, 45) },
    new TimeSlotsModel { Id = 12, StartTime = new TimeOnly(2, 45), EndTime = new TimeOnly(3, 0) },
    new TimeSlotsModel { Id = 13, StartTime = new TimeOnly(3, 0), EndTime = new TimeOnly(3, 15) },
    new TimeSlotsModel { Id = 14, StartTime = new TimeOnly(3, 15), EndTime = new TimeOnly(3, 30) },
    new TimeSlotsModel { Id = 15, StartTime = new TimeOnly(3, 30), EndTime = new TimeOnly(3, 45) },
    new TimeSlotsModel { Id = 16, StartTime = new TimeOnly(3, 45), EndTime = new TimeOnly(4, 0) },
    new TimeSlotsModel { Id = 17, StartTime = new TimeOnly(4, 0), EndTime = new TimeOnly(4, 15) },
    new TimeSlotsModel { Id = 18, StartTime = new TimeOnly(4, 15), EndTime = new TimeOnly(4, 30) },
    new TimeSlotsModel { Id = 19, StartTime = new TimeOnly(4, 30), EndTime = new TimeOnly(4, 45) },
    new TimeSlotsModel { Id = 20, StartTime = new TimeOnly(4, 45), EndTime = new TimeOnly(5, 0) },
    new TimeSlotsModel { Id = 21, StartTime = new TimeOnly(5, 0), EndTime = new TimeOnly(5, 15) },
    new TimeSlotsModel { Id = 22, StartTime = new TimeOnly(5, 15), EndTime = new TimeOnly(5, 30) },
    new TimeSlotsModel { Id = 23, StartTime = new TimeOnly(5, 30), EndTime = new TimeOnly(5, 45) },
    new TimeSlotsModel { Id = 24, StartTime = new TimeOnly(5, 45), EndTime = new TimeOnly(6, 0) },
    new TimeSlotsModel { Id = 25, StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(6, 15) },
    new TimeSlotsModel { Id = 26, StartTime = new TimeOnly(6, 15), EndTime = new TimeOnly(6, 30) },
    new TimeSlotsModel { Id = 27, StartTime = new TimeOnly(6, 30), EndTime = new TimeOnly(6, 45) },
    new TimeSlotsModel { Id = 28, StartTime = new TimeOnly(6, 45), EndTime = new TimeOnly(7, 0) },
    new TimeSlotsModel { Id = 29, StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(7, 15) },
    new TimeSlotsModel { Id = 30, StartTime = new TimeOnly(7, 15), EndTime = new TimeOnly(7, 30) },
    new TimeSlotsModel { Id = 31, StartTime = new TimeOnly(7, 30), EndTime = new TimeOnly(7, 45) },
    new TimeSlotsModel { Id = 32, StartTime = new TimeOnly(7, 45), EndTime = new TimeOnly(8, 0) },
    new TimeSlotsModel { Id = 33, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(8, 15) },
    new TimeSlotsModel { Id = 34, StartTime = new TimeOnly(8, 15), EndTime = new TimeOnly(8, 30) },
    new TimeSlotsModel { Id = 35, StartTime = new TimeOnly(8, 30), EndTime = new TimeOnly(8, 45) },
    new TimeSlotsModel { Id = 36, StartTime = new TimeOnly(8, 45), EndTime = new TimeOnly(9, 0) },
    new TimeSlotsModel { Id = 37, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(9, 15) },
    new TimeSlotsModel { Id = 38, StartTime = new TimeOnly(9, 15), EndTime = new TimeOnly(9, 30) },
    new TimeSlotsModel { Id = 39, StartTime = new TimeOnly(9, 30), EndTime = new TimeOnly(9, 45) },
    new TimeSlotsModel { Id = 40, StartTime = new TimeOnly(9, 45), EndTime = new TimeOnly(10, 0) },
    new TimeSlotsModel { Id = 41, StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(10, 15) },
    new TimeSlotsModel { Id = 42, StartTime = new TimeOnly(10, 15), EndTime = new TimeOnly(10, 30) },
    new TimeSlotsModel { Id = 43, StartTime = new TimeOnly(10, 30), EndTime = new TimeOnly(10, 45) },
    new TimeSlotsModel { Id = 44, StartTime = new TimeOnly(10, 45), EndTime = new TimeOnly(11, 0) },
    new TimeSlotsModel { Id = 45, StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(11, 15) },
    new TimeSlotsModel { Id = 46, StartTime = new TimeOnly(11, 15), EndTime = new TimeOnly(11, 30) },
    new TimeSlotsModel { Id = 47, StartTime = new TimeOnly(11, 30), EndTime = new TimeOnly(11, 45) },
    new TimeSlotsModel { Id = 48, StartTime = new TimeOnly(11, 45), EndTime = new TimeOnly(12, 0) },
    new TimeSlotsModel { Id = 49, StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(12, 15) },
    new TimeSlotsModel { Id = 50, StartTime = new TimeOnly(12, 15), EndTime = new TimeOnly(12, 30) },
    new TimeSlotsModel { Id = 51, StartTime = new TimeOnly(12, 30), EndTime = new TimeOnly(12, 45) },
    new TimeSlotsModel { Id = 52, StartTime = new TimeOnly(12, 45), EndTime = new TimeOnly(13, 0) },
    new TimeSlotsModel { Id = 53, StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(13, 15) },
    new TimeSlotsModel { Id = 54, StartTime = new TimeOnly(13, 15), EndTime = new TimeOnly(13, 30) },
    new TimeSlotsModel { Id = 55, StartTime = new TimeOnly(13, 30), EndTime = new TimeOnly(13, 45) },
    new TimeSlotsModel { Id = 56, StartTime = new TimeOnly(13, 45), EndTime = new TimeOnly(14, 0) },
    new TimeSlotsModel { Id = 57, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(14, 15) },
    new TimeSlotsModel { Id = 58, StartTime = new TimeOnly(14, 15), EndTime = new TimeOnly(14, 30) },
    new TimeSlotsModel { Id = 59, StartTime = new TimeOnly(14, 30), EndTime = new TimeOnly(14, 45) },
    new TimeSlotsModel { Id = 60, StartTime = new TimeOnly(14, 45), EndTime = new TimeOnly(15, 0) },
    new TimeSlotsModel { Id = 61, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(15, 15) },
    new TimeSlotsModel { Id = 62, StartTime = new TimeOnly(15, 15), EndTime = new TimeOnly(15, 30) },
    new TimeSlotsModel { Id = 63, StartTime = new TimeOnly(15, 30), EndTime = new TimeOnly(15, 45) },
    new TimeSlotsModel { Id = 64, StartTime = new TimeOnly(15, 45), EndTime = new TimeOnly(16, 0) },
    new TimeSlotsModel { Id = 65, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(16, 15) },
    new TimeSlotsModel { Id = 66, StartTime = new TimeOnly(16, 15), EndTime = new TimeOnly(16, 30) },
    new TimeSlotsModel { Id = 67, StartTime = new TimeOnly(16, 30), EndTime = new TimeOnly(16, 45) },
    new TimeSlotsModel { Id = 68, StartTime = new TimeOnly(16, 45), EndTime = new TimeOnly(17, 0) },
    new TimeSlotsModel { Id = 69, StartTime = new TimeOnly(17, 0), EndTime = new TimeOnly(17, 15) },
    new TimeSlotsModel { Id = 70, StartTime = new TimeOnly(17, 15), EndTime = new TimeOnly(17, 30) },
    new TimeSlotsModel { Id = 71, StartTime = new TimeOnly(17, 30), EndTime = new TimeOnly(17, 45) },
    new TimeSlotsModel { Id = 72, StartTime = new TimeOnly(17, 45), EndTime = new TimeOnly(18, 0) },
    new TimeSlotsModel { Id = 73, StartTime = new TimeOnly(18, 0), EndTime = new TimeOnly(18, 15) },
    new TimeSlotsModel { Id = 74, StartTime = new TimeOnly(18, 15), EndTime = new TimeOnly(18, 30) },
    new TimeSlotsModel { Id = 75, StartTime = new TimeOnly(18, 30), EndTime = new TimeOnly(18, 45) },
    new TimeSlotsModel { Id = 76, StartTime = new TimeOnly(18, 45), EndTime = new TimeOnly(19, 0) },
    new TimeSlotsModel { Id = 77, StartTime = new TimeOnly(19, 0), EndTime = new TimeOnly(19, 15) },
    new TimeSlotsModel { Id = 78, StartTime = new TimeOnly(19, 15), EndTime = new TimeOnly(19, 30) },
    new TimeSlotsModel { Id = 79, StartTime = new TimeOnly(19, 30), EndTime = new TimeOnly(19, 45) },
    new TimeSlotsModel { Id = 80, StartTime = new TimeOnly(19, 45), EndTime = new TimeOnly(20, 0) },
    new TimeSlotsModel { Id = 81, StartTime = new TimeOnly(20, 0), EndTime = new TimeOnly(20, 15) },
    new TimeSlotsModel { Id = 82, StartTime = new TimeOnly(20, 15), EndTime = new TimeOnly(20, 30) },
    new TimeSlotsModel { Id = 83, StartTime = new TimeOnly(20, 30), EndTime = new TimeOnly(20, 45) },
    new TimeSlotsModel { Id = 84, StartTime = new TimeOnly(20, 45), EndTime = new TimeOnly(21, 0) },
    new TimeSlotsModel { Id = 85, StartTime = new TimeOnly(21, 0), EndTime = new TimeOnly(21, 15) },
    new TimeSlotsModel { Id = 86, StartTime = new TimeOnly(21, 15), EndTime = new TimeOnly(21, 30) },
    new TimeSlotsModel { Id = 87, StartTime = new TimeOnly(21, 30), EndTime = new TimeOnly(21, 45) },
    new TimeSlotsModel { Id = 88, StartTime = new TimeOnly(21, 45), EndTime = new TimeOnly(22, 0) },
    new TimeSlotsModel { Id = 89, StartTime = new TimeOnly(22, 0), EndTime = new TimeOnly(22, 15) },
    new TimeSlotsModel { Id = 90, StartTime = new TimeOnly(22, 15), EndTime = new TimeOnly(22, 30) },
    new TimeSlotsModel { Id = 91, StartTime = new TimeOnly(22, 30), EndTime = new TimeOnly(22, 45) },
    new TimeSlotsModel { Id = 92, StartTime = new TimeOnly(22, 45), EndTime = new TimeOnly(23, 0) },
    new TimeSlotsModel { Id = 93, StartTime = new TimeOnly(23, 0), EndTime = new TimeOnly(23, 15) },
    new TimeSlotsModel { Id = 94, StartTime = new TimeOnly(23, 15), EndTime = new TimeOnly(23, 30) },
    new TimeSlotsModel { Id = 95, StartTime = new TimeOnly(23, 30), EndTime = new TimeOnly(23, 45) },
    new TimeSlotsModel { Id = 96, StartTime = new TimeOnly(23, 45), EndTime = new TimeOnly(23, 59) } // Adjusted last slot
);



            //    builder.Entity<TimeSlotsModel>().HasData(

            // new TimeSlotsModel { Id = 1, StartTime = new TimeOnly(9,0 ), EndTime = new TimeOnly(9,30) },
            //new TimeSlotsModel { Id = 2, StartTime = new TimeOnly(10,0 ), EndTime = new TimeOnly(10,30) },
            //new TimeSlotsModel { Id = 3, StartTime = new TimeOnly(11,0 ), EndTime = new TimeOnly(11,30) },
            //new TimeSlotsModel { Id = 4, StartTime = new TimeOnly(12,0 ), EndTime = new TimeOnly(12,30) },
            //new TimeSlotsModel { Id = 5, StartTime = new TimeOnly(13,0), EndTime = new TimeOnly(13,30) },
            //new TimeSlotsModel { Id = 6, StartTime = new TimeOnly(14,0), EndTime = new TimeOnly(14,30) },
            //new TimeSlotsModel { Id = 7, StartTime = new TimeOnly(15,0), EndTime = new TimeOnly(15,30) },
            //new TimeSlotsModel { Id = 8, StartTime = new TimeOnly(16,0), EndTime = new TimeOnly(16,30) }
            //);
        }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appoinments { get; set; }
        public DbSet<PatientModel> Patients { get; set; }

        public DbSet<TimeSlotsModel> Slots { get; set; }

    }
}


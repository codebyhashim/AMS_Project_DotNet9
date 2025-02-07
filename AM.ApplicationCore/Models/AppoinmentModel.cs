using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AM.Models
{
    public class AppointmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppoinmentStatus Status { get; set; }
        // Foreign key  User
        public int PatientId { get; set; }


        public int DoctorId { get; set; }

        //Navigation Property

        public DoctorModel? Doctor { get; set; }
        public PatientModel? Patient { get; set; }

    }
    public enum AppoinmentStatus
    {
        Pending,
        Booked,
        Cancelled,

    }
}

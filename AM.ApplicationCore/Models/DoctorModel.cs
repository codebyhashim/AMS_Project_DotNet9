using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AM.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AM.Models
{
    public class DoctorModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Speciality { get; set; }
        public string? Degree { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Experience { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? WaitTime { get; set; }

        public string? Email { get; set; }

        

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        public string? AvailabilityDays { get; set; }

        //public DayOfWeek AvailabilityDays { get; set; }

        public string? ImagePath { get; set; } // Stores image filename

        [NotMapped] // Prevents EF from storing this in DB
        public IFormFile? ImageFile { get; set; } // Only for form submission
        public string? AvailabilityTimeSlot { get; set; }

        //Navigation Property to Appointments
        public ICollection<AppointmentModel>? Appoinment { get; set; }

      
    }

}

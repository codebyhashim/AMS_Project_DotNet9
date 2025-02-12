using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AM.Models
{
    public class PatientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        // navigation Property
        //public ICollection<AppoinmentModel> Appointments { get; set; } =new List<AppoinmentModel>();
    }
    public enum Gender
    {
        selectGender, Male, Female, Other
    }
}


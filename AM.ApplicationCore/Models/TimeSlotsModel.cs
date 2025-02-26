using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AM.Models;

namespace AM.ApplicationCore.Models
{
    public class TimeSlotsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

    
        


    }
}

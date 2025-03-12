//using System.Data.Entity;
using AM.ApplicationCore.Interfaces;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using Microsoft.EntityFrameworkCore;
namespace AM.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public DoctorRepository(ApplicationDbContext _context, IEmailService emailService)
        {
            this._context = _context;
            this._emailService = emailService;
        }

        public async Task<DoctorModel> GetDoctor(string Id)
        {

            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.UserId == Id);
            return doctor;
        }

        public async Task<List<AppointmentModel>> GetDoctorAppoinments(int id)
        {
            var appoinment = await _context.Appoinments.Where(x => x.DoctorId == id).Include(x => x.Patient).Include(x => x.Doctor).ToListAsync();
            foreach (var item in appoinment)
            {
                var BookedSlots = int.Parse(item.BookedSlots);
            var slot = _context.Slots.FirstOrDefault(x=>x.Id==BookedSlots);
                item.BookedSlots = $"{slot.StartTime}-{slot.EndTime}";
                //item.AppointmentDate = item.AppointmentDate.ToString("MM/dd/yyyy");

            }
            return appoinment;


        }

        public async Task<AppointmentModel> GetAppointment(int id)
        {
            var appointment = await _context.Appoinments.FindAsync(id);
            return appointment;
        }

        public async Task<bool> BookAppointment(AppointmentModel appointment)
        {


            appointment.Status = AppoinmentStatus.Booked;
             _context.Appoinments.Update(appointment);
           await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CanceleAppointment(AppointmentModel appointment)
        {
            var email= _context.Appoinments.
                Where(x => x.AppointmentId == appointment.AppointmentId).
                Select(x=>x.Patient.User.Email).FirstOrDefault();
            


            // get the doctor selected by user and retieve the doctor details
            var getDoctor = _context.Doctors.FirstOrDefault(x => x.Id == appointment.DoctorId);


            // get Patient Name
            var getPatient = _context.Patients.FirstOrDefault(x => x.Id == appointment.PatientId);

            // get date slots 
            var slot = _context.Slots.FirstOrDefault(x => x.Id == int.Parse(appointment.BookedSlots));
            //var slotTime = $"{slot.StartTime.ToString('h mm tt') - slot.EndTime.ToString('h mm tt')}";
            var startTime = slot.StartTime.ToString("h:mm tt");
            var endTime = slot.EndTime.ToString("h:mm tt");
            var timeSlot = $"{startTime}-{endTime}";

            var message = $@"Dear {getPatient.Name},

We regret to inform you that your scheduled appointment with Dr. {getDoctor.Name} on {appointment.AppointmentDate.ToString("dd MMM,yyyy")}, at {timeSlot} has been canceled.

We understand this may be inconvenient and apologize for any disruption this may cause. If you would like to reschedule or need further assistance, please feel free to contact us at {getDoctor.Email} or you can book a new appointment through our online portal.

We appreciate your understanding.

Best regards,
HealthConnect";
            appointment.Status = AppoinmentStatus.Cancelled;
            _context.Appoinments.Update(appointment);
            await _context.SaveChangesAsync();
            await _emailService.SendEmailAsync(email, "Appointment Cancellation Notice", message);

            return true;
        }


    }
}

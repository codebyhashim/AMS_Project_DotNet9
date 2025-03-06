
using System.Security.Claims;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Models;
using AM.Data;
using AM.Data.Migrations;
using AM.Infrastructure.Services;
using AM.Interfaces;
using AM.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AM.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> userManager;

        public PatientRepository(ApplicationDbContext _context, IHttpContextAccessor _HttpContextAccessor, IEmailService emailService, UserManager<IdentityUser> userManager)
        {
            this._context = _context;
            _httpContextAccessor = _HttpContextAccessor;
            this._emailService = emailService;
            this.userManager = userManager;
        }

        public string GetLoginPatient()
        {
            var user = _httpContextAccessor.HttpContext?.User;


            var loginId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            return loginId;
        }
        public async Task<bool> RegisterPatient(PatientModel patient)
        {
            var user = _httpContextAccessor.HttpContext?.User;


            var loginId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            patient.UserId = loginId;

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdatePatient(PatientModel patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PatientModel> GetPatient(string id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.UserId == id);
            return patient;
        }


        public async Task<List<DoctorModel>> GetActiveDoctors()
        {
            var doctors = await _context.Doctors.Where(x => x.IsActive == true).ToListAsync();
            return doctors;

        }

        public Task<AppointmentModel> ShowAppointmetForm(PatientModel patient)
        {
            var appointment = new AppointmentModel
            {
                PatientId = patient.Id,
                Patient = patient,

            };
            return Task.FromResult(appointment);
        }

        public async Task<bool> GetAppointments(AppointmentModel appointments)
        {
            //step1. get login user then get email for sending email
            //step2. get doctor that select by user
            //step3 from this doctor get doctor details .
            //step4 then call inject email service and call sendemail method to send these credentials


            // get email from login user 
            var getUserCredentialDetails = _httpContextAccessor.HttpContext?.User;
            var loginId = getUserCredentialDetails?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var getLoginUser = userManager.FindByIdAsync(loginId);
            var email = getLoginUser?.Result.Email;

            // get the doctor selected by user and retieve the doctor details
            var getDoctor = _context.Doctors.FirstOrDefault(x => x.Id == appointments.DoctorId);


            // get Patient Name
            var getPatient = _context.Patients.FirstOrDefault(x => x.Id == appointments.PatientId);

            // get date slots 
            var slot = _context.Slots.FirstOrDefault(x => x.Id == int.Parse(appointments.BookedSlots));
            //var slotTime = $"{slot.StartTime.ToString('h mm tt') - slot.EndTime.ToString('h mm tt')}";
            var startTime = slot.StartTime.ToString("h:mm tt");
            var endTime = slot.EndTime.ToString("h:mm tt");
            var timeSlot = $"{startTime}-{endTime}";

            //created emaily body message
            var message = $@"
             Dear {getPatient.Name},
             
             Your appointment with Dr. {getDoctor.Name}, {getDoctor.Speciality}, has been successfully scheduled. Below are the details for your upcoming visit:

             - **Appointment Date:**   {appointments.AppointmentDate.ToString("dd MMM,yyyy")}            
             - **Appointment Time:** {timeSlot}
             - **Doctor’s Name:** Dr. {getDoctor.Name}
             - **Location:** HealthConnect, {getDoctor.Address}
             - **Contact Information:** {getDoctor.PhoneNumber}

             - **Preparation Instructions:** Please arrive 15 minutes early.

             If you need to cancel or reschedule your appointment, please contact us at least **20 hours** in advance by calling {getDoctor.PhoneNumber} or emailing {getDoctor.Email}.

             If you have any questions or require further assistance, do not hesitate to reach out.

             We look forward to seeing you on **{appointments.AppointmentDate.ToString("dd MMM,yyyy")}** at **{slot.StartTime - slot.EndTime}**.

             Best regards,  
             HealthConnect  
             {getDoctor.PhoneNumber}
             ";



            await _context.Appoinments.AddAsync(appointments);
            await _context.SaveChangesAsync();
            //await _emailService.SendEmailAsync(email, "Your Doctor Account Credentials", message);
            return true;

        }

        public async Task<List<AppointmentModel>> ViewAppoinments(PatientModel patient)
        {
            var slot = _context.Slots.ToList();


            var appointments = await _context.Appoinments.Where(x => x.PatientId == patient.Id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
            foreach (var appointment in appointments)
            {
                var matchingSlots = slot.FirstOrDefault(x => x.Id.ToString() == appointment.BookedSlots);
                if (matchingSlots != null)
                {
                    string slotTime = $"{matchingSlots.StartTime:hh:mm tt} - {matchingSlots.EndTime:hh:mm tt}";

                    appointment.BookedSlots = slotTime;
                }
            };
            return appointments;



        }



        public async Task<List<string>> GetDays(int doctorId)
        {
            var doctor = await _context.Doctors.Where(x => x.Id == doctorId).FirstOrDefaultAsync();
            //if (doctor == null)
            //{
            //    //var message = "Doctor not found.";
            //    return "Doctor not found.";
            //}


            var doctorAvailabilityDay = doctor.AvailabilityDays.Split(",")
       .Select(s => int.Parse(s))
       .Select(day => (DayOfWeek)day)
       .Select(day => day.ToString()).Select(s => s.Trim()) // Convert DayOfWeek enum to string (e.g., "Sunday", "Monday")
       .ToList();


            return doctorAvailabilityDay;
        }



        public async Task<List<SelectListItem>> DisplaySlots(int doctorId, string date)
        {
            DateTime dat = DateTime.Parse(date);
            DayOfWeek userSelecteDay = dat.DayOfWeek;

            // Select doctor from db
            var doctor = await _context.Doctors.Where(x => x.Id == doctorId).FirstOrDefaultAsync();
            //if (doctor == null)
            //{
            //    return Json(new { message = "Doctor not found." });
            //}

            // Get selected doctor slots and convert to array of int
            var doctorSlots = doctor.AvailabilityTimeSlot.Split(',').Select(s => int.Parse(s)).ToArray();

            // Get doctor availability days
            var doctorAvailabilityDays = doctor.AvailabilityDays.Split(",")
                .Select(s => int.Parse(s))
                .Select(day => (DayOfWeek)day)
                .ToList();


            // Get  slots for the given doctor and date
            var bookedSlot = _context.Appoinments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate == dat && a.Status == AppoinmentStatus.Booked)
                .Select(a => int.Parse(a.BookedSlots))
                .ToList();

            // Get  slots for the given doctor and date
            var cancelAppointments = _context.Appoinments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate == dat && a.Status == AppoinmentStatus.Cancelled)
                .Select(a => int.Parse(a.BookedSlots))
                .ToList();

            // Get all slots for the doctor
            var allSlots = _context.Slots
                .Where(x => doctorSlots.Contains(x.Id))
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.StartTime:hh:mm tt} - {x.EndTime:hh:mm tt}",
                    //Selected = bookedSlot.Contains(x.Id),
                    Disabled = bookedSlot.Contains(x.Id),
                }).ToList();
            return allSlots;
        }

        public async Task<List<TimeSlotsModel>> GetAllSlots()
        {
            var slots = _context.Slots.ToList();
            return slots;
        }
    }
}



//Dear [Patient's Name],

//Your appointment with Dr. [Doctor's Name], [Doctor's Specialty], has been successfully scheduled. Below are the details for your upcoming visit:

//Appointment Date: [Date]
//Appointment Time: [Time]
//Doctor’s Name: Dr. [Doctor’s Full Name]
//Location: [Clinic/Hospital Name], [Full Address]
//Contact Information: [Phone number or email for inquiries]
//Reason for Appointment: [Brief reason for visit, such as consultation, routine check-up, etc.]

//Preparation Instructions:
//[Instructions, such as "Please arrive 15 minutes early," or "Fast for 12 hours prior to your visit."]
//If you need to cancel or reschedule your appointment, please contact us at least [time frame, e.g., 24 hours] in advance by calling [Phone Number] or emailing [Email Address].

//If you have any questions or require further assistance, do not hesitate to reach out.

//We look forward to seeing you on [Date] at [Time].

//Best regards,
//[Your Clinic’s Name]
//[Contact Details]Dear [Patient's Name],

//Your appointment with Dr. [Doctor's Name], [Doctor's Specialty], has been successfully scheduled. Below are the details for your upcoming visit:

//Appointment Date: [Date]
//Appointment Time: [Time]
//Doctor’s Name: Dr. [Doctor’s Full Name]
//Location: [Clinic/Hospital Name], [Full Address]
//Contact Information: [Phone number or email for inquiries]
//Reason for Appointment: [Brief reason for visit, such as consultation, routine check-up, etc.]

//Preparation Instructions:
//[Instructions, such as "Please arrive 15 minutes early," or "Fast for 12 hours prior to your visit."]
//If you need to cancel or reschedule your appointment, please contact us at least [time frame, e.g., 24 hours] in advance by calling [Phone Number] or emailing [Email Address].

//If you have any questions or require further assistance, do not hesitate to reach out.

//We look forward to seeing you on [Date] at [Time].

//Best regards,
//[Your Clinic’s Name]
//[Contact Details]


using System.Security.Claims;
using AM.ApplicationCore.Models;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AM.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public PatientRepository(ApplicationDbContext _context, IHttpContextAccessor _HttpContextAccessor)
        {
            this._context = _context;
            _httpContextAccessor = _HttpContextAccessor;
           
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
            //var slot = int.Parse(appointments.BookedSlots);
            //var getSlot = _context.Slots.FirstOrDefault(x=>x.Id==slot);
            //Console.WriteLine(getSlot);

            //appointments.BookedSlots = $"{ getSlot.StartTime} - {getSlot.EndTime}";
            await _context.Appoinments.AddAsync(appointments);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<AppointmentModel>> ViewAppoinments(PatientModel patient)
        {
            var slot = _context.Slots.ToList();
           
                
            var appointments = await _context.Appoinments.Where(x => x.PatientId == patient.Id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
                foreach (var appointment in appointments)
                {
                var matchingSlots = slot.FirstOrDefault(x => x.Id.ToString() == appointment.BookedSlots);
                    if (matchingSlots!=null)
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

       

      public async  Task<List<SelectListItem>> DisplaySlots(int doctorId, string date)
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
            var slots= _context.Slots.ToList();
            return slots;
        }
    }
}

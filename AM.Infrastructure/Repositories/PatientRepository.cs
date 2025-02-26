
using System.Security.Claims;
using AM.ApplicationCore.Models;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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


    }
}

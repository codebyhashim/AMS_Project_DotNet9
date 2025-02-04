
using System.Security.Claims;
using AM.Data;
using AM.Interfaces;
using AM.Models;
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
        public void RegisterPatient(PatientModel patient)
        {
            var user = _httpContextAccessor.HttpContext?.User;


            var loginId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            patient.UserId = loginId;

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }


        public async Task<PatientModel> UpdatePatient(PatientModel patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
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

        public async Task<AppoinmentModel> ShowAppointmetForm(PatientModel patient)
        {
            var appointment = new AppoinmentModel
            {
                PatientId = patient.Id,
                Patient = patient,

            };
            return appointment;
        }

        public async Task GetAppoinments(AppoinmentModel appointments)
        {
            await _context.Appoinments.AddAsync(appointments);
            await _context.SaveChangesAsync();

        }

        public async Task<List<AppoinmentModel>> ViewAppoinments(PatientModel patient)
        {
            var appointments = await _context.Appoinments.Where(x => x.PatientId == patient.Id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
            return appointments;
        }


    }
}

//using System.Data.Entity;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using Microsoft.EntityFrameworkCore;
namespace AM.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<DoctorModel> GetDoctor(string Id)
        {

            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.UserId == Id);
            return doctor;
        }

        public async Task<List<AppoinmentModel>> GetDoctorAppoinments(int id)
        {
            var appoinment = await _context.Appoinments.Where(x => x.DoctorId == id).Include(x => x.Patient).Include(x => x.Doctor).ToListAsync();
            return appoinment;


        }

        public async Task<AppoinmentModel> GetAppointment(int id)
        {
            var appointment = await _context.Appoinments.FindAsync(id);
            return appointment;
        }

        public async Task<bool> BookAppointment(AppoinmentModel appointment)
        {


            appointment.Status = AppoinmentStatus.Booked;
             _context.Appoinments.Update(appointment);
           await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CanceleAppointment(AppoinmentModel appointment)
        {
            appointment.Status = AppoinmentStatus.Cancelled;
            _context.Appoinments.Update(appointment);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}

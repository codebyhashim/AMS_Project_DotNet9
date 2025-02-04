using System.Security.Claims;
using AM.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {


        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {

            _doctorRepository = doctorRepository;
        }



        [HttpGet("Doctor/Index")]

        public async Task<IActionResult> Index()
        {
            var loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var doctor = await _doctorRepository.GetDoctor(loginId);
            //var doctor = await context.Doctors.FirstOrDefaultAsync(x => x.UserId == loginId);


            if (doctor == null)
            {
                // If the doctor doesn't exist, handle this scenario (e.g., prompt user to create doctor profile)
                return Json("there is no doctor");  // Redirect to create doctor profile if necessary
            }


            //var Appoinment = await context.Appoinments.Where(a => a.DoctorId == doctor.Id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();

            var appoinment = await _doctorRepository.GetDoctorAppoinments(doctor.Id);
            return View(appoinment);



        }
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {


            var appointmet = await _doctorRepository.GetAppointment(id);

            if (appointmet != null)
            {
                _doctorRepository.BookAppointment(appointmet);

            }



            return RedirectToAction("Index", "Doctor");
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int Id)
        {

            var appointment = await _doctorRepository.GetAppointment(Id);
            if (appointment != null)
            {
                _doctorRepository.CanceleAppointment(appointment);

            }
            return RedirectToAction("Index", "Doctor");
        }
    }
}

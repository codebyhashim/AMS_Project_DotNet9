using System.Security.Claims;
using AM.ApplicationCore.Features.Admin.GetAppointmentById;
using AM.ApplicationCore.Features.Doctor.BookAppoinment;
using AM.ApplicationCore.Features.Doctor.GetDoctor;
using AM.ApplicationCore.Features.Doctor.GetDoctorAppointments;
using AM.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {


        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediator _mediator;

        public DoctorController(IDoctorRepository doctorRepository, IMediator mediator)
        {

            _doctorRepository = doctorRepository;
            this._mediator = mediator;
        }



        [HttpGet("Doctor/Index")]

        public async Task<IActionResult> Index()
        {
            var loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var doctor = await _doctorRepository.GetDoctor(loginId);
            var doctor = await _mediator.Send(new GetDoctorRequest() { Id = loginId });

            //var doctor = await context.Doctors.FirstOrDefaultAsync(x => x.UserId == loginId);


            if (doctor == null)
            {
                // If the doctor doesn't exist, handle this scenario (e.g., prompt user to create doctor profile)
                return Json("there is no doctor");  // Redirect to create doctor profile if necessary
            }


            //var Appoinment = await context.Appoinments.Where(a => a.DoctorId == doctor.Id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();

            //var appoinment = await _doctorRepository.GetDoctorAppoinments(doctor.Id);
            var appoinment = await _mediator.Send(new GetDoctorAppoinmentsRequest { Id = doctor.Id });

            return View(appoinment);



        }
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {


            var appointmet = await _doctorRepository.GetAppointment(id);
            //var appointmet = await _mediator.Send(new GetDoctorAppoinmentsRequest() { Id = id });


            if (appointmet != null)
            {
                //await _mediator.Send(new BookAppointmentRequest(appointmet));
                await _doctorRepository.BookAppointment(appointmet);

            }



            return RedirectToAction("Index", "Doctor");
        }

            [HttpPost]
            public async Task<IActionResult> Cancel(int Id)
            {

                var appointment = await _doctorRepository.GetAppointment(Id);
                if (appointment != null)
                {
                    await _doctorRepository.CanceleAppointment(appointment);

                }
                return RedirectToAction("Index", "Doctor");
            }
        }
    }


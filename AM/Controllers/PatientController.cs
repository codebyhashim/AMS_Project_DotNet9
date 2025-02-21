using AM.ApplicationCore.Features.Doctor.GetDoctor;
using AM.ApplicationCore.Features.Patient.BookAppoinments;
using AM.ApplicationCore.Features.Patient.DisplayAppointmentForm;
using AM.ApplicationCore.Features.Patient.GetActiveDoctors;
using AM.ApplicationCore.Features.Patient.GetLoginUserId;
using AM.ApplicationCore.Features.Patient.GetPateint;
using AM.ApplicationCore.Features.Patient.RegisterPatient;
using AM.ApplicationCore.Features.Patient.UpdatePatient;
using AM.ApplicationCore.Features.Patient.ViewAppoinments;
using AM.ApplicationCore.Models;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using AM.Views.Patient;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Controllers
{

    [Authorize(Roles = "Admin,Patient")]
    public class PatientController : Controller
    {

       
        private readonly IMediator _mediator;
        private readonly IValidator<PatientModel> _validator;
        private readonly ApplicationDbContext applicationDb;


        //private readonly IValidator<AppointmentModel> _appoinmentvalidator;

        public PatientController(IMediator mediator , IValidator<PatientModel> validator , ApplicationDbContext applicationDb)
        {

            this._mediator = mediator;
            this._validator = validator;
            this.applicationDb = applicationDb;
        }






        [HttpGet("Patient/PatientRegister")]
        public Task<IActionResult> PatientRegister()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = _patientRepository.GetLoginPatient();
            var userId = _mediator.Send(new GetLoginUserIdRequest()).Result;


            if (string.IsNullOrEmpty(userId))
            {
                return Task.FromResult<IActionResult>(RedirectToAction("Login", "Account"));
            }
            //var user = context.Patients.Where(x => x.UserId == userId).Count();
            //var user = _patientRepository.GetPatient(userId).Result;
            var user = _mediator.Send(new GetPatientRequest() { Id = userId }).Result;

            if (user != null)
            {
                return Task.FromResult<IActionResult>(RedirectToAction("MakeAppoinment", "patient"));


            }
            else
            {
                ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                return Task.FromResult<IActionResult>(View());
            }

        }

        [HttpPost("Patient/PatientRegister")]
        public async Task<IActionResult> PatientRegister(PatientModel patient)
        {
            

            var validation =await _validator.ValidateAsync(patient);
            if (validation.IsValid)
            {
                await _mediator.Send(new RegisterPatientRequest(patient));

                   return RedirectToAction("MakeAppoinment");
            }
            else
            {
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
                return View();

            }
            //if (ModelState.IsValid)
            //{

            //    //var getLoginID =  _patientRepository.GetLoginPatient();
            //    //_patientRepository.RegisterPatient(patient);
            //    await _mediator.Send(new RegisterPatientRequest(patient));
            //    return RedirectToAction("MakeAppoinment");
            //}

        }


        public async Task<IActionResult> Updatedetails()
        {
            //var logInId = _patientRepository.GetLoginPatient();
            var logInId =await _mediator.Send(new GetLoginUserIdRequest());
            //var patient = _patientRepository.GetPatient(logInId).Result;
            var patient =await _mediator.Send(new GetPatientRequest() { Id=logInId});
            ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
            return View(patient);

        }
        [HttpPost]
        public async Task<IActionResult> Updatedetails(PatientModel patient)
        {
            var validation =await _validator.ValidateAsync(patient);
            if (validation.IsValid)
            {
                 await _mediator.Send(new UpdatePatientRequest(patient));

                TempData["sucessMessage"] = "Updated Successfully";
                return RedirectToAction("Updatedetails");
            }
            else
            {

                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            
            //await _patientRepository.UpdatePatient(patient);
            //await _mediator.Send(new UpdatePatientRequest(patient));

            //TempData["sucessMessage"] = "Updated Successfully";
            //return RedirectToAction("Updatedetails");
        }

        public async Task<IActionResult> MakeAppoinment()
        {

            //var userId = _patientRepository.GetLoginPatient();

            var userId = _mediator.Send(new GetLoginUserIdRequest()).Result;
            //var patient = await _patientRepository.GetPatient(userId);
            var patient = await _mediator.Send(new GetPatientRequest() { Id= userId });

            if (patient != null)
            {
                //var doctors = _patientRepository.GetActiveDoctors();
                var doctors = _mediator.Send(new GetActiveDoctorsRequest());
                if (doctors == null)
                {
                    return BadRequest("doctor not registered");
                }
                ViewBag.doctors = doctors.Result;

                //var time=applicationDb.Slots.ToList();

                //    ViewBag.timeSlot = time;
                
                
               
                //var appointmentModel = _patientRepository.ShowAppointmetForm(patient);
                var appointmentModel = _mediator.Send(new DisplayAppointmentFormRequest() {Patients=patient });

                ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                return View(appointmentModel.Result);
            }
            else
            {
                return RedirectToAction("PatientRegister", "Patient");

            }


        }
        [HttpPost]
        public async Task<IActionResult> MakeAppoinment(AppointmentModel appointment)
        {
            //var validation = await appoinmentvalidator.ValidateAsync(appointment);
            //if (validation.IsValid)
            //{
                await _mediator.Send(new BookAppointmentsRequest(appointment));

            return RedirectToAction("ViewAppoinment", "Patient");
            //}
            //else
            //{
            //    foreach (var error in validation.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return View();
            //}
        }

        //return View();
        //await _patientRepository.GetAppointments(appoinment);
        //await _mediator.Send(new BookAppointmentsRequest(appointment));

        //return RedirectToAction("ViewAppoinment", "Patient");




        public async Task<IActionResult> ViewAppoinment()
        {

            //var loginId = _patientRepository.GetLoginPatient();
            var loginId = _mediator.Send(new GetLoginUserIdRequest()).Result;

            //var patient = _patientRepository.GetPatient(loginId).Result;
            var patient =await _mediator.Send(new GetPatientRequest() { Id=loginId});

            if (patient == null)
            {
                ViewBag.msg = "no Appointment";
            }
            else
            {
                //var data = _patientRepository.ViewAppoinments(patient).Result;
                var data = _mediator.Send(new ViewAppointmentsRequest(patient)).Result;
                //var data = _mediator.Send(new ViewAp);


                //if (data.Count == 0)
                //{
                //    ViewBag.msg = "NO Appoinment";
                //}
                //else
                //{

                    return View(data);
                //}


            }
            return View();
        }


        // patient Regiter actions method

        //[HttpGet("Patient/Index")]
        //public async Task<IActionResult> Index()

        //{
        //    var loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (string.IsNullOrEmpty(loginId)) RedirectToAction("Login", "Account");
        //    var data = await context.Patients.Where(x => x.UserId == loginId).ToListAsync();
        //    if (data == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        return View(data);
        //    }



        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(int Id)
        //{

        //    var patient = await context.Patients.FindAsync(Id);
        //    //context.Patients.Remove(data);
        //    //context.SaveChanges();  
        //    return View(patient);
        //}
        //[HttpPost("Patient/Delete")]
        //[ActionName("Delete")]
        //public async Task<IActionResult> ConfirmDelete(int Id)
        //{

        //    var patient = context.Patients.Find(Id);
        //    if (patient != null)
        //    {
        //        context.Patients.Remove(patient);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }



        //    return View();


        //}
        //[HttpGet("Pateint/Edit")]
        //public IActionResult Edit(int Id)
        //{
        //    var patient = context.Patients.Find(Id);

        //    return View(patient);
        //}
        //[HttpPost("Pateint/Edit")]
        //public IActionResult Edit(PatientModel patient)
        //{

        //    if (ModelState.IsValid)
        //    {


        //        context.Patients.Update(patient);
        //        context.SaveChanges();
        //        return RedirectToAction("Index", "patient");


        //    }
        //    return View();


        //}
        //[HttpPost]
        //public IActionResult CancelAppoinmentConfirmed(int id)
        //{
        //    var appoinment = context.Appoinments.Find(id);
        //    if (appoinment != null)
        //    {
        //        context.Appoinments.Remove(appoinment);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("ViewAppoinment", "Patient");
        //}








        //    public IActionResult CancelAppoinment(int id)
        //    {
        //        var patient = context.Appoinments.Find(id);
        //        if (patient != null)
        //        {
        //            var doctor = context.Doctors.FirstOrDefault(x => x.Id == patient.DoctorId);
        //            if (doctor != null)
        //            {
        //                ViewBag.doctorName = doctor.Name;
        //                ViewBag.DoctorSpeciality = doctor.Speciality;
        //            }
        //        }



        //        return View(patient);
        //    }

    }
}

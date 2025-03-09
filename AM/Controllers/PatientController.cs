using AM.ApplicationCore.Features.Doctor.GetDoctor;
using AM.ApplicationCore.Features.Patient.BookAppoinments;
using AM.ApplicationCore.Features.Patient.DisplayAppointmentForm;
using AM.ApplicationCore.Features.Patient.DisplayDoctorSlots;
using AM.ApplicationCore.Features.Patient.GetActiveDoctors;
using AM.ApplicationCore.Features.Patient.GetAllSlots;
using AM.ApplicationCore.Features.Patient.GetDoctorDays;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace AM.Controllers
{

    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {

       
        private readonly IMediator _mediator;
        private readonly IValidator<PatientModel> _validator;
        private readonly IValidator<AppointmentModel> _appointmentValidator;
        private readonly IPatientRepository patientRepository;

        //private readonly ApplicationDbContext applicationDb;



        //private readonly IValidator<AppointmentModel> _appoinmentvalidator;

        public PatientController(IMediator mediator , IValidator<PatientModel> pateintValidator ,IValidator<AppointmentModel> AppointmentValidator, ApplicationDbContext applicationDb, IPatientRepository patientRepository)
        {
 
            this._mediator = mediator;
            this._validator = pateintValidator;
            _appointmentValidator = AppointmentValidator;
            this.patientRepository = patientRepository;
            //this.applicationDb = applicationDb;

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

                //var time = applicationDb.Slots.ToList();
                //var time = patientRepository.GetAllSlots();
                var time = _mediator.Send(new GetAllSlotsRequest()).Result;



                ViewBag.timeSlot = time;



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
            var validation = await _appointmentValidator.ValidateAsync(appointment);
            if (validation.IsValid)
            {

                //var doctor = applicationDb.Doctors.Where(x => x.Id == doctorId).FirstOrDefault();
                //var doctorSlots = doctor.AvailabilityTimeSlot.Split(',').Select(s => int.Parse(s))
                //                                   .ToArray();

                //var selectSlot = applicationDb.Slots.Where(x => doctorSlots.Contains(x.Id)).ToList();
                //if (selectSlot != null)
                //{

                //  return selectSlot;
                //}

                await _mediator.Send(new BookAppointmentsRequest(appointment));
                
                TempData["Message"]= "Appointment has been booked successfully and email sent successfully ";

                return RedirectToAction("ViewAppoinment", "Patient");
            }
            else
            {
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
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





        public async Task<IActionResult> GetDays(int doctorId)
        {

            var days = _mediator.Send(new GetDaysRequest(doctorId)).Result;
            return  Json(days);
       
        }


        public IActionResult SelectedSlots(int doctorId, string date)
        {

            var slot = _mediator.Send(new DisplayDoctorSlotsRequest(doctorId,date)).Result;
            return Json(slot);
            


        }




        //public async Task<IActionResult> GetDays(int doctorId)
        //{

            //var days = _mediator.Send(new GetDaysRequest(doctorId)).Result;
            //var days = patientRepository.GetDays(doctorId).Result;
            //return Json(days);
            //     var doctor = await applicationDb.Doctors.Where(x => x.Id == doctorId).FirstOrDefaultAsync();
            //     if (doctor == null)
            //     {
            //         return Json(new { message = "Doctor not found." });
            //     }


            //     var doctorAvailabilityDay = doctor.AvailabilityDays.Split(",")
            //.Select(s => int.Parse(s))
            //.Select(day => (DayOfWeek)day)
            //.Select(day => day.ToString()).Select(s => s.Trim()) // Convert DayOfWeek enum to string (e.g., "Sunday", "Monday")
            //.ToList();


            //return Json(doctorAvailabilityDay);
        //}



        //public IActionResult SelectedSlots(int doctorId, string date)
        //{

        //    DateTime dat = DateTime.Parse(date);
        //    //string userSelectedday = dat.DayOfWeek.ToString();

        //    DayOfWeek userSelecteDay = dat.DayOfWeek;



        //    //select doctor from db
        //    var doctor = applicationDb.Doctors.Where(x => x.Id == doctorId).FirstOrDefault();
        //    if (doctor == null)
        //    {
        //        return Json(new { message = "Doctor not found." });
        //    }
        //    // get selected doctor slots to convert  array using split and  then converto into int
        //    var doctorSlots = doctor.AvailabilityTimeSlot.Split(',').Select(s => int.Parse(s))
        //                                       .ToArray();

        //    // get doctor day from db
        //    //var doctorDay = doctor.AvailabilityDays.Split(",").Select(s => int.Parse(s)).ToList();

        //    //select day 
        //    var doctorAvailabilityDays = doctor.AvailabilityDays.Split(",").Select(s => int.Parse(s)).Select(day => (DayOfWeek)day).ToList();
        //    if (!doctorAvailabilityDays.Contains(userSelecteDay))
        //    {
        //        return Json(new { message = "Doctor is not available on this day." });
        //    }


        //    // get doctor slots from slot table  
        //    var selectSlot = applicationDb.Slots.Where(x => doctorSlots.Contains(x.Id))
        //        .Select(x => new SelectListItem
        //        {
        //            Value = x.Id.ToString(),
        //            Text = $"{x.StartTime:hh:mm tt} - {x.EndTime:hh:mm tt}"
        //        }
        //        ).ToList();



        //    return Json(selectSlot);

        //}
        //public IActionResult SelectedSlots(int doctorId, string date)
        //{
        //    DateTime dat = DateTime.Parse(date);
        //    DayOfWeek userSelecteDay = dat.DayOfWeek;

        //    // Select doctor from db
        //    var doctor = applicationDb.Doctors.Where(x => x.Id == doctorId).FirstOrDefault();
        //    if (doctor == null)
        //    {
        //        return Json(new { message = "Doctor not found." });
        //    }

        //    // Get selected doctor slots and convert to array of int
        //    var doctorSlots = doctor.AvailabilityTimeSlot.Split(',').Select(s => int.Parse(s)).ToArray();

        //    // Get doctor availability days
        //    var doctorAvailabilityDays = doctor.AvailabilityDays.Split(",")
        //        .Select(s => int.Parse(s))
        //        .Select(day => (DayOfWeek)day)
        //        .ToList();

        //    // Check if the doctor is available on the selected day
        //    if (!doctorAvailabilityDays.Contains(userSelecteDay))
        //    {
        //        return Json(new { message = "Doctor is not available on this day." });
        //    }

        //    // Get all slots for the doctor
        //    var allSlots = applicationDb.Slots
        //        .Where(x => doctorSlots.Contains(x.Id))
        //        .Select(x => new SelectListItem
        //        {
        //            Value = x.Id.ToString(),
        //            Text = $"{x.StartTime:hh:mm tt} - {x.EndTime:hh:mm tt}"
        //        })
        //        .ToList();

        //    // Get booked slots for the given doctor and date
        //    var bookedSlotIds = applicationDb.Appoinments
        //        .Where(a => a.DoctorId == doctorId && a.AppointmentDate == dat)
        //        .Select(a => a.BookedSlots)
        //        .ToList();

        //    // Filter out the booked slots
        //    var unbookedSlots = allSlots
        //        .Where(slot => !bookedSlotIds.Contains((slot.Value)))
        //        .ToList();

        //    return Json(unbookedSlots);
        //}



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


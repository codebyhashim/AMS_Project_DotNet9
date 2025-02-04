using AM.Interfaces;
using AM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Controllers
{

    [Authorize(Roles = "Admin,Patient")]
    public class PatientController : Controller
    {

        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {

            this._patientRepository = patientRepository;
        }






        [HttpGet("Patient/PatientRegister")]
        public IActionResult PatientRegister()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = _patientRepository.GetLoginPatient();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }
            //var user = context.Patients.Where(x => x.UserId == userId).Count();
            var user = _patientRepository.GetPatient(userId).Result;

            if (user != null)
            {
                return RedirectToAction("MakeAppoinment", "patient");


            }
            else
            {
                ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                return View();
            }

        }

        [HttpPost("Patient/PatientRegister")]
        public async Task<IActionResult> PatientRegister(PatientModel patient)
        {
            if (ModelState.IsValid)
            {

                var getLoginID = _patientRepository.GetLoginPatient();
                _patientRepository.RegisterPatient(patient);
                return RedirectToAction("MakeAppoinment");
            }

            return View();
        }


        public IActionResult Updatedetails()
        {
            var logInId = _patientRepository.GetLoginPatient();
            var patient = _patientRepository.GetPatient(logInId).Result;
            return View(patient);

        }
        [HttpPost]
        public async Task<IActionResult> Updatedetails(PatientModel patient)
        {
            await _patientRepository.UpdatePatient(patient);
            TempData["sucessMessage"] = "Updated Successfully";
            return RedirectToAction("Updatedetails");
        }

        public async Task<IActionResult> MakeAppoinment()
        {

            var userId = _patientRepository.GetLoginPatient();

            var patient = await _patientRepository.GetPatient(userId);
            if (patient != null)
            {
                var doctors = _patientRepository.GetActiveDoctors();
                ViewBag.doctors = doctors.Result;
                var appointmentModel = _patientRepository.ShowAppointmetForm(patient);
                ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                return View(appointmentModel.Result);
            }
            else
            {
                return RedirectToAction("PatientRegister", "Patient");

            }


        }
        [HttpPost]
        public async Task<IActionResult> MakeAppoinment(AppoinmentModel appoinment)
        {
            await _patientRepository.GetAppoinments(appoinment);
            return RedirectToAction("ViewAppoinment", "Patient");
        }


        public IActionResult ViewAppoinment()
        {

            var loginId = _patientRepository.GetLoginPatient();
            var patient = _patientRepository.GetPatient(loginId).Result;
            if (patient == null)
            {
                ViewBag.msg = "no Appointment";
            }
            else
            {
                var data = _patientRepository.ViewAppoinments(patient).Result;

                if (data.Count == 0)
                {
                    ViewBag.msg = "NO Appoinment";
                }
                else
                {

                    return View(data);
                }


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

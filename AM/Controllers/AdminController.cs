using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

using AM.ApplicationCore.Features.Admin.BookAppoinment;
using AM.ApplicationCore.Features.Admin.CancelAppointment;
using AM.ApplicationCore.Features.Admin.CreateDoctor;
using AM.ApplicationCore.Features.Admin.DashboardCounts;
using AM.ApplicationCore.Features.Admin.DeleteDoctor;

using AM.ApplicationCore.Features.Admin.GetAllAppoinments;
using AM.ApplicationCore.Features.Admin.GetAllDoctors;
using AM.ApplicationCore.Features.Admin.GetAppointmentById;
using AM.ApplicationCore.Features.Admin.GetDoctorById;
using AM.ApplicationCore.Features.Admin.InviteDoctor;
using AM.ApplicationCore.Features.Admin.UpdateDoctor;
using AM.ApplicationCore.Features.Admin.UpdateLockDoctor;
using AM.ApplicationCore.Validator;


//using AM.ApplicationCore.queries.Admin;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using AM.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Serilog;
using static System.Reflection.Metadata.BlobBuilder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace AM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
       
        private readonly IMediator _mediator;
        //private readonly ILogger logger;
        private readonly IValidator<DoctorModel> _validator;
        private readonly ApplicationDbContext applicationDbContext;

        public AdminController(ApplicationDbContext _Context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMediator _mediator, ILogger<AdminController> logger, IValidator<DoctorModel> validator, ApplicationDbContext applicationDbContext )
        {
            context = _Context;
            this.userManager = userManager;
            this.roleManager = roleManager;
          
            this._mediator = _mediator;
            //this.logger = logger;
            this._validator = validator;
            this.applicationDbContext = applicationDbContext;


            //this.validator = this.validator;
        }

        //  create button and action method in admin controllers
        // in action method we change logic of true and false

        public async Task<IActionResult> Index()
        {

            //var counts =  adminRepository.Counts();
            var counts = await _mediator.Send(new DashboardCountsRequest());

            return View(counts);
        }

        [HttpGet("Admin/ViewDoctors")]
        public async Task<IActionResult> ViewDoctors()
        {
            
            //var listOfDoctors = adminRepository.ViewDoctors().Result;
            
            var listOfDoctors = await _mediator.Send(new GetAllDoctorsRequest());
            
           
            return View(listOfDoctors);
          
        }

        [HttpGet("Doctor/Create")]
        public IActionResult Create()
        {

            var slots = context.Slots.ToList();
           
            ViewBag.Slots = slots;
            // creating object and pass to the view
            return View();
        }


        [HttpPost("Doctor/Create")]
        public async Task<IActionResult> Create([FromForm] DoctorModel doctor , List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {

            //var validator = await _validator.ValidateAsync(doctor);
            var validation = await _validator.ValidateAsync(doctor);
            if (validation.IsValid)
            {
                await _mediator.Send(new CreateDoctorRequest(doctor,AvailabilityDays, AvailabilityTimeSlot));

                return RedirectToAction("ViewDoctors", "Admin");
            }
            foreach (var error in validation.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            //if (ModelState.IsValid)
            //{

            //    //await adminRepository.CreateDoctor(doctor);

            //    await _mediator.Send(new CreateDoctorRequest(doctor));

            //    return RedirectToAction("ViewDoctors", "Admin");
            //}

            return View();
        }

        //[HttpGet("Doctor/Delete")]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    //var selectData = await context.Doctors.FindAsync(Id);
        //    //var doctor = await adminRepository.GetDoctorById(Id);

        //    var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = Id });
        //    if (doctor == null) NotFound();

        //    return View(doctor);
        //}
        [HttpPost("Doctor/Delete/{Id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {

            //var doctor = await adminRepository.GetDoctorById(Id);
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = Id });

            if (doctor != null)
            {
                //await adminRepository.DeleteDoctor(doctor);
                await _mediator.Send(new DeleteDoctorRequest() { id = doctor.Id });
                TempData["deleteMessage"] = "Deleted Sucessfully";
                return RedirectToAction("ViewDoctors", "Admin");
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        public async Task<IActionResult> ShowDoctor(int id)
        {
            //var doctor =await context.Doctors.FindAsync(id);
            //var doctor = adminRepository.GetDoctorById(id).Result;
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = id });
            if (doctor != null)
            {
                if (doctor.IsActive == true)
                {
                    TempData["Lock"] = "The doctor is now locked";
                    doctor.IsActive = false;
                }
                else
                {
                    TempData["Lock"] = "The doctor is now Unlocked";
                    doctor.IsActive = true;

                }
                //await adminRepository.DoctorStatusUpdate(doctor);
                await _mediator.Send(new UpdateDoctorRequest(doctor));

            }
            return RedirectToAction("ViewDoctors", "Admin");
        }
       

        [HttpGet("Doctor/Edit")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    // Fetch the doctor details
        //    var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = id });

        //    // Get the selected slot IDs from the doctor's AvailabilityTimeSlot
        //    var selectedSlotIds = doctor.AvailabilityTimeSlot?.Split(','); // Split the comma-separated string into an array

        //    // Get all available slots from the database
        //    var slots = context.Slots.ToList();

        //    // Create a list of SelectListItem with the selected slots marked as selected
        //    var selectedSlotList = slots.Select(x => new SelectListItem
        //    {
        //        Text = $"{x.StartTime} - {x.EndTime}", // Format the display text
        //        Value = x.Id.ToString(),
        //        Selected = selectedSlotIds?.Contains(x.Id.ToString()) ?? false // Mark as selected if the slot ID is in the selectedSlotIds array
        //    }).ToList();

        //    // Assign the list to ViewBag.SlotList
        //    ViewBag.SlotList = selectedSlotList;

        //    return View(doctor);
        //}





        public async Task<IActionResult> Edit(int id)
        {
            //var doctor = await adminRepository.GetDoctorById(id);
            // Fetch the doctor details
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = id });

            // Get all available slots from the database
            var slots = context.Slots.ToList();
            // Get the selected slot IDs from the doctor's AvailabilityTimeSlot
            var selectedSlots = doctor.AvailabilityTimeSlot.Split(',');

            // Get the selected slot IDs from the doctor's AvailabilityTimeSlot

            var selecetedDays = doctor.AvailabilityDays.Split(',');

            var daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
                .Select(day => new SelectListItem
                {
                    Text=day.ToString(),
                    Value= ((int)day).ToString(),
                    Selected=selecetedDays.Contains(((int)day).ToString())

                }).ToList();

            ViewBag.Days = daysOfWeek;
            // Create a list of SelectListItem with the selected slots marked as selected
            var selectedSlotList = slots.Select(x => new SelectListItem
            {
                Text = x.StartTime + "-" + x.EndTime,
                Value = x.Id.ToString(),
                Selected = selectedSlots.Any(y => y.Equals(x.Id.ToString())) // Mark as selected if the slot ID is in the selectedSlotIds array
                //Selected = selectedSlots?.Contains(x.Id.ToString()) ?? false

            }).ToList();
            //ViewBag.SlotList = new MultiSelectList(selectedSlotList, "Value", "Text", selectedSlots);

            // Assign the list to ViewBag.SlotList
            ViewBag.SlotList = selectedSlotList;

            //Console.WriteLine(totalTimeslot);
            return View(doctor);
        }
        [HttpPost("Doctor/Edit")]
        public async Task<IActionResult> Edit(DoctorModel doctorModel, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {
            var validation =await _validator.ValidateAsync(doctorModel);

            if (validation.IsValid)
            {
                //await adminRepository.DoctorUpdate(doctorModel);
                //await _mediator.Send(new UpdateDoctorRequest(doctorModel));

                await _mediator.Send(new UpdateDoctorLockRequest(doctorModel,AvailabilityDays, AvailabilityTimeSlot));

                TempData["UpdatedMessage"] = "Updated Successfully";
                return RedirectToAction("ViewDoctors", "Admin");

            }
            else
            {
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }


            //if (ModelState.IsValid)
            //{
            //    //await adminRepository.DoctorUpdate(doctorModel);
            //    await _mediator.Send(new UpdateDoctorRequest(doctorModel));

            //    TempData["UpdatedMessage"] = "Updated Successfully";                                                       // Step 5: Redirect to the Index page after succ 
            //}


        }
        public async Task<IActionResult> Approve(int id)
        {
            //var appointment = context.Appoinments.Find(id);
            //var appointment = await adminRepository.GetAppointmentById(id);
            var appointment = await _mediator.Send(new GetAppointmentByIdRequest { Id = id });

            if (appointment != null)
            {
                await _mediator.Send(new BookAppointmentRequest(appointment));
                //adminRepository.BookAppointment(appointment);

            }
            //if (appoinmet != null)
            //{
            //    appoinmet.Status = AppoinmentStatus.Booked;
            //    context.Appoinments.Update(appoinmet);
            //    context.SaveChanges();
            //}



            return RedirectToAction("ViewAppoinments", "Admin");
        }

        //[HttpPost]    
        public async Task<IActionResult> Cancel(int id)
        {

            //var appointment = await adminRepository.GetAppointmentById(id);
            var appointment = await _mediator.Send(new GetAppointmentByIdRequest() { Id = id });

            //adminRepository.CancelAppointment(appointment);
            await _mediator.Send(new CancelAppointmentRequest(appointment));

            return RedirectToAction("ViewAppoinments", "Admin"); // Redirect back to the Index page after cancellation
        }

        [HttpGet]
        public async Task<IActionResult> ViewAppoinments()
        {
            //var appointments = await adminRepository.ViewAppointments();
            var appointments = await _mediator.Send(new GetAllAppoinmentsRequest());

            if (appointments.Count == 0)
            {
                ViewBag.msg = "No appointments have been booked yet";
            }
            return View(appointments);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorUser(DoctorModel doctor)
        {
            //var updatedDoctor = await adminRepository.InviteDoctor(doctor);
            var updatedDoctor = await _mediator.Send(new InviteDoctorRequest(doctor));
            await _mediator.Send(new UpdateDoctorRequest(updatedDoctor));
            //await adminRepository.DoctorUpdate(updatedDoctor);
            //return Ok("Doctor account created and email sent.");
            TempData["SuccessMessage"] = "Account created successfully! A confirmation email has been sent.";

            return RedirectToAction("ViewDoctors", "Admin");
        }

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //}


        // If registration fails, return the form with validation errors
        //return View("ViewDoctors", "Admin");



        //public static async Task<bool> SendEmailAsync(string email, string subject, string message)
        //{
        //    try
        //    {
        //        var smtpClient = new SmtpClient("smtp.gmail.com")  // Gmail SMTP server
        //        {
        //            Port = 587,  // Port 587 is commonly used for TLS
        //            Credentials = new NetworkCredential("hashim104243@gmail.com", "fksm ugfl uugl lcgl"),  // Use App Password if using 2FA
        //            EnableSsl = true,  // Enable SSL for secure connection
        //        };

        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress("hashim104243@gmail.com"),  // Sender's email address
        //            Subject = subject,
        //            Body = message,
        //            IsBodyHtml = false,  // Set to true if you're sending HTML content
        //        };

        //        mailMessage.To.Add(email);  // Add recipient's email address


        //        await smtpClient.SendMailAsync(mailMessage);

        //        return true;// Send the email asynchronously
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log error if sending fails
        //        Console.WriteLine($"Error sending email: {ex.Message}");
        //    }
        //    return false;
        //}
    }
}












//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DoctorUser(DoctorModel Doctor)
//{
//    var doctor = context.Doctors.Find(Doctor.Id);
//    if (doctor != null)
//    {

//        if (ModelState.IsValid)
//        {

//            var user = new IdentityUser
//            {
//                UserName = doctor.Email,  // Email from the InputModel
//                Email = doctor.Email,

//            };
//            var password = "#Password123";

//            var result = await userManager.CreateAsync(user, password);

//            if (result.Succeeded)
//            {

//                // Step 2: Assign the "Doctor" role
//                if (!await roleManager.RoleExistsAsync("Doctor"))
//                {
//                    await roleManager.CreateAsync(new IdentityRole("Doctor"));
//                }

//                await userManager.AddToRoleAsync(user, "Doctor");
//                doctor.UserId = user.Id;
//                await adminRepository.DoctorUpdate(doctor);
//                //context.Doctors.Update(doctor);
//                //context.SaveChanges();


//                var loginUrl = "https://localhost:7251/Identity/Account/login";  // Replace with your actual login URL
//                var message = $"Hello, \n\nYour doctor account has been created. Please use the following details to log in:\n\nEmail: {user.Email}\nPassword: {password}\n\nLogin URL: {loginUrl}";
//                if (user.Email != null) await SendEmailAsync(user.Email, "Your Doctor Account Credentials", message);

//                //return Ok("Doctor account created and email sent.");
//                TempData["SuccessMessage"] = "Account created successfully! A confirmation email has been sent.";
//                return RedirectToAction("Index", "Admin");
//            }

//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError(string.Empty, error.Description);
//            }
//        }
//    }

//    // If registration fails, return the form with validation errors
//    return View("ViewDoctors", "Admin");
//}


//private async Task SendEmailAsync(string email, string subject, string message)
//{
//    var smtpClient = new SmtpClient("smtp.gmail.com")  // Gmail SMTP server
//    {
//        Port = 587,  // Port 587 is commonly used for TLS
//        Credentials = new NetworkCredential("hashim104243@gmail.com", "fksm ugfl uugl lcgl"),  // Use App Password if using 2FA
//        EnableSsl = true,  // Enable SSL for secure connection
//    };

//    var mailMessage = new MailMessage
//    {
//        From = new MailAddress("hashim104243@gmail.com"),  // Sender's email address
//        Subject = subject,
//        Body = message,
//        IsBodyHtml = false,  // Set to true if you're sending HTML content
//    };

//    mailMessage.To.Add(email);  // Add recipient's email address

//    try
//    {
//        await smtpClient.SendMailAsync(mailMessage);  // Send the email asynchronously
//    }
//    catch (Exception ex)
//    {
//        // Log error if sending fails
//        Console.WriteLine($"Error sending email: {ex.Message}");
//    }
//}

//}
//}
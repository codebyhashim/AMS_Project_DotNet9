using System.Net;
using System.Net.Mail;
using AM.ApplicationCore.Features.Admin.Appointments.Queries;
using AM.ApplicationCore.Features.Admin.DashboardCounts;

using AM.ApplicationCore.Features.Admin.Doctors.Queries;
//using AM.ApplicationCore.queries.Admin;
using AM.Data;
using AM.Interfaces;
using AM.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminRepository adminRepository;
        private readonly IMediator _mediator;

        public AdminController(ApplicationDbContext _Context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAdminRepository adminRepository, IMediator _mediator)
        {
            context = _Context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminRepository = adminRepository;
            this._mediator = _mediator;
        }

        //  create button and action method in admin controllers
        // in action method we change logic of true and false

        public async Task<IActionResult> Index()
        {

            //var counts =  adminRepository.Counts();
            var counts= await _mediator.Send(new DashboardCountsQuery());

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
            return View();
        }

        [HttpPost("Doctor/Create")]
        public async Task<IActionResult> Create(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                 //await _adminRepository.CreateDoctor(doctor);
                 await adminRepository.CreateDoctor(doctor);
                //await _mediator.Send(new CreateDoctorCommand(doctor));
                //await _mediator.Send(new CreateDoctorCommand(
                //    doctor.Name,
                //    doctor.Description,
                //    doctor.Email,
                //    doctor.Experience,
                //    doctor.IsActive,
                //    doctor.City,
                //    doctor.AvailabilityDays,
                //    doctor.AvailabilityHours,
                //    doctor.WaitTime,
                //    doctor.Speciality,
                //    doctor.PhoneNumber,
                //    doctor.UserId,

                //    doctor.Degree,
                //    doctor.Address));

                //await context.Doctors.AddAsync(doctor);
                //await context.SaveChangesAsync();
                return RedirectToAction("ViewDoctors", "Admin");
            }
            return View();
        }
        [HttpGet("Doctor/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            //var selectData = await context.Doctors.FindAsync(Id);
            //var doctor = await adminRepository.GetDoctorById(Id);

            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = Id });
            if (doctor == null) NotFound();

            return View(doctor);
        }
        [HttpPost("Doctor/Delete")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {

            //var doctor = await adminRepository.GetDoctorById(Id);
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = Id });

            if (doctor != null)
            {
                await adminRepository.DeleteDoctor(doctor);
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
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id=id});
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
                await adminRepository.DoctorStatusUpdate(doctor);
            }
            return RedirectToAction("ViewDoctors", "Admin");
        }
        [HttpGet("Doctor/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            //var doctor = await adminRepository.GetDoctorById(id);
            var doctor = await _mediator.Send(new GetDoctorByIdRequest() { id = id });

            return View(doctor);
        }
        [HttpPost("Doctor/Edit")]
        public async Task<IActionResult> Edit(DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                await adminRepository.DoctorUpdate(doctorModel);
                TempData["UpdatedMessage"] = "Updated Successfully";                                                       // Step 5: Redirect to the Index page after succ 
            }
            return RedirectToAction("ViewDoctors", "Admin");
        }
        public async Task<IActionResult> Approve(int id)
        {
            //var appointment = context.Appoinments.Find(id);
            //var appointment = await adminRepository.GetAppointmentById(id);
            var appointment = await _mediator.Send(new GetAppointmentByIdRequest { id = id });

            if (appointment != null)
            {
                adminRepository.BookAppointment(appointment);

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
            var appointment = await _mediator.Send(new GetAppointmentByIdRequest() { id = id });

            adminRepository.CancelAppointment(appointment);
            return RedirectToAction("ViewAppoinments", "Admin"); // Redirect back to the Index page after cancellation
        }

        [HttpGet]
        public async Task<IActionResult> ViewAppoinments()
        {   
            //var appointments = await adminRepository.ViewAppointments();
            var appointments = await _mediator.Send(new GetAllAppoinmentsRequest());

            if (appointments.Count == 0)
            {
                ViewBag.msg = "No appointments found";
            }
            return View(appointments);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorUser(DoctorModel Doctor)
        {
            await adminRepository.InviteDoctor(Doctor);
            //await adminRepository.DoctorUpdate(Doctor);
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
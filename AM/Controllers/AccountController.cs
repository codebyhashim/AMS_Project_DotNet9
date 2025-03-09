//using Microsoft.AspNetCore.Identity;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
//using AM.ApplicationCore.Interfaces;

//namespace AM.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly SignInManager<IdentityUser> _signInManager;
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly IEmailService _emailService;

//        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IEmailService emailService)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//            this._emailService = emailService;
//        }

//        // External login callback method
//        [HttpGet]
//        public Task<IActionResult> ExternalLogin(string provider)
//        {
//            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
//            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
//            return Task.FromResult<IActionResult>(Challenge(properties, "Google"));
//        }

//        // External login callback method
//        [HttpGet]
//        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
//        {
//            var info = await _signInManager.GetExternalLoginInfoAsync();
//            if (info == null)
//            {
//                return RedirectToAction(nameof(Login));
//            }

//            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
//            if (result.Succeeded)
//            {
//                return RedirectToLocal(returnUrl);
//            }
//            else
//            {
//                // Handle the case where the user isn't found.
//                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
//                var user = new IdentityUser { UserName = email, Email = email };

//                var createResult = await _userManager.CreateAsync(user);
//                if (createResult.Succeeded)
//                {
//                    // Generate email confirmation token
//                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
//                        new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

//                    // Send the confirmation email
//                    var subject = "Please confirm your email";
//                    var body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>";
//                    var emailSent = await _emailService.SendEmailAsync(user.Email, subject, body);
//                    if (emailSent)
//                    {
//                        // Redirect to a page showing that the confirmation email has been sent
//                        return RedirectToAction("ConfirmEmailSent");
//                    }
//                    else
//                    {
//                        // If sending email fails, add an error
//                        ModelState.AddModelError(string.Empty, "There was an issue sending the confirmation email.");
//                    }



//                    await _userManager.AddLoginAsync(user, info);
//                    await _signInManager.SignInAsync(user, isPersistent: false);
//                    return RedirectToLocal(returnUrl);
//                }
//            }
//            return RedirectToAction(nameof(Login));
//        }



//        // original code
//        private IActionResult RedirectToLocal(string returnUrl)
//        {
//            // Check if the returnUrl is a local URL
//            if (Url.IsLocalUrl(returnUrl))
//            {
//                // If it's a local URL, redirect there
//                return Redirect(returnUrl);
//            }
//            else
//            {
//                // If it's not a local URL, redirect to the "ViewAppointment" action of the "Patient" controller
//                return RedirectToAction("ViewAppoinment", "Patient");
//            }
//        }


//    }

//}














using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using AM.Data;

namespace AM.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IEmailService emailService, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this._emailService = emailService;
            this._context = context;
        }

        // External login callback method (Google, for example)
        [HttpGet]
        public Task<IActionResult> ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Task.FromResult<IActionResult>(Challenge(properties, provider));
        }

        // External login callback method
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded)
            {
                // If the login is successful, redirect to the return URL or the default page.
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // Handle the case where the user isn't found.
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var user = new IdentityUser { UserName = email, Email = email };

                var createResult = await _userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    // 1. Link the Google login to the user.
                    await _userManager.AddLoginAsync(user, info);  // This is important

                    // Optionally: Generate an email confirmation token and send a confirmation email.
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

                    var subject = "Please confirm your email";
                    //var body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>";
                    var body = $"Please confirm your email by clicking the link below: \n\n{confirmationLink}";

                    var emailSent = await _emailService.SendEmailAsync(user.Email, subject, body);

                    if (emailSent)
                    {
                        // Redirect to confirmation email sent page
                        return RedirectToAction("ConfirmEmailSent", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "There was an issue sending the confirmation email.");
                    }

                    // Sign the user in after the creation and linking.
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    // Handle user creation errors (e.g., email already taken).
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }

        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToLocal(returnUrl);
        //    }
        //    else
        //    {
        //        // Handle the case where the user isn't found.
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        var user = new IdentityUser { UserName = email, Email = email };

        //        var createResult = await _userManager.CreateAsync(user);
        //        if (createResult.Succeeded)
        //        {
        //            // 1. Generate email confirmation token
        //            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var confirmationLink = Url.Action("ConfirmEmail", "Account",
        //                new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

        //            // 2. Send the confirmation email
        //            var subject = "Please confirm your email";
        //            var body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>";
        //            var emailSent = await _emailService.SendEmailAsync(user.Email, subject, body);
        //            if (emailSent)
        //            {
        //                // 3. Redirect to a page showing that the confirmation email has been sent
        //                //return RedirectToAction("ConfirmEmailSent", "Account");
        //                return RedirectToAction("ConfirmEmailSent", "Account");

        //            }
        //            else
        //            {
        //                // If sending email fails, add an error
        //                ModelState.AddModelError(string.Empty, "There was an issue sending the confirmation email.");
        //            }

        //            await _userManager.AddLoginAsync(user, info);
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            // Handle errors during user creation (e.g., email already exists, etc.)
        //            foreach (var error in createResult.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }

        //    return RedirectToAction(nameof(Login));
        //}

        // 4. Email confirmation
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Login");

            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Login");

            }

            var result = await _userManager.ConfirmEmailAsync(user, token);



            if (result.Succeeded)
            {
                // Successfully confirmed email
                //return RedirectToAction("Login");
                var userRoll = await _signInManager.UserManager.GetRolesAsync(user);



                //// Assign the "Patient" role if it's not assigned
                if (!userRoll.Contains("Patient"))
                {
                    await _signInManager.UserManager.AddToRoleAsync(user, "Patient");
                }


                if (userRoll.Contains("Admin"))
                {
                    //HttpContext.Session.SetString("role","Admin");
                    return RedirectToAction("Index", "Admin");
                }


                if (userRoll.Contains("Doctor"))
                {
                    //HttpContext.Session.SetString("role", "Doctor");

                    //ViewBag.doctor = "Doctor";
                    return RedirectToAction("Index", "Doctor");  // Replace "DoctorDashboard" with your actual controller and action
                }



                //if (User.IsInRole("Doctor")) {
                //    return RedirectToAction("Index", "DoctorDashboard");



                //} else
                if (User.IsInRole("Patient"))
                {

                    //HttpContext.Session.SetString("role", "Patient");

                    var data = _context.Patients.Where(x => x.UserId == user.Id).Count();

                   
                    if (data > 0)
                    {


                        return RedirectToAction("ViewAppoinment", "Patient");
                    }
                    else
                    {

                        return RedirectToAction("PatientRegister", "Patient");
                    }
                }
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Login");
                //return RedirectToAction("ViewAppoinment", "Patient");
                //return RedirectToAction("ConfirmEmailSuccess");
            }

            // If confirmation fails, you can handle errors here
            return RedirectToAction("Index", "Home");
        }

        // View to show confirmation email sent message
        public IActionResult ConfirmEmailSent()
        {
            return View();
        }

        // Helper method to redirect to the local URL or default page
        private IActionResult RedirectToLocal(string returnUrl)
        {
            // Check if the returnUrl is a local URL
            if (Url.IsLocalUrl(returnUrl))
            {
                // If it's a local URL, redirect there
                return Redirect(returnUrl);
            }
            else
            {
                // If it's not a local URL, redirect to the "ViewAppointment" action of the "Patient" controller
                return RedirectToAction("ViewAppoinment", "Patient");
            }
        }
    }
}


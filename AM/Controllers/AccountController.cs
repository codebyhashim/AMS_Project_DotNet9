using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace AM.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // External login callback method
        [HttpGet]
        public Task<IActionResult> ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Task.FromResult<IActionResult>(Challenge(properties, "Google"));
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
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
            }
            return RedirectToAction(nameof(Login));
        }

        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    //return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToAction(nameof(HomeController.Index), "Home");
        //    return Url.IsLocalUrl(returnUrl) ? RedirectToAction("PatientController", "ViewAppoinment") : RedirectToAction("PatientController", "ViewAppoinment");

        //}

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

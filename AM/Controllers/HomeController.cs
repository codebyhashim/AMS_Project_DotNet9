using System.Diagnostics;
using AM.Data;
using AM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AM.Controllers
{
    //[Authorize(Roles = "Patient")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            context = _context;
        }
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            //var d = context.Doctors.ToList();
            var d = context.Doctors.Where(x=>x.IsActive==true).ToList();

            return View(d);
        }
        
        [HttpGet]
        public IActionResult SearchDoctors(string searchName)
        {
          
                try
                {
                    IEnumerable<DoctorModel> doctors;

                    if (string.IsNullOrEmpty(searchName) )
                    {
                        // Return all doctors if searchName is empty or null
                        doctors = context.Doctors.ToList();
                    }
                    else
                    {
                        // Convert to lowercase to avoid case sensitivity issues
                        doctors = context.Doctors
                                        .Where(d => d.Name.ToLower().Contains(searchName.ToLower()))
                                        .ToList();
                    }

                    // Return the partial view with the updated list of doctors
                    return PartialView("DoctorListPartial", doctors);
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.Error.WriteLine($"Error in SearchDoctors: {ex.Message}");

                    // Return a JSON response with the error details
                    return StatusCode(500, new { error = ex.Message });
                }
            }

        
public IActionResult ViewDetails(int id)
        {
            var doctor = context.Doctors.Find(id);
            //var suggestionDoctor = context.Doctors.Where(x =>int.Parse( x.Experience) > 10).ToList();
            var suggestDtr = context.Doctors.Where(x => x.Speciality == doctor.Speciality && x.Id!=doctor.Id && x.IsActive==true && x.Experience>10).Take(4).ToList();
            ViewBag.suggestDtr = suggestDtr;
            if (doctor == null)
            {
                return NotFound(); // Return a 404 page if no doctor is found
            }
            return View(doctor);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

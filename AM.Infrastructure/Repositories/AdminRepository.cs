using AM.Data;
using AM.Interfaces;
using AM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AM.Interfaces;
using System.Net.Mail;
using System.Net;
using AM.ApplicationCore.Interfaces;
namespace AM.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailService emailService;

        public AdminRepository(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService
            )
        {
            this._context = _context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailService = emailService;
        }
        public async Task<DoctorModel> InviteDoctor(DoctorModel Doctor)
        {
            var doctor = _context.Doctors.Find(Doctor.Id);
            if (doctor != null)
            {



                var user = new IdentityUser
                {
                    UserName = doctor.Email,  // Email from the InputModel
                    Email = doctor.Email,

                };
                var password = "#Password123";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {

                    // Step 2: Assign the "Doctor" role
                    if (!await roleManager.RoleExistsAsync("Doctor"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Doctor"));
                    }

                    await userManager.AddToRoleAsync(user, "Doctor");
                    doctor.UserId = user.Id;

                    _context.Doctors.Update(doctor);
                   _context.SaveChanges();


                    var loginUrl = "https://localhost:7251/Identity/Account/login";  // Replace with your actual login URL
                    var message = $"Hello, \n\nYour doctor account has been created. Please use the following details to log in:\n\nEmail: {user.Email}\nPassword: {password}\n\nLogin URL: {loginUrl}";
                    if (user.Email != null)
                    {
                        await emailService.SendEmail(user.Email, "Your Doctor Account Credentials", message);
                    }

                }
            }
            return doctor;
        }

        public async Task<AppoinmentModel> GetAppointment(int id)
        {
            var appointment = await _context.Appoinments.FindAsync(id);
            return appointment;
        }


        public void BookAppointment(AppoinmentModel appointment)
        {
            appointment.Status = AppoinmentStatus.Booked;
            _context.Appoinments.Update(appointment);
            _context.SaveChanges();

        }



        public void CancelAppointment(AppoinmentModel appointment)
        {
            appointment.Status = AppoinmentStatus.Cancelled;
            _context.Appoinments.Update(appointment);
            _context.SaveChanges();

        }

        public DashbaordCounts Counts()
        {

            var totalRegisterdDoctor = _context.Doctors.Count();
            var totalRegisterdPatients = _context.Patients.Count();
            var totalApprovedAppointments = _context.Appoinments.Count(x => x.Status == AppoinmentStatus.Booked);
            var totalPendingAppointments = _context.Appoinments.Count(x => x.Status == AppoinmentStatus.Pending);
            var totalCanceleAppointments = _context.Appoinments.Count(x => x.Status == AppoinmentStatus.Cancelled);

            var counts = new DashbaordCounts
            {
                TotalRegisterdDoctor = totalRegisterdDoctor,
                TotalRegisterdPatients = totalRegisterdPatients,
                TotalApprovedAppointments = totalApprovedAppointments,
                TotalPendingAppointments = totalPendingAppointments,
                TotalCanceleAppointments = totalCanceleAppointments,
            };

            return counts;

        }

        public async Task<bool> CreateDoctor(DoctorModel doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctor(DoctorModel doctor)
        {
            var user = await userManager.FindByEmailAsync(doctor.Email);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    return false;
                }
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return false;
                //_context.Doctors.Remove(doctor);
                //await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DoctorStatusUpdate(DoctorModel doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DoctorUpdate(DoctorModel doctorModel)
        {
            var doctor = await _context.Doctors.FindAsync(doctorModel.Id);
            if (doctor == null)
            {
                return false; // Return 404 if doctor not found
            }
            var user = await userManager.FindByIdAsync(doctorModel.UserId);
            if (user != null)
            {
                user.Email = doctorModel.Email;
                user.UserName = doctorModel.Email;

                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return false;
                }


            }
            doctor.Email = doctorModel.Email;
            doctor.Name = doctorModel.Name;
            doctor.Speciality = doctorModel.Speciality;
            doctor.AvailabilityDays = doctorModel.AvailabilityDays;
            doctor.Experience = doctorModel.Experience;
            doctor.City = doctorModel.City;
            doctor.IsActive = doctorModel.IsActive;
            doctor.WaitTime = doctorModel.WaitTime;
            doctor.PhoneNumber = doctorModel.PhoneNumber;
            doctor.Degree = doctorModel.Degree;


            //doctor = data;
            _context.Doctors.Update(doctor);
            // Step 4: Save changes to the database (both the doctor and the user)
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<DoctorModel> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return doctor;
        }



        public async Task<List<AppoinmentModel>> ViewAppointments()
        {
            var appointments = await _context.Appoinments.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();

            return appointments;
        }

        public async Task<List<DoctorModel>> ViewDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

       
    
}
}





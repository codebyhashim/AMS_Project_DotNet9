using AM.Data;
using AM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Numerics;
using FluentValidation;
using Azure.Core;
using MediatR;
using AM.ApplicationCore.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace AM.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailService emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AdminRepository(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService, IHttpContextAccessor httpContextAccessor
            )
        {
            this._context = _context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailService = emailService;
            this._httpContextAccessor = httpContextAccessor;

        }
        public async Task<DoctorModel> InviteDoctor(DoctorModel Doctor)
        {



            var doctor = await _context.Doctors.FindAsync(Doctor.Id);
            if (doctor != null)
            {
                //var emailExist = await userManager.FindByEmailAsync(Doctor.Email);
                //if (emailExist != null)
                //{
                //    // Return an error response or handle accordingly if email already exists
                //    // For example, you can throw an exception or return a custom error message.
                //    return null;
                //}


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
                    await _context.SaveChangesAsync();


                    var loginUrl = "https://localhost:7251/Identity/Account/login";  // Replace with your actual login URL
                    var message = $"Hello, \n\nYour doctor account has been created. Please use the following details to log in:\n\nEmail: {user.Email}\nPassword: {password}\n\nLogin URL: {loginUrl}";
                    if (user.Email != null)
                    {
                        await emailService.SendEmailAsync(user.Email, "Your Doctor Account Credentials", message);
                    }

                }
            }
            return doctor;
        }

        public async Task<AppointmentModel> GetAppointmentById(int id)
        {
            var appointment = await _context.Appoinments.FindAsync(id);
            return appointment;
        }


        public async Task<bool> BookAppointment(AppointmentModel appointment)
        {
            appointment.Status = AppoinmentStatus.Booked;
            _context.Appoinments.Update(appointment);
            await _context.SaveChangesAsync();
            return true;

        }



        public async Task<bool> CancelAppointment(AppointmentModel appointment)
        {
            appointment.Status = AppoinmentStatus.Cancelled;
            _context.Appoinments.Update(appointment);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<DashboardCountsModel> Counts()
        {

            var totalRegisterdDoctor = await _context.Doctors.CountAsync();
            var totalRegisterdPatients = await _context.Patients.CountAsync();
            var totalApprovedAppointments = await _context.Appoinments.CountAsync(x => x.Status == AppoinmentStatus.Booked);
            //var totalPendingAppointments = await _context.Appoinments.CountAsync(x => x.Status == AppoinmentStatus.Pending);
            var totalCanceleAppointments = await _context.Appoinments.CountAsync(x => x.Status == AppoinmentStatus.Cancelled);

            var counts = new DashboardCountsModel
            {
                TotalRegisterdDoctor = totalRegisterdDoctor,
                TotalRegisterdPatients = totalRegisterdPatients,
                TotalApprovedAppointments = totalApprovedAppointments,
                //TotalPendingAppointments = totalPendingAppointments,
                TotalCanceleAppointments = totalCanceleAppointments,
            };

            return counts;

        }


        public async Task<bool> DeleteDoctor(DoctorModel doctor)
        {
            //var user = await userManager.FindByEmailAsync(doctor.Email);
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == doctor.UserId);

            //var user = _httpContextAccessor.HttpContext?.User;
            // var user = await userManager.fin

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
            //return true;
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
            //doctor.AvailabilityDays = string.Join(",", AvailabilityDays);

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

        public async Task<DoctorModel> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            return doctor;
        }



        public async Task<List<AppointmentModel>> ViewAppointments()
        {
            var appointments = await _context.Appoinments.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();

            return appointments;
        }

        public async Task<List<DoctorModel>> ViewDoctors()
        {

            //var doctr=await _context.Doctors.ToListAsync();


            var doctors = await _context.Doctors.ToListAsync();

            var doctorModels = new List<DoctorModel>();

            foreach (var item in doctors)
            {
                var slotId = item.AvailabilityTimeSlot.Split(',').Select(int.Parse).ToList();

                var slot = await _context.Slots.Where(x => slotId.Contains(x.Id)).ToListAsync();
                var availabilitySlotString = string.Join(", ", slot.Select(s => $"{s.StartTime:hh:mm tt} - {s.EndTime:hh:mm tt}"));
                var doctor = new DoctorModel
                {
                    Id = item.Id,
                    AvailabilityTimeSlot = availabilitySlotString,
                    Email = item.Email,
                    Name = item.Name,
                    Speciality = item.Speciality,

                    AvailabilityDays = item.AvailabilityDays,
                    //doctor.AvailabilityDays = string.Join(",", AvailabilityDays);


                    Experience = item.Experience,
                    City = item.City,
                    IsActive = item.IsActive,
                    WaitTime = item.WaitTime,
                    PhoneNumber = item.PhoneNumber,
                    Degree = item.Degree,
                    UserId=item.UserId


                };
                doctorModels.Add(doctor);
            }
            return doctorModels;



           
        }


        public async Task<bool> CreateDoctor(DoctorModel doctor, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {


            doctor.AvailabilityDays = string.Join(',', AvailabilityDays);
            doctor.AvailabilityTimeSlot = string.Join(',', AvailabilityTimeSlot);

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> UpdateLockDoctor(DoctorModel doctors, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {


            //var doctor = await _adminRepository.GetDoctorById(request._doctor.Id);

            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctors.Id);

            doctor.Name = doctors.Name;
            doctor.Speciality = doctors.Speciality;
            doctor.Degree = doctors.Degree;
            doctor.City = doctors.City;
            doctor.PhoneNumber = doctors.PhoneNumber;
            doctor.Experience = doctors.Experience;
            doctor.IsActive = doctors.IsActive;
            doctor.Description = doctors.Description;
            doctor.Address = doctors.Address;
            doctor.WaitTime = doctors.WaitTime;
            doctor.Email = doctors.Email;
            doctor.UserId = doctors.UserId;
            //doctor.AvailabilityDays = request._doctor.AvailabilityDays;
            doctor.AvailabilityDays = string.Join(',', AvailabilityDays);

            doctor.AvailabilityTimeSlot = string.Join(',', AvailabilityTimeSlot);
            _context.Doctors.Update(doctor);
            //_context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}





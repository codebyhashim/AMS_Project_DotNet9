using AM.ApplicationCore.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.CreateDoctor
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public CreateDoctorHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            string? uniqueFileName = null;
            if (request._doctor.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + request._doctor.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //request._doctor.ImagePath = uniqueFileName;
                // Ensure the directory exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder); // ✅ Creates the folder if it does not exist
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request._doctor.ImageFile.CopyToAsync(fileStream);
                }
            }

            var doctor = new DoctorModel
            {
                Name = request._doctor.Name,
                Speciality = request._doctor.Speciality,
                Degree = request._doctor.Degree,
                City = request._doctor.City,
                PhoneNumber = request._doctor.PhoneNumber,
                Experience = request._doctor.Experience,
                IsActive = request._doctor.IsActive,
                Description = request._doctor.Description,
                Address = request._doctor.Address,
                WaitTime = request._doctor.WaitTime,
                Email = request._doctor.Email,
                UserId = request._doctor.UserId,
                ImagePath = uniqueFileName,
                AvailabilityDays = request._doctor.AvailabilityDays,
                AvailabilityTimeSlot = request._doctor.AvailabilityTimeSlot
            };
            return await _adminRepository.CreateDoctor(doctor, request.availabilityDays, request.availabilityTimeSlot);
        }
    }


}

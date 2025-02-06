using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateDoctor
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public UpdateDoctorHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _adminRepository.GetDoctorById(request._doctor.Id);

            doctor.Name = request._doctor.Name;
            doctor.Speciality = request._doctor.Speciality;
            doctor.Degree = request._doctor.Degree;
            doctor.City = request._doctor.City;
            doctor.PhoneNumber = request._doctor.PhoneNumber;
            doctor.Experience = request._doctor.Experience;
            doctor.IsActive = request._doctor.IsActive;
            doctor.Description = request._doctor.Description;
            doctor.Address = request._doctor.Address;
            doctor.WaitTime = request._doctor.WaitTime;
            doctor.Email = request._doctor.Email;
            doctor.UserId = request._doctor.UserId;
            doctor.AvailabilityDays = request._doctor.AvailabilityDays;
            doctor.AvailabilityHours = request._doctor.AvailabilityHours;

            return await _adminRepository.DoctorUpdate(doctor);

        }
    }
}

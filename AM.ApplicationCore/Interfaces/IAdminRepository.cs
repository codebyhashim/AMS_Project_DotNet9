using AM.ApplicationCore.Models;
using AM.Models;

namespace AM.ApplicationCore.Interfaces
{
    public interface IAdminRepository
    {
        Task<DashboardCountsModel> Counts();
        Task<List<AppointmentModel>> ViewAppointments();
        Task<List<DoctorModel>> ViewDoctors();
        Task<DoctorModel> GetDoctorById(int id);
        Task<AppointmentModel> GetAppointmentById(int Id);
        //Task<bool> InviteDoctor(DoctorModel Doctor);

        Task<bool> CreateDoctor(DoctorModel doctor, List<string> AvailabilityDays,List<string> AvailabilityTimeSlot);
        Task<bool> DeleteDoctor(DoctorModel doctor);


        Task<bool> DoctorUpdate(DoctorModel doctor);

        Task<bool> UpdateLockDoctor(DoctorModel doctor, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot);

        Task<bool> BookAppointment(AppointmentModel appoinment);
        Task<bool> CancelAppointment(AppointmentModel appoinment);


        Task<bool> DoctorStatusUpdate(DoctorModel doctor);

        Task<DoctorModel> InviteDoctor(DoctorModel doctor);

        //Task<bool> InviteDoctor(DoctorModel doctor);

        //Task<TimeSlotsModel> GetDoctorSlots(DoctorModel doctor);

    }
}


using AM.Models;

namespace AM.Interfaces
{
    public interface IAdminRepository
    {
        Task<DashboardCountsModel> Counts();
        Task<List<AppoinmentModel>> ViewAppointments();
        Task<List<DoctorModel>> ViewDoctors();
        Task<DoctorModel> GetDoctorById(int id);
        Task<AppoinmentModel> GetAppointmentById(int Id);
        //Task<bool> InviteDoctor(DoctorModel Doctor);

        Task<bool> CreateDoctor(DoctorModel doctor);
        Task<bool> DeleteDoctor(DoctorModel doctor);
        Task<bool> DoctorUpdate(DoctorModel doctor);
        void BookAppointment(AppoinmentModel appoinment);
        void CancelAppointment(AppoinmentModel appoinment);


        Task<bool> DoctorStatusUpdate(DoctorModel doctor);

        Task<DoctorModel> InviteDoctor(DoctorModel doctor);
        
    }
}

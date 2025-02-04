using AM.Models;

namespace AM.Interfaces
{
    public interface IAdminRepository
    {
        DashbaordCounts Counts();
        Task<List<DoctorModel>> ViewDoctors();

        Task<bool> CreateDoctor(DoctorModel doctor);

        Task<DoctorModel> GetDoctor(int id);

        Task<List<AppoinmentModel>> ViewAppointments();

        //Task<bool> InviteDoctor(DoctorModel Doctor);

        void BookAppointment(AppoinmentModel appoinment);
        void CancelAppointment(AppoinmentModel appoinment);
        Task<AppoinmentModel> GetAppointment(int Id);
        Task<bool> DeleteDoctor(DoctorModel doctor);

        Task<bool> DoctorUpdate(DoctorModel doctor);

        Task<bool> DoctorStatusUpdate(DoctorModel doctor);

        Task<DoctorModel> InviteDoctor(DoctorModel doctor);

        







    }
}

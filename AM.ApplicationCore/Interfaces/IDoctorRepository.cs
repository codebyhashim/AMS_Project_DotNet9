using AM.Models;

namespace AM.Interfaces
{
    public interface IDoctorRepository
    {
        Task<DoctorModel> GetDoctor(string Id);

        Task<List<AppointmentModel>> GetDoctorAppoinments(int id);
        Task<AppointmentModel> GetAppointment(int Id);
        Task<bool> BookAppointment(AppointmentModel appoinment);
        Task<bool> CanceleAppointment(AppointmentModel appoinment);

    }
}

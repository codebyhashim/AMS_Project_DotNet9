using AM.Models;

namespace AM.Interfaces
{
    public interface IDoctorRepository
    {
        Task<DoctorModel> GetDoctor(string Id);

        Task<List<AppoinmentModel>> GetDoctorAppoinments(int id);
        Task<AppoinmentModel> GetAppointment(int Id);
        Task<bool> BookAppointment(AppoinmentModel appoinment);
        Task<bool> CanceleAppointment(AppoinmentModel appoinment);

    }
}

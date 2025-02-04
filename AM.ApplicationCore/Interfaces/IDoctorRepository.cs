using AM.Models;

namespace AM.Interfaces
{
    public interface IDoctorRepository
    {
        Task<DoctorModel> GetDoctor(string Id);

        Task<List<AppoinmentModel>> GetDoctorAppoinments(int id);
        Task<AppoinmentModel> GetAppointment(int Id);
        void BookAppointment(AppoinmentModel appoinment);
        void CanceleAppointment(AppoinmentModel appoinment);

    }
}

using AM.Models;

namespace AM.Interfaces
{
    public interface IPatientRepository
    {
        string GetLoginPatient();
        void RegisterPatient(PatientModel patient);

        Task<PatientModel> UpdatePatient(PatientModel patient);
        Task<PatientModel> GetPatient(string id);
        Task<List<DoctorModel>> GetActiveDoctors();

        Task<AppoinmentModel> ShowAppointmetForm(PatientModel patient);

        Task GetAppoinments(AppoinmentModel appointments);

        Task<List<AppoinmentModel>> ViewAppoinments(PatientModel patient);


        //DoctorModel GetActiveDoctor();

    }
}

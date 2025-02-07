using AM.Models;

namespace AM.Interfaces
{
    public interface IPatientRepository
    {
        string GetLoginPatient();
        Task<bool> RegisterPatient(PatientModel patient);

        //Task<PatientModel> UpdatePatient(PatientModel patient);
        Task<bool> UpdatePatient(PatientModel patient);

        Task<PatientModel> GetPatient(string id);
        Task<List<DoctorModel>> GetActiveDoctors();

        Task<AppointmentModel> ShowAppointmetForm(PatientModel patient);

        Task<bool> GetAppointments(AppointmentModel appointments);

        Task<List<AppointmentModel>> ViewAppoinments(PatientModel patient);


        //DoctorModel GetActiveDoctor();

    }
}

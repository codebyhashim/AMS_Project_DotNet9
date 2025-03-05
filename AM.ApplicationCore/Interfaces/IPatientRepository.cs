using System.Text.Json.Nodes;
using AM.ApplicationCore.Models;
using AM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        Task<List<string>> GetDays(int doctorId);

        Task<List<SelectListItem>>  DisplaySlots(int doctorId, string date);

        Task<List<TimeSlotsModel>> GetAllSlots();
        //DoctorModel GetActiveDoctor();

    }
}

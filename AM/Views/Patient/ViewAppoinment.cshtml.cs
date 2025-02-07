using AM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Views.Patient
{
    public class ViewAppoinmentsRequest : PageModel
    {
        private PatientModel patient;

        public ViewAppoinmentsRequest(PatientModel patient)
        {
            this.patient = patient;
        }

        public void OnGet()
        {
        }
    }
}

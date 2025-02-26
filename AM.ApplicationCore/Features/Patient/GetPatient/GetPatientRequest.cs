using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetPateint
{
    public class GetPatientRequest : IRequest<PatientModel>
    {

        public string Id { get; set; }
    }
}

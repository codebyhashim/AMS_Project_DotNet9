using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetPateint
{
    public class GetPatientRequest : IRequest<PatientModel>
    {
        
        public string Id { get; set; }
    }
}

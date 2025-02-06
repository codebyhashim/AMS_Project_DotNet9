using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctor
{
    public class GetDoctorRequest : IRequest<DoctorModel>
    {
        public string Id { get; set; }
    }
}

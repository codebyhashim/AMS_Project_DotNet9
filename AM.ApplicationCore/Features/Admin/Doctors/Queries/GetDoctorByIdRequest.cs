using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.Doctors.Queries
{
    public class GetDoctorByIdRequest : IRequest<DoctorModel>
    {
        public int id;

      
    }
}

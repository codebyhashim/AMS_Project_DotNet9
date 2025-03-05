using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetAllSlots
{
    public class GetAllSlotsRequest :  IRequest<List<TimeSlotsModel>>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetLoginUserId
{
    public class GetLoginUserIdRequest : IRequest<string>
    {
    }
}

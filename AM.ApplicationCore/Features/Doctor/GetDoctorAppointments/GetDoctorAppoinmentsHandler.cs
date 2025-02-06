using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctorAppointments
{
    public class GetDoctorAppoinmentsHandler : IRequestHandler<GetDoctorAppoinmentsRequest, List<AppoinmentModel>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorAppoinmentsHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        //public async Task<AppoinmentModel> Handle(GetDoctorAppoinmentsRequest request, CancellationToken cancellationToken)
        //{
        //    return await _doctorRepository.GetAppointment(request.Id);
        //}

        async Task<List<AppoinmentModel>> IRequestHandler<GetDoctorAppoinmentsRequest, List<AppoinmentModel>>.Handle(GetDoctorAppoinmentsRequest request, CancellationToken cancellationToken)
        {
            var appointment= await _doctorRepository.GetDoctorAppoinments(request.Id);
            return appointment;
        }
    }
}

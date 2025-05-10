using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;

namespace CompanyModule.Application.Handlers
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AddAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<Appointment> Handle(AddAppointmentCommand command, CancellationToken cancellationToken)
        {
            Appointment appointment = _mapper.Map<Appointment>(command.createRequest);

            await _appointmentRepository.AddAsync(appointment);

            return appointment;
        }
    }
}

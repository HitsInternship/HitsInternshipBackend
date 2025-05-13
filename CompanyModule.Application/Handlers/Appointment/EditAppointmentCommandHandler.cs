using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;

namespace CompanyModule.Application.Handlers
{
    public class EditAppointmentCommandHandler : IRequestHandler<EditAppointmentCommand, Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public EditAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<Appointment> Handle(EditAppointmentCommand command, CancellationToken cancellationToken)
        {
            Appointment appointment = await _appointmentRepository.GetByIdAsync(command.appointmentId);

            _mapper.Map(command.editRequest, appointment);

            await _appointmentRepository.UpdateAsync(appointment);

            return appointment;
        }
    }
}

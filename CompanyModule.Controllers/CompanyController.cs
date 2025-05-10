using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Domain.Entities;
using CompanyModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CompanyModule.Contracts.CQRS.Queries;

namespace CompanyModule.Controllers
{
    [ApiController]
    [Route("api/companies/")]
    public class CompanyController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public CompanyController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все компании-партнеры.
        /// </summary>
        /// <returns>Список компаний партнеров.</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<CompanyResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok((await _sender.Send(new GetCompaniesQuery())).Select(_mapper.Map<CompanyResponse>));
        }

        /// <summary>
        /// Добавляет компанию-партнера.
        /// </summary>
        /// <returns>Добавленная компания.</returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCompany(CompanyRequest createRequest)
        {
            return Ok(_mapper.Map<CompanyResponse>(await _sender.Send(new AddCompanyCommand(createRequest))));
        }

        /// <summary>
        /// Изменяет информацию о компании-партнере.
        /// </summary>
        [HttpPut]
        [Route("{companyId}")]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditCompany(Guid companyId, EditCompanyRequest editRequest)
        {
            return Ok(_mapper.Map<CompanyResponse>(await _sender.Send(new EditCompanyCommand(companyId, editRequest))));
        }

        /// <summary>
        /// Добавляет документ о партнерстве с компанией.
        /// </summary>
        /// <returns>Добавленный документ.</returns>
        [HttpPost]
        [Route("{companyId}/agreements/add")]
        [ProducesResponseType(typeof(PartnershipAgreementResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPartnershipAgreement(Guid companyId, [FromForm] PartnershipAgreementRequest createRequest)
        {
            return Ok(_mapper.Map<PartnershipAgreementResponse>(await _sender.Send(new AddPartnershipAgreementCommand(companyId, createRequest))));
        }

        /// <summary>
        /// Изменяет статус компании-партнера.
        /// </summary>
        [HttpPut]
        [Route("{companyId}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeCompanyStatus(Guid companyId, CompanyStatus companyStatus)
        {
            await _sender.Send(new ChangeCompanyStatusCommand(companyId, companyStatus));

            return Ok();
        }

        /// <summary>
        /// Добавить человека от компании.
        /// </summary>
        /// <returns>Добавленный человек от компании.</returns>
        [HttpPost]
        [Route("{companyId}/persons/add")]
        [ProducesResponseType(typeof(CompanyPersonResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCompanyPerson(Guid companyId, CompanyPersonRequest createRequest)
        {
            return Ok(_mapper.Map<CompanyPersonResponse>(await _sender.Send(new AddCompanyPersonCommand(companyId, createRequest))));
        }

        /// <summary>
        /// Получить список людей от компаний (CompanyPerson).
        /// </summary>
        /// <returns>Список людей от компании.</returns>
        [HttpGet]
        [Route("{companyId}/persons")]
        [ProducesResponseType(typeof(List<CompanyPersonResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanyPersons(Guid companyId, bool includeCurators, bool includeRepresenters)
        {
            return Ok((await _sender.Send(new GetCompanyPersonsQuery(companyId, includeCurators, includeRepresenters))).Select(companyPerson => _mapper.Map<CompanyPersonResponse>(companyPerson)).ToList());
        }

        /// <summary>
        /// Добавить встречу с компанией.
        /// </summary>
        /// <returns>Встреча с компанией.</returns>
        [HttpPost]
        [Route("{companyId}/appointments/add")]
        [ProducesResponseType(typeof(AppointmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAppointment(Guid companyId, AppointmentRequest createRequest)
        {
            return Ok(_mapper.Map<AppointmentResponse>(await _sender.Send(new AddAppointmentCommand(companyId, createRequest))));
        }

        ///// <summary>
        ///// Изменить встречу с компанией.
        ///// </summary>
        ///// <returns>Встреча с компанией.</returns>
        //[HttpPost]
        //[Route("appointments/{appointmentId}")]
        //[ProducesResponseType(typeof(AppointmentResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> EditAppointment(Guid appointmentId, AppointmentRequest editRequest)
        //{
        //    return Ok(_mapper.Map<AppointmentResponse>(await _sender.Send(new EditAppointmentCommand(appointmentId, editRequest))));
        //}
    }
}

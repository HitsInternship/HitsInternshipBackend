using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Domain.Entities;
using CompanyModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
        /// Добавляет документ о партнерстве с компанией.
        /// </summary>
        /// <returns>Добавленный документ.</returns>
        [HttpPut]
        [Route("{id}/agreements/add")]
        [ProducesResponseType(typeof(PartnershipAgreementResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPartnershipAgreement(Guid companyId, PartnershipAgreementRequest createRequest)
        {
            return Ok(_mapper.Map<PartnershipAgreementResponse>(await _sender.Send(new AddPartnershipAgreementCommand(companyId, createRequest))));
        }

        /// <summary>
        /// Изменяет статус компании-партнера.
        /// </summary>
        /// <returns>Добавленная компания.</returns>
        [HttpPut]
        [Route("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeCompanyStatus(Guid id, CompanyStatus companyStatus)
        {
            return Ok(await _sender.Send(new ChangeCompanyStatusCommand(id, companyStatus)));
        }
    }
}

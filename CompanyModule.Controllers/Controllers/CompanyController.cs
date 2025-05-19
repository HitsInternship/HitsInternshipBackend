﻿using System.Web.Mvc;
using AutoMapper;
using CompanyModule.Contracts.Commands;
using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Contracts.Queries;
using CompanyModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace CompanyModule.Controllers.Controllers
{
    [Authorize]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/companies/")]
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
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("")]
        [ProducesResponseType(typeof(List<CompanyResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok((await _sender.Send(new GetCompaniesQuery())).Select(_mapper.Map<CompanyResponse>));
        }

        /// <summary>
        /// Добавляет компанию-партнера.
        /// </summary>
        /// <returns>Добавленная компания.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("add")]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCompany(CompanyRequest createRequest)
        {
            return Ok(_mapper.Map<CompanyResponse>(await _sender.Send(new AddCompanyCommand(createRequest))));
        }

        /// <summary>
        /// Изменяет информацию о компании-партнере.
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}")]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditCompany(Guid companyId, EditCompanyRequest editRequest)
        {
            return Ok(_mapper.Map<CompanyResponse>(await _sender.Send(new EditCompanyCommand(companyId, editRequest))));
        }

        /// <summary>
        /// Добавляет документ о партнерстве с компанией.
        /// </summary>
        /// <returns>Добавленный документ.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}/agreements/add")]
        [ProducesResponseType(typeof(PartnershipAgreementResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPartnershipAgreement(Guid companyId,
            [FromForm] PartnershipAgreementRequest createRequest)
        {
            return Ok(_mapper.Map<PartnershipAgreementResponse>(
                await _sender.Send(new AddPartnershipAgreementCommand(companyId, createRequest))));
        }

        /// <summary>
        /// Позволяет получить документы о партнерстве c компанией.
        /// </summary>
        /// <returns>Документ о партнерстве.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}/agreements")]
        [ProducesResponseType(typeof(List<PartnershipAgreementResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPartnershipAgreements(Guid companyId)
        {
            return Ok((await _sender.Send(new GetPartnershipAgreementsQuery(companyId))).Select(
                _mapper.Map<PartnershipAgreementResponse>));
        }

        /// <summary>
        /// Изменяет статус компании-партнера.
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeCompanyStatus(Guid companyId, CompanyStatus companyStatus)
        {
            await _sender.Send(new ChangeCompanyStatusCommand(companyId, companyStatus));

            return Ok();
        }

        /// <summary>
        /// Добавить человека от компании.
        /// </summary>
        /// <param name="createRequest.userId">Если необходимо создать человека от компании на основе уже существующего пользователя.</param>
        /// <returns>Добавленный человек от компании.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}/persons/add")]
        [ProducesResponseType(typeof(CompanyPersonResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCompanyPerson(Guid companyId, CompanyPersonRequest createRequest)
        {
            return Ok(_mapper.Map<CompanyPersonResponse>(
                await _sender.Send(new AddCompanyPersonCommand(companyId, createRequest))));
        }

        /// <summary>
        /// Получить список людей от компаний (CompanyPerson).
        /// </summary>
        /// <returns>Список людей от компании.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{companyId}/persons")]
        [ProducesResponseType(typeof(List<CompanyPersonResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanyPersons(Guid companyId, bool includeCurators,
            bool includeRepresenters)
        {
            return Ok((await _sender.Send(new GetCompanyPersonsQuery(companyId, includeCurators, includeRepresenters)))
                .Select(_mapper.Map<CompanyPersonResponse>));
        }
    }
}
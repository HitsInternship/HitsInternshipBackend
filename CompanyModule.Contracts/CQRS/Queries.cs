using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModule.Contracts.CQRS
{
    public class Queries
    {
        public record GetCompanyPersonsQuery(Guid companyId, bool includeCurators, bool includeRepresenters) : IRequest<List<CompanyPerson>>;
        public record GetCompaniesQuery() : IRequest<List<Company>>;
    }
}

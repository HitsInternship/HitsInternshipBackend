using CompanyModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModule.Contracts.DTOs.Responses
{
    public class PartnershipAgreementResponse
    {
        public string description { get; set; }
        public Guid documentId { get; set; }

        public PartnershipAgreementResponse() {}
    }
}

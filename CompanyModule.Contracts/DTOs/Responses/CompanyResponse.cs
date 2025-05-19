using CompanyModule.Domain.Entities;
using CompanyModule.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModule.Contracts.DTOs.Responses
{
    public class CompanyResponse
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public CompanyStatus status { get; set; }

        public CompanyResponse() {}
    }
}

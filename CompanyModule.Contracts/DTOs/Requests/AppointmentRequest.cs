using CompanyModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModule.Contracts.DTOs.Requests
{
    public class AppointmentRequest
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public AppointmentRequest() {}
    }
}

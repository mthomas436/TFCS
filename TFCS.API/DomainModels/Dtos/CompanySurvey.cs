using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.DomainModels.Dtos
{
    public class CompanySurvey
    {
        public Company company { get; set; }
        public Survey survey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.DomainModels.Dtos
{
    public class MenuItemsDto
    {
        public ICollection<Company> Companies { get; set; }
        public ICollection<SurveyType> StandardSurveyTypes { get; set; }
        public ICollection<StandardMenuItem> StandardMenuItems { get; set; }
    }
}

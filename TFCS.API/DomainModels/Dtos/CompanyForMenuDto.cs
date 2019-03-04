using System.Collections.Generic;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.DomainModels.Dtos
{
    public class CompanyForMenuDto
    {

        public CompanyForMenuDto()
        {
            Surveys = new HashSet<Survey>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

    }
}
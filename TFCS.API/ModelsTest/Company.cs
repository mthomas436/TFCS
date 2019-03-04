using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class Company
    {
        public Company()
        {
            Survey = new HashSet<Survey>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoImagePath { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Survey> Survey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFCS.API.DomainModels.Entities
{
    public class CompanyEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }

        //Any other Id that needs to be added
        public int Id { get; set; }

        //public virtual Company Company { get; set; }
        //public virtual User User { get; set; }
    }
}

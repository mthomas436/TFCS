using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFCS.API.DomainModels.Entities
{
    public class StandardMenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public string Name { get; set; }
    }
}

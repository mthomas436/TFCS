using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyMenuItem
    {
        [Key]
        public int ItemId { get; set; }
        public int MenuItemId { get; set; }
        public int SurveyId { get; set; }
        public string Name { get; set; }

        public virtual StandardMenuItem StandardMenuItems { get; set; }
    }
}

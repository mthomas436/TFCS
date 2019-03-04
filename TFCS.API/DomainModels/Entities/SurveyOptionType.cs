using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyOptionType
    {
        public SurveyOptionType()
        {
           // SurveyOptions = new HashSet<SurveyOption>();
        }
        [Key]
        public int OptionTypeId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string Description { get; set; }

        //public virtual ICollection<SurveyOption> SurveyOption { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyType
    {
        public SurveyType()
        {
           // Surveys = new HashSet<Survey>();
        }
        [Key]
        public int SurveyTypeId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string Description { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyResponse
    {
        [Key]
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]        
        public string SavedValue { get; set; }
        public int OptionId { get; set; }
        public DateTime DateEntered { get; set; }

        public virtual SurveyOption SurveyOption { get; set; }
        public virtual Survey Survey { get; set; }
    }
}

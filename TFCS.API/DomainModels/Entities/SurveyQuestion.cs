using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyQuestion
    {
        public SurveyQuestion()
        {
            // SurveyOptions = new HashSet<SurveyOption>();
        }
        [Key]
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]        
        public string QuestionName { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]        
        public string ShortQuestionName { get; set; }
        public int QuestionOrder { get; set; }

        [Column(TypeName = "VARCHAR(25)")]
        [StringLength(25)]    
        public string QuestionType { get; set; }

        public int SurveyTypeId { get; set; }

        public bool Required { get; set; }
        
        public virtual ICollection<SurveyOption> SurveyOptions { get; set; }
        public virtual Survey Survey { get; set; }
    }
}

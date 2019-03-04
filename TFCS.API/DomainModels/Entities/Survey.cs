using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class Survey
    {
        public Survey()
        {
            //SurveyQuestions = new HashSet<SurveyQuestion>();
            //SurveyResponses = new HashSet<SurveyResponse>();
        }
        [Key]
        public int SurveyId { get; set; }
        public int CompanyId { get; set; }
        public bool? Active { get; set; }
        public int SurveyTypeId { get; set; }

        [Column(TypeName = "VARCHAR(1000)")]
        [StringLength(1000)]             
        public string SurveyIntro { get; set; }

        [Column(TypeName = "VARCHAR(1000)")]
        [StringLength(1000)]           
        public string SurveyFooterText { get; set; }

        public virtual Company Company { get; set; }
        public virtual SurveyType SurveyTypes { get; set; }
        public virtual ICollection<SurveyMenuItem> SurveyMenuItems { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponse { get; set; }

    }
}

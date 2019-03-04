using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class Survey
    {
        public Survey()
        {
            SurveyQuestion = new HashSet<SurveyQuestion>();
            SurveyResponse = new HashSet<SurveyResponse>();
        }

        public int SurveyId { get; set; }
        public int CompanyId { get; set; }
        public bool? Active { get; set; }
        public int SurveyTypeId { get; set; }
        public string SurveyIntro { get; set; }
        public string SurveyFooterText { get; set; }

        public virtual Company Company { get; set; }
        public virtual SurveyType SurveyType { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponse { get; set; }
    }
}

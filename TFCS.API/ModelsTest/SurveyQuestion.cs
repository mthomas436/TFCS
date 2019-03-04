using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            SurveyOption = new HashSet<SurveyOption>();
        }

        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionName { get; set; }
        public string ShortQuestionName { get; set; }
        public int? QuestionOrder { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<SurveyOption> SurveyOption { get; set; }
    }
}

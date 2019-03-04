using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class SurveyOption
    {
        public SurveyOption()
        {
            SurveyResponse = new HashSet<SurveyResponse>();
        }

        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public int OptionTypeId { get; set; }
        public int OptionOrder { get; set; }
        public int QuestionId { get; set; }

        public virtual SurveyOptionType OptionType { get; set; }
        public virtual SurveyQuestion Question { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponse { get; set; }
    }
}

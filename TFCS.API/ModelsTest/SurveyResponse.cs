using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class SurveyResponse
    {
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }
        public int OptionId { get; set; }
        public byte[] SavedValue { get; set; }
        public DateTime DateEntered { get; set; }

        public virtual SurveyOption Option { get; set; }
        public virtual Survey Survey { get; set; }
    }
}

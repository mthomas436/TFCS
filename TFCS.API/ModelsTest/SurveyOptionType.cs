using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class SurveyOptionType
    {
        public SurveyOptionType()
        {
            SurveyOption = new HashSet<SurveyOption>();
        }

        public int OptionTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SurveyOption> SurveyOption { get; set; }
    }
}

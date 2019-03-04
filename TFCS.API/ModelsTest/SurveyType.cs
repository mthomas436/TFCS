using System;
using System.Collections.Generic;

namespace TFCS.API.ModelsTest
{
    public partial class SurveyType
    {
        public SurveyType()
        {
            Survey = new HashSet<Survey>();
        }

        public int SurveyTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Survey> Survey { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public partial class SurveyOption
    {
        public SurveyOption()
        {
            //SurveyResponses = new HashSet<SurveyResponse>();
        }


        [Key]
        public int OptionId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]   
        public string OptionName { get; set; }

        public int OptionTypeId { get; set; }
        public int OptionOrder { get; set; }
        public int QuestionId { get; set; }
        public int? OptionGroup { get; set; }

        public virtual SurveyOptionType SurveyOptionType { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponse { get; set; }



 
    }
}

using System.ComponentModel.DataAnnotations;

namespace TFCS.API.DomainModels.Entities
{
    public class SurveyResponseHeader
    {
        [Key]
        public int SurveyId { get; set; }
        public int CompanyId { get; set; }
        public int Week { get; set; }
        public string RO  { get; set; }

         
    }
}
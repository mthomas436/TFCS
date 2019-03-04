using System.ComponentModel.DataAnnotations;

namespace TFCS.API.DomainModels.Entities
{
    public class CompanySurveyCatItem
    {
        [Key]
        public int SurveyCatId { get; set; }
        public int SurveyId { get; set; }

    }
}
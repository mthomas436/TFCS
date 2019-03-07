using System.ComponentModel.DataAnnotations;

namespace TFCS.API.DomainModels.Dtos
{
    public class QuestionForInsertDto
    {

        public int SurveyId { get; set; }

        [StringLength(500)]        
        public string QuestionName { get; set; }

        public int QuestionOrder { get; set; }

        [StringLength(25)]    
        public string QuestionType { get; set; }

        public bool Required { get; set; }       
    
    }
}
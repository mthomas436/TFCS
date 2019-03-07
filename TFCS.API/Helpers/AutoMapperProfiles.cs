using AutoMapper;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForEditDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
                //.ForMember(dest => dest.pas, opt => opt.Ignore());


            CreateMap<UserForRegisterDto, User>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())                 
                 .ForMember(dest => dest.Active, opt => opt.Ignore());

            CreateMap<CompanyForMenuDto, Company>()
                .ForMember(dest => dest.Active, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore()); 
               // .ForMember(dest =>  dest.Employees, opt => opt.Ignore())
                //.ForMember(dest => dest.Vehicles, opt => opt.Ignore());

            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<QuestionForUpdateDto, SurveyQuestion>()
                .ForMember(dest => dest.ShortQuestionName, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyTypeId, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyOptions, opt => opt.Ignore())
                .ForMember(dest => dest.Survey, opt => opt.Ignore());

            CreateMap<QuestionForInsertDto, SurveyQuestion>()
                .ForMember(dest => dest.ShortQuestionName, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyTypeId, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyOptions, opt => opt.Ignore())
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore())
                .ForMember(dest => dest.Survey, opt => opt.Ignore());                

        }


    }
}

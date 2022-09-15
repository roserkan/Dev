using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.JWT;
using Devs.Application.Dtos.Developers;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Dtos.SocialProfiles;
using Devs.Application.Dtos.Technologies;
using Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Devs.Application.Features.ProgrammingLanguages.Commands.Update;
using Devs.Application.Features.SocialProfiles.Commands.Create;
using Devs.Application.Features.SocialProfiles.Commands.Delete;
using Devs.Application.Features.SocialProfiles.Commands.Update;
using Devs.Application.Features.Technologies.Commands.Create;
using Devs.Application.Features.Technologies.Commands.Delete;
using Devs.Application.Features.Technologies.Commands.Update;
using Devs.Application.Models;
using Devs.Domain.Entities;

namespace Devs.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //ProgrammingLanguages
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();


        //Technologies
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        CreateMap<Technology, TechnologyDto>()
            .ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(t => t.ProgrammingLanguage.Name))
            .ReverseMap();
        CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
        CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
        CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
        CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
        CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
        CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();


        //SocialProfiles
        CreateMap<IPaginate<SocialProfile>, SocialProfileListModel>().ReverseMap();
        CreateMap<SocialProfile, SocialProfileDto>().ReverseMap();
        CreateMap<SocialProfile, CreateSocialProfileCommand>().ReverseMap();
        CreateMap<SocialProfile, CreatedSocialProfileDto>().ReverseMap();
        CreateMap<SocialProfile, UpdateSocialProfileCommand>().ReverseMap();
        CreateMap<SocialProfile, UpdatedSocialProfileDto>().ReverseMap();
        CreateMap<SocialProfile, DeleteSocialProfileCommand>().ReverseMap();
        CreateMap<SocialProfile, DeletedSocialProfileDto>().ReverseMap();


        //Developer-Auth
        CreateMap<Developer, RegisterUserCommand>().ReverseMap();
        CreateMap<TokenDto, AccessToken>().ReverseMap();




    }
}
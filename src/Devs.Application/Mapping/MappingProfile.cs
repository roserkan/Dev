using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Devs.Application.Features.ProgrammingLanguages.Commands.Update;
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

    }
}
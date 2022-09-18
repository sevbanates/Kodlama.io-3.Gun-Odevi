using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Dtos;
using Domain.Entities;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetListLanguage;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();

            CreateMap<Language, DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();

            CreateMap<Language, GetByIdLanguageDto>().ReverseMap();

            CreateMap<Language, GetListLanguageDto>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();


        }
    }
}

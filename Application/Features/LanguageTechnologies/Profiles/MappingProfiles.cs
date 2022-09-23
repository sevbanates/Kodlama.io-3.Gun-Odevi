using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTech;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
     

            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
        }
    }
}

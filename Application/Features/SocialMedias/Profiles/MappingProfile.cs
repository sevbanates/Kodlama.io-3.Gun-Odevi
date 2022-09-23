using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Queries.GetByIdQuey;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
    

            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, GetByIdSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaQuery>().ReverseMap();

            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand : IRequest<CreatedSocialMediaDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public string SocialMediaName { get; set; }
        //public string[] Roles { get; } = { "User" };

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;


            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaBusinessRules.SocialMediaNameCanNotBeDuplicated(request.UserId, request.SocialMediaName);

                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia createdSocialMedia = await _socialMediaRepository.AddAsync(mappedSocialMedia);
                CreatedSocialMediaDto mappedCreatedSocialMediaDto =
                    _mapper.Map<CreatedSocialMediaDto>(createdSocialMedia);

                return mappedCreatedSocialMediaDto;

            }
        }
    }
}

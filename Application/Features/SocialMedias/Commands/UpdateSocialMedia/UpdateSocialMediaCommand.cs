using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string Url { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                var updatedSocialMedia = await _socialMediaRepository.UpdateAsync(mappedSocialMedia);
                var mappedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(updatedSocialMedia);

                return mappedSocialMediaDto;
            }
        }
    }
}

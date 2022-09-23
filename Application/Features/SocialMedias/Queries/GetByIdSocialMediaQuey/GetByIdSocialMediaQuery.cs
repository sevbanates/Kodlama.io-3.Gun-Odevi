using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SocialMedias.Queries.GetByIdQuey
{
    public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetByIdSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, IUserRepository userRepository)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<GetByIdSocialMediaDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var socialMedia = await _socialMediaRepository.GetAsync(s => s.Id == request.Id && s.UserId == request.UserId);
                var relatedUser = await _userRepository.GetAsync(u => u.Id == request.UserId);
                var mappedSocialMedia = _mapper.Map<GetByIdSocialMediaDto>(socialMedia);
                mappedSocialMedia.UserName = relatedUser.FirstName + " " + relatedUser.LastName;
                return mappedSocialMedia;


            }
        }
    }
}

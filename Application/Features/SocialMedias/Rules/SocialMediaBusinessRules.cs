using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IUserRepository _userRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository, IUserRepository userRepository)
        {
            _socialMediaRepository = socialMediaRepository;
            _userRepository = userRepository;
        }

        public async Task SocialMediaNameCanNotBeDuplicated(int userId, string name)
        {

           

            IPaginate<SocialMedia> searchSocialMedia = await _socialMediaRepository.GetListAsync(u=>u.UserId == userId && u.SocialMediaName == name, include:s=>s.Include(p=>p.User));

            if (searchSocialMedia.Items.Any()) throw new BusinessException("Inserted name is already exist!");
        }
    }
}

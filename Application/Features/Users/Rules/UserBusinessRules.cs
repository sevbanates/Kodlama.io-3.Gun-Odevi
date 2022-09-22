using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetAsync(u => u.Email == email);
            if (result is not null) throw new BusinessException("Email address already exists");
        }

        public async Task CheckIfUserExists(string email)
        {
            var result = await _userRepository.GetAsync(u => u.Email == email);
            if (result is null) throw new BusinessException("Email address could not be found");
        }

        public async Task CheckIfThePasswordIsCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordHash))
                throw new BusinessException("Please make sure you entered password correctly");
        }
    }
}

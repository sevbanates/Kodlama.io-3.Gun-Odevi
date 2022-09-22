using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<AccessToken>
    {

        public string? Email { get; set; }
        public string? Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserBusinessRules _userBusinessRules;


            public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<AccessToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.Email);
                await _userBusinessRules.CheckIfUserExists(user.Email);
                //await _userBusinessRules.CheckIfThePasswordIsCorrect(request.Password, user.PasswordHash,
                   // user.PasswordSalt);

                var userClaims = await _userOperationClaimRepository.GetListAsync(uc => uc.UserId == user.Id,
                    include: u => u.Include(c => c.OperationClaim),
                    cancellationToken: cancellationToken);

                var token = _tokenHelper.CreateToken(user, userClaims.Items.Select(p => p.OperationClaim).ToList());

                return token;
            }
        }
    }
}

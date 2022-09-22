using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.CreateUser
{

    public class RegisterUserCommand : UserForRegisterDto, IRequest<AccessToken>
    {
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserBusinessRules _userBusinessRules;


            public RegisterUserCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _operationClaimRepository = operationClaimRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<AccessToken> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Status = true,
                    AuthenticatorType = AuthenticatorType.Email
                };

                OperationClaim? claim = await _operationClaimRepository.GetAsync(p => p.Name == "User");

                User newUser = await _userRepository.AddAsync(user);

                UserOperationClaim userOperationClaim = new UserOperationClaim
                {
                    UserId = newUser.Id,
                    OperationClaimId = claim.Id,
                    

                };

                await _userOperationClaimRepository.AddAsync(userOperationClaim);

                var userClaims = await _userOperationClaimRepository.GetListAsync(
                    p => p.UserId == newUser.Id,
                    include: p => p.Include(c => c.OperationClaim),
                    cancellationToken: cancellationToken);

                var token = _tokenHelper.CreateToken(newUser, userClaims.Items.Select(p => p.OperationClaim).ToList());
                return token;
                


            }
        }

    }
}

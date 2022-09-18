using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<GetByIdLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.CheckIfLanguageExistOrNot(request.Id);

                Language searchLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);
                GetByIdLanguageDto getByIdLanguageDto = _mapper.Map<GetByIdLanguageDto>(searchLanguage);

                return getByIdLanguageDto;
            }
        }
    }
}

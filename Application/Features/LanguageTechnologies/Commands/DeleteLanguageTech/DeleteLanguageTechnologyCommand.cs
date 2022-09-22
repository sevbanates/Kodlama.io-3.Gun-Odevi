using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTech
{
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology selectedLanguageTechnology =
                    await _languageTechnologyRepository.GetAsync(p => p.Id == request.Id);
                LanguageTechnology deletedLanguageTechnology =
                    await _languageTechnologyRepository.DeleteAsync(selectedLanguageTechnology);
                DeletedLanguageTechnologyDto mappedLanguageTechnologyDto =
                    _mapper.Map<DeletedLanguageTechnologyDto>(deletedLanguageTechnology);

                return mappedLanguageTechnologyDto;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTech
{
    public class GetListLanguageTechnologyQuery : IRequest<LanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageTechnology> languageTechs = await _languageTechnologyRepository.GetListAsync(
                                                              include: l=>l.Include(p=>p.Language),
                                                              index: request.PageRequest.Page,
                                                              size: request.PageRequest.PageSize);
                LanguageTechnologyListModel mappedLanguageTechnology =
                    _mapper.Map<LanguageTechnologyListModel>(languageTechs);
                return mappedLanguageTechnology;
            }
        }
    }
}

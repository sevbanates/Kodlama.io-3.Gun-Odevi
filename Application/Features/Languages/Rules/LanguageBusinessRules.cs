using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicated(string name)
        {
            IPaginate<Language> searchLanguage = await _languageRepository.GetListAsync(l => l.Name == name);

            if (searchLanguage.Items.Any()) throw new BusinessException("Inserted name is already exist!");
        }

        public async Task CheckIfLanguageExistOrNot(int id)
        {
            Language searchLanguage = await _languageRepository.GetAsync(l => l.Id == id);
            if (searchLanguage == null) throw new BusinessException("Language could not be found!");
        }
    }
}

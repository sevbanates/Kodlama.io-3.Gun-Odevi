using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageValidator()
        {
            RuleFor(l => l.language.Name).NotEmpty();
            RuleFor(l => l.language.Name).MaximumLength(20);
            RuleFor(l => l.language.Name).MinimumLength(2);
        }
    }
}

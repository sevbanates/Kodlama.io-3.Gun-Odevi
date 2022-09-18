using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Name).MaximumLength(20);
            RuleFor(l => l.Name).MinimumLength(2);
        }
    }
}

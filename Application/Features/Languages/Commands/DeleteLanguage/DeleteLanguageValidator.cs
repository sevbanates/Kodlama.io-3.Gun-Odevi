using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageValidator()
        {
            RuleFor(l => l.Id).NotEmpty();
        }
    }
}

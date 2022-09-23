using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaValidator : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaValidator()
        {
            RuleFor(s=>s.SocialMediaName).NotEmpty();
            RuleFor(s=>s.Url).NotEmpty();
        }
    }
}

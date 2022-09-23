using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using FluentValidation;

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaValidator :AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaValidator()
        {
            RuleFor(s=>s.SocialMediaName).NotEmpty();
            RuleFor(s=>s.Url).NotEmpty();
        }
    }
}

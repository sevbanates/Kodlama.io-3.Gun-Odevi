using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Dtos
{
    public class GetByIdSocialMediaDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string SocialMediaName { get; set; }
        public string Url { get; set; }
    }
}

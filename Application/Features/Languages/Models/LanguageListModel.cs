using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Models
{
    public class LanguageListModel : BasePageableModel
    {
        public IList<GetListLanguageDto> Items { get; set; }
    }
}

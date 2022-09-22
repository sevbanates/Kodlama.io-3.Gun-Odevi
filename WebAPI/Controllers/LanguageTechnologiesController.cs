using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetListLanguage;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTech;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTech;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand)
        {
            UpdatedLanguageTechnologyDto result = await Mediator.Send(updateLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            DeletedLanguageTechnologyDto result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new() { PageRequest = pageRequest };

            LanguageTechnologyListModel result = await Mediator.Send(getListLanguageTechnologyQuery);

            return Created("", result);
        }
    }
}

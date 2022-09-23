using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Queries.GetByIdQuey;
using Application.Features.Users.Commands.CreateUser;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            var result = await Mediator.Send(createSocialMediaCommand);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            UpdatedSocialMediaDto result = await Mediator.Send(updateSocialMediaCommand);
            return Created("", result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeletedSocialMediaDto result = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }

        [HttpGet("{Id},{UserId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaQuery getByIdSocialMediaQuery)
        {
            GetByIdSocialMediaDto result = await Mediator.Send(getByIdSocialMediaQuery);
            return Created("", result);



        }

    }
}

using Application.Core.DTOs.Language;
using Application.Features.Languages;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class LanguageController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<LanguageRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLanguages()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(LanguageRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateLanguage(LanguageCUD languageCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { languageCUD = languageCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(LanguageRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLanguage(long Id, LanguageCUD languageCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, languageCUD = languageCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteLanguage(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}

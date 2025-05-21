using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppSettingsModule.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/settings/")]
    public class SettingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch]
        [Route("edit-theme")]
        public async Task<IActionResult> EditTheme()
        {
            return Ok();
        }

        [HttpPatch]
        [Route("edit-language")]
        public async Task<IActionResult> EditLanguage()
        {
            return Ok();
        }
    }
}

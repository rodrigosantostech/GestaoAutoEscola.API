using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("authenticate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> AuthenticateAsync([FromBody] DataAuthenticationDto dataAuthentication,
        [FromServices] IAutenticacaoService authenticationService)
    {
        return Ok(await authenticationService.Authenticate(dataAuthentication.Email, dataAuthentication.Password));
    }

    [HttpPost("revalidate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> RevalidateAsync([FromBody] string token,
        [FromServices] IAutenticacaoService authenticationService)
    {
        return Ok(await authenticationService.Revalidate(token));
    }
}
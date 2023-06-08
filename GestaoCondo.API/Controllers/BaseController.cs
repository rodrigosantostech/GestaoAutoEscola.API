using GestaoCondo.API.Presentation.Response;
using Microsoft.AspNetCore.Mvc;

namespace GestaoCondo.API.Controllers;

public class BaseController: ControllerBase
{
    protected ActionResult<T> ApiResponseToActionResult<T>(ApiResponse<T> response)
    {
        if (response.IsSuccess)
            return Ok(response);

        if (response.Error != null)
            return StatusCode(500, response);

        return BadRequest(response);
    }
}

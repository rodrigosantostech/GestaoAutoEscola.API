using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoCondo.API.Presentation.Dto;
using GestaoCondo.API.Presentation.Response;
using Microsoft.AspNetCore.Mvc;

namespace GestaoCondo.API.Controllers;
[ApiController]
[Route("api/tipotransacao")]
public class TipoTransacaoController : ControllerBase
{
    private readonly ITipoTransacaoService _tipoTransacaoService;
    public TipoTransacaoController(ITipoTransacaoService tipoTransacaoService)
    {
        _tipoTransacaoService = tipoTransacaoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoTransacaoDto>> ObterPorId(int id)
    {
        var response = await _tipoTransacaoService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoTransacaoDto>>> ObterTodos()
    {
        var response = await _tipoTransacaoService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [HttpPost("CreateTest")]
    public async Task<ActionResult<TipoTransacaoDto>> Adicionar(TipoTransacaoDto tipoTransacao)
    {
        var response = await _tipoTransacaoService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }


    [HttpPut]
    public async Task<ActionResult<TipoTransacaoDto>> Atualizar(TipoTransacaoDto tipoTransacao)
    {
        var response = await _tipoTransacaoService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TipoTransacaoDto>> Deletar(TipoTransacaoDto tipoTransacao)
    {
        var response = await _tipoTransacaoService.Deletar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    private ActionResult<T> ApiResponseToActionResult<T>(ApiResponse<T> response)
    {
        if (response.IsSuccess)
            return Ok(response);

        if (response.Error != null)
            return StatusCode(500, response);

        return BadRequest(response);
    }
}

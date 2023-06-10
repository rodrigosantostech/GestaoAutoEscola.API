using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/tipo_transacao")]
public class TipoTransacaoController : BaseController
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

    [HttpPost]
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
    public async Task<ActionResult<TipoTransacaoDto>> Deletar(int id)
    {
        var response = await _tipoTransacaoService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}

using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/categoria_transacao")]
public class CategoriaTransacaoController : BaseController
{
    private readonly ICategoriaTransacaoService _categoriaTransacaoService;
    public CategoriaTransacaoController(ICategoriaTransacaoService categoriaTransacaoService)
    {
        _categoriaTransacaoService = categoriaTransacaoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaTransacaoDto>> ObterPorId(int id)
    {
        var response = await _categoriaTransacaoService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaTransacaoDto>>> ObterTodos()
    {
        var response = await _categoriaTransacaoService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [HttpPost()]
    public async Task<ActionResult<CategoriaTransacaoDto>> Adicionar(CategoriaTransacaoDto tipoTransacao)
    {
        var response = await _categoriaTransacaoService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }


    [HttpPut]
    public async Task<ActionResult<CategoriaTransacaoDto>> Atualizar(CategoriaTransacaoDto tipoTransacao)
    {
        var response = await _categoriaTransacaoService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoriaTransacaoDto>> Deletar(int id)
    {
        var response = await _categoriaTransacaoService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}

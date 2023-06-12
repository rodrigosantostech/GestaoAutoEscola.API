using GestaoAutoEscola.API.Domain.Enums;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/tipo_veiculo")]
public class TipoVeiculoController : BaseController
{
    private readonly ITipoVeiculoService _tipoVeiculoService;
    public TipoVeiculoController(ITipoVeiculoService tipoVeiculoService)
    {
        _tipoVeiculoService = tipoVeiculoService;
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER,INSTRUTOR")]
    [HttpGet("{id}")]
    public async Task<ActionResult<TipoVeiculoDto>> ObterPorId(int id)
    {
        var response = await _tipoVeiculoService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER,INSTRUTOR")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoVeiculoDto>>> ObterTodos()
    {
        var response = await _tipoVeiculoService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPost]
    public async Task<ActionResult<TipoVeiculoDto>> Adicionar(TipoVeiculoDto tipoTransacao)
    {
        var response = await _tipoVeiculoService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPut]
    public async Task<ActionResult<TipoVeiculoDto>> Atualizar(TipoVeiculoDto tipoTransacao)
    {
        var response = await _tipoVeiculoService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<TipoVeiculoDto>> Deletar(int id)
    {
        var response = await _tipoVeiculoService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}
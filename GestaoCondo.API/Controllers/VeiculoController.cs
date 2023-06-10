using GestaoAutoEscola.API.Domain.Enums;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/veiculo")]
public class VeiculoController : BaseController
{
    private readonly IVeiculoService _veiculoService;
    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VeiculoDto>> ObterPorId(int id)
    {
        var response = await _veiculoService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoDto>>> ObterTodos()
    {
        var response = await _veiculoService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPost]
    public async Task<ActionResult<VeiculoDto>> Adicionar(VeiculoDto tipoTransacao)
    {
        var response = await _veiculoService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPut]
    public async Task<ActionResult<VeiculoDto>> Atualizar(VeiculoDto tipoTransacao)
    {
        var response = await _veiculoService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<VeiculoDto>> Deletar(int id)
    {
        var response = await _veiculoService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}

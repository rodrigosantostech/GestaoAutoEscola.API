using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Dto.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/aula")]
public class AulaController : BaseController
{
    private readonly IAulaService _aulaService;
    public AulaController(IAulaService aulaService)
    {
        _aulaService = aulaService;
    }

    [Authorize("Bearer")]
    [HttpGet("{id}")]
    public async Task<ActionResult<AulaDtoOutput>> ObterPorId(int id)
    {
        var response = await _aulaService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER,INSTRUTOR")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AulaDto>>> ObterTodos()
    {
        var response = await _aulaService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPost]
    public async Task<ActionResult<AulaDto>> Adicionar(AulaDto tipoTransacao)
    {
        var response = await _aulaService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPut]
    public async Task<ActionResult<AulaDto>> Atualizar(AulaDto tipoTransacao)
    {
        var response = await _aulaService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<AulaDto>> Deletar(int id)
    {
        var response = await _aulaService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}

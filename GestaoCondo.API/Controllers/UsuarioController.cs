using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAutoEscola.API.Controllers;
[ApiController]
[Route("api/usuario")]
public class UsuarioController : BaseController
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> ObterPorId(int id)
    {
        var response = await _usuarioService.ObterPorId(id);
        return ApiResponseToActionResult(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObterTodos()
    {
        var response = await _usuarioService.ObterTodos();
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> Adicionar(UsuarioDto tipoTransacao)
    {
        var response = await _usuarioService.Adicionar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }


    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPut]
    public async Task<ActionResult<UsuarioDto>> Atualizar(UsuarioDto tipoTransacao)
    {
        var response = await _usuarioService.Atualizar(tipoTransacao);
        return ApiResponseToActionResult(response);
    }

    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioDto>> Deletar(int id)
    {
        var response = await _usuarioService.Deletar(id);
        return ApiResponseToActionResult(response);
    }
}

using FluentValidation;
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
    private readonly IValidator<UsuarioDto> _validator;
    public UsuarioController(IUsuarioService usuarioService, IValidator<UsuarioDto> validator)
    {
        _usuarioService = usuarioService;
        _validator = validator;
    }

    [Authorize("Bearer")]
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
    public async Task<ActionResult<UsuarioDto>> Adicionar(UsuarioDto usuario)
    {
        var validationResult = _validator.Validate(usuario);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var response = await _usuarioService.Adicionar(usuario);
        return ApiResponseToActionResult(response);
    }


    [Authorize("Bearer", Roles = "ADMIN,MANAGER")]
    [HttpPut]
    public async Task<ActionResult<UsuarioDto>> Atualizar(UsuarioDto usuario)
    {
        var validationResult = _validator.Validate(usuario);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var response = await _usuarioService.Atualizar(usuario);
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

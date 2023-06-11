using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Domain.Interfaces.Strategy;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;
using GestaoAutoEscola.API.Services.Strategy;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<ApiResponse<UsuarioDto>> Adicionar(UsuarioDto usuario)
    {
        try
        {
            var usuarioValidation = await _usuarioRepository.ObterUsuarioPorEmail(usuario.Email);
            if (usuarioValidation != null) throw new ApiException("Usuario com esse email já existe", statusCode: 201);

            RoleStrategy roleStrategy;
            switch (usuario.Roles)
            {
                case "ALUNO":
                    roleStrategy = new AlunoRoleStrategy();
                    break;
                case "INSTRUTOR":
                    roleStrategy = new InstrutorRoleStrategy();
                    break;
                case "ADMIN":
                    roleStrategy = new AdminRoleStrategy();
                    break;
                case "GERENTE":
                    roleStrategy = new GerenteRoleStrategy();
                    break;
                default:
                    throw new ApiException("Role de usuário inválida.");
            }

            var usuarioEntity = roleStrategy.CriarUsuario(usuario);

            var createdTest = await _usuarioRepository.AdicionarAsync(usuarioEntity);

            return new ApiResponse<UsuarioDto>(true, createdTest.Adapt<UsuarioDto>(), "Usuario criado com Sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<UsuarioDto>(false, null!, ex, "Erro ao Criar Usuario");
        }
    }
    public async Task<ApiResponse<UsuarioDto>> Deletar(int id)
    {
        try
        {
            await _usuarioRepository.DeletarAsync(id);
            return new ApiResponse<UsuarioDto>(true, null!, "Deletar feito com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<UsuarioDto>(false, null!, ex, ex.Message);
        }
    }

    public async Task<ApiResponse<IEnumerable<UsuarioDto>>> ObterTodos()
    {
        try
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();

            var usuariosDto = usuarios.Select(u =>
            {
                var usuarioDto = u.Adapt<UsuarioDto>();
                usuarioDto.Senha = string.Empty;
                return usuarioDto;
            }).ToList();

            return new ApiResponse<IEnumerable<UsuarioDto>>(true, usuariosDto, "Consultar realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<UsuarioDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<UsuarioDto>> ObterPorId(int id)
    {

        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        if (usuario == null) throw new ApiException("Usuario não existe!", statusCode: 404);

        var usuarioDto = usuario!.Adapt<UsuarioDto>();
        usuarioDto.ForcarSenhaVazio();

        return new ApiResponse<UsuarioDto>(true, usuarioDto, "Consultar realizada com sucesso.");
    }

    public async Task<ApiResponse<UsuarioDto>> Atualizar(UsuarioDto usuarioDto)
    {
        try
        {
            var usuarioBanco = await _usuarioRepository.ObterPorIdAsync(usuarioDto.Id);
            if (usuarioBanco == null) throw new ApiException("Usuario não existe!", statusCode: 404);

            RoleStrategy roleStrategy;
            switch (usuarioDto.Roles)
            {
                case "ALUNO":
                    roleStrategy = new AlunoRoleStrategy();
                    break;
                case "INSTRUTOR":
                    roleStrategy = new InstrutorRoleStrategy();
                    break;
                case "ADMIN":
                    roleStrategy = new AdminRoleStrategy();
                    break;
                case "GERENTE":
                    roleStrategy = new GerenteRoleStrategy();
                    break;
                default:
                    throw new ApiException("Role de usuário inválida.");
            }

            var usuarioEntity = roleStrategy.AtualizarUsuario(usuarioBanco, usuarioDto);

            var usuarioAtualizado = await _usuarioRepository.AtualizarAsync(usuarioEntity);

            return new ApiResponse<UsuarioDto>(true, usuarioAtualizado.Adapt<UsuarioDto>(), "Atualização feita com sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<UsuarioDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<UsuarioDto>(false, null!, ex, "Erro ao atualizar Tipo Veiculo.");
        }
    }
}

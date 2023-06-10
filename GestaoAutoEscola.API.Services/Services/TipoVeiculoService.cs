using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;
public class TipoVeiculoService : ITipoVeiculoService
{
    private readonly ITipoVeiculoRepository _tipoVeiculoRepository;

    public TipoVeiculoService(ITipoVeiculoRepository tipoVeiculoRepository)
    {
        _tipoVeiculoRepository = tipoVeiculoRepository;

    }
    public async Task<ApiResponse<TipoVeiculoDto>> Adicionar(TipoVeiculoDto tipoVeiculo)
    {
        try
        {
            var tipoVeiculoEntity = new TipoVeiculo
            {
                Id = tipoVeiculo.Id,
                Tipo = tipoVeiculo.Tipo

            };

            var createdTest = await _tipoVeiculoRepository.AdicionarAsync(tipoVeiculoEntity);

            return new ApiResponse<TipoVeiculoDto>(true, createdTest.Adapt<TipoVeiculoDto>(), "Tipo Veiculo criado com Sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoVeiculoDto>(false, null!, ex, "Erro ao Criar Tipo de Veiculo");
        }
    }
    public async Task<ApiResponse<TipoVeiculoDto>> Deletar(int id)
    {
        try
        {
            await _tipoVeiculoRepository.DeletarAsync(id);
            return new ApiResponse<TipoVeiculoDto>(true, null!, "Deletar feito com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoVeiculoDto>(false, null!, ex, ex.Message);
        }
    }

    public async Task<ApiResponse<IEnumerable<TipoVeiculoDto>>> ObterTodos()
    {
        try
        {
            var tipoVeiculos = await _tipoVeiculoRepository.ObterTodosAsync();
            return new ApiResponse<IEnumerable<TipoVeiculoDto>>(true, tipoVeiculos.Adapt<List<TipoVeiculoDto>>(), "Consultar realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoVeiculoDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<TipoVeiculoDto>> ObterPorId(int id)
    {

        var tipoVeiculo = await _tipoVeiculoRepository.ObterPorIdAsync(id);
        if (tipoVeiculo == null) throw new ApiException("Tipo Veiculo não Existe", statusCode: 404);

        var tipoVeiculoDto = tipoVeiculo!.Adapt<TipoVeiculoDto>();

        return new ApiResponse<TipoVeiculoDto>(true, tipoVeiculoDto, "Consultar realizada com sucesso.");
    }

    public async Task<ApiResponse<TipoVeiculoDto>> Atualizar(TipoVeiculoDto tipoVeiculo)
    {
        try
        {
            var tipoVeiculoValidation = await _tipoVeiculoRepository.ObterPorIdAsync(tipoVeiculo.Id);
            if (tipoVeiculoValidation == null) throw new ApiException("Tipo Veiculo não Existe", statusCode: 404);

            var tipoVeiculoEntity = new TipoVeiculo
            {
                Id = tipoVeiculo.Id,
                Tipo = tipoVeiculo.Tipo

            };

            var tipoVeiculoAtualizado = await _tipoVeiculoRepository.AtualizarAsync(tipoVeiculoEntity);

            return new ApiResponse<TipoVeiculoDto>(true, tipoVeiculoAtualizado.Adapt<TipoVeiculoDto>(), "Atualização feita com sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<TipoVeiculoDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoVeiculoDto>(false, null!, ex, "Erro ao atualizar Tipo Veiculo.");
        }
    }
}

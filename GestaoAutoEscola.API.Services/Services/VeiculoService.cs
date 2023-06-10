using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;
public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;

    }
    public async Task<ApiResponse<VeiculoDto>> Adicionar(VeiculoDto veiculo)
    {
        try
        {
            var veiculoEntity = new Veiculo
            {
                Id = veiculo.Id,
                Modelo = veiculo.Modelo,
                Marca = veiculo.Marca,
                Ano = veiculo.Ano,
                Cor = veiculo.Cor,
                Placa = veiculo.Placa,
                Categoria = veiculo.Categoria,
                Status = veiculo.Status,
                Kilometragem = veiculo.Kilometragem,
                DataUltimaManutencao = veiculo.DataUltimaManutencao,
                TipoVeiculoId = veiculo.TipoVeiculoId
            };

            var veiculoCriado = await _veiculoRepository.AdicionarAsync(veiculoEntity);

            return new ApiResponse<VeiculoDto>(true, veiculoCriado.Adapt<VeiculoDto>(), "Veiculo criado com Sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<VeiculoDto>(false, null!, ex, "Erro ao Criar Veiculo");
        }
    }
    public async Task<ApiResponse<VeiculoDto>> Deletar(int id)
    {
        try
        {
            await _veiculoRepository.DeletarAsync(id);
            return new ApiResponse<VeiculoDto>(true, null!, "Deletar feito com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<VeiculoDto>(false, null!, ex, ex.Message);
        }
    }

    public async Task<ApiResponse<IEnumerable<VeiculoDto>>> ObterTodos()
    {
        try
        {
            var veiculos = await _veiculoRepository.ObterTodosAsync();
            return new ApiResponse<IEnumerable<VeiculoDto>>(true, veiculos.Adapt<List<VeiculoDto>>(), "Consultar realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<VeiculoDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<VeiculoDto>> ObterPorId(int id)
    {

        var veiculo = await _veiculoRepository.ObterPorIdAsync(id);
        if (veiculo == null) throw new ApiException("Veiculo não Existe", statusCode: 404);

        var veiculoDto = veiculo!.Adapt<VeiculoDto>();

        return new ApiResponse<VeiculoDto>(true, veiculoDto, "Consultar realizada com sucesso.");
    }

    public async Task<ApiResponse<VeiculoDto>> Atualizar(VeiculoDto veiculo)
    {
        try
        {
            var veiculoValidation = await _veiculoRepository.ObterPorIdAsync(veiculo.Id);
            if (veiculoValidation == null) throw new ApiException("Veiculo não Existe", statusCode: 404);

            var veiculoEntity = new Veiculo
            {
                Id = veiculo.Id,
                Modelo = veiculo.Modelo,
                Marca = veiculo.Marca,
                Ano = veiculo.Ano,
                Cor = veiculo.Cor,
                Placa = veiculo.Placa,
                Categoria = veiculo.Categoria,
                Status = veiculo.Status,
                Kilometragem = veiculo.Kilometragem,
                DataUltimaManutencao = veiculo.DataUltimaManutencao,
                TipoVeiculoId = veiculo.TipoVeiculoId
            };

            var veiculoAtualizado = await _veiculoRepository.AtualizarAsync(veiculoEntity);

            return new ApiResponse<VeiculoDto>(true, veiculoAtualizado.Adapt<VeiculoDto>(), "Atualização feita com sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<VeiculoDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<VeiculoDto>(false, null!, ex, "Erro ao atualizar Veiculo.");
        }
    }
}

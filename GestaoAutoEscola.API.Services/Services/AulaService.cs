using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Dto.Output;
using GestaoAutoEscola.API.Presentation.Response;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;
public class AulaService : IAulaService
{
    private readonly IAulaRepository _aulaRepository;
    private readonly IVeiculoRepository _veiculoRepository;
    public AulaService(IAulaRepository aulaRepository, IVeiculoRepository veiculoRepository)
    {
        _aulaRepository = aulaRepository;
        _veiculoRepository = veiculoRepository;

    }
    public async Task<ApiResponse<AulaDto>> Adicionar(AulaDto aula)
    {
        try
        {
            if (!await VerificarDisponibilidadeInstrutor(aula))
            {
                throw new ApiException("Instrutor não disponível para a data e hora informada!", statusCode: 409);
            }

            if (!await VerificarDisponibilidadeVeiculo(aula))
            {
                throw new ApiException("Veiculo não disponível para a data e hora informada!", statusCode: 409);
            }

            var aulaEntity = new Aula
            {
                Id = aula.Id,
                Data = aula.Data,
                HoraInicio = aula.HoraInicio,
                HoraFim = aula.HoraFim,
                AlunoId = aula.AlunoId,
                InstrutorId = aula.InstrutorId,
                VeiculoId = aula.VeiculoId,
                Pago = aula.Pago,
                Finalizada = false,
                TransacaoId = aula.TransacaoId,
                AvaliacaoId = aula.AvaliacaoId
            };

            var aulaCriada = await _aulaRepository.AdicionarAsync(aulaEntity);

            return new ApiResponse<AulaDto>(true, aulaCriada.Adapt<AulaDto>(), "Aula criada com Sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<AulaDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<AulaDto>(false, null!, ex, "Erro ao Criar Aula");
        }
    }
    public async Task<ApiResponse<AulaDto>> Deletar(int id)
    {
        try
        {
            await _aulaRepository.DeletarAsync(id);
            return new ApiResponse<AulaDto>(true, null!, "Deletar feito com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<AulaDto>(false, null!, ex, ex.Message);
        }
    }

    public async Task<ApiResponse<IEnumerable<AulaDto>>> ObterTodos()
    {
        try
        {
            var aulas = await _aulaRepository.ObterTodosAsync();
            return new ApiResponse<IEnumerable<AulaDto>>(true, aulas.Adapt<List<AulaDto>>(), "Consultar realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<AulaDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<AulaDtoOutput>> ObterPorId(int id)
    {

        var aula = await _aulaRepository.ObterPorIdAsync(id);
        if (aula == null) throw new ApiException("Aula não Existe", statusCode: 404);

        var aulaDto = aula!.Adapt<AulaDtoOutput>();

        return new ApiResponse<AulaDtoOutput>(true, aulaDto, "Consultar realizada com sucesso.");
    }

    public async Task<ApiResponse<AulaDto>> Atualizar(AulaDto aula)
    {
        try
        {
            var aulaValidation = await _aulaRepository.ObterPorIdAsync(aula.Id);
            if (aulaValidation == null) throw new ApiException("Veiculo não Existe", statusCode: 404);

            var aulaEntity = new Aula
            {
                Id = aula.Id,
                HoraInicio = aula.HoraInicio,
                HoraFim = aula.HoraFim,
                AlunoId = aula.AlunoId,
                InstrutorId = aula.InstrutorId,
                VeiculoId = aula.VeiculoId,
                Pago = aula.Pago,
                Finalizada = aula.Finalizada,
                TransacaoId = aula.TransacaoId,
                AvaliacaoId = aula.AvaliacaoId
            };

            var veiculoAtualizado = await _aulaRepository.AtualizarAsync(aulaEntity);

            return new ApiResponse<AulaDto>(true, veiculoAtualizado.Adapt<AulaDto>(), "Atualização feita com sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<AulaDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<AulaDto>(false, null!, ex, "Erro ao atualizar Veiculo.");
        }
    }


    private async Task<bool> VerificarDisponibilidadeVeiculo(AulaDto aula)
    {
        var aulasVeiculo = await _aulaRepository.ObterAulasPorVeiculo(aula.VeiculoId);

        // Verificar se há alguma sobreposição de horário com as aulas existentes
        var conflito = aulasVeiculo.Any(a =>
            a.Data.Date == aula.Data.Date &&
            a.HoraInicio < aula.HoraFim &&
            a.HoraFim > aula.HoraInicio);

        return !conflito;
    }

    private async Task<bool> VerificarDisponibilidadeInstrutor(AulaDto aula)
    {
        var aulasInstrutor = await _aulaRepository.ObterAulasPorInstrutor(aula.InstrutorId);

        // Verificar se há alguma sobreposição de horário com as aulas existentes
        var conflito = aulasInstrutor.Any(a =>
            a.Data.Date == aula.Data.Date &&
            a.HoraInicio < aula.HoraFim &&
            a.HoraFim > aula.HoraInicio);

        return !conflito;
    }
}

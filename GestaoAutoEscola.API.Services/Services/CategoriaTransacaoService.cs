using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoCondo.API.Presentation.Response;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;

public class CategoriaTransacaoService : ICategoriaTransacaoService
{
    private readonly ICategoriaTransacaoRepository _categoriaTransacaoRepository;

    public CategoriaTransacaoService(ICategoriaTransacaoRepository categoriaTransacaoRepository)
    {
        _categoriaTransacaoRepository = categoriaTransacaoRepository;

    }
    public async Task<ApiResponse<CategoriaTransacaoDto>> Adicionar(CategoriaTransacaoDto tipoTransacao)
    {
        try
        {
            var tipoTransacaoValidation = await _categoriaTransacaoRepository.ObterPorIdAsync(tipoTransacao.Id);
            if (tipoTransacaoValidation != null) return new ApiResponse<CategoriaTransacaoDto>(false, null!, "Categoria Transacao ja existe!");

            var tipoTransacaoEntity = new CategoriaTransacao
            {
                Id = tipoTransacao.Id,
                Nome = tipoTransacao.Nome

            };

            var createdTest = await _categoriaTransacaoRepository.AdicionarAsync(tipoTransacaoEntity);

            return new ApiResponse<CategoriaTransacaoDto>(true, createdTest.Adapt<CategoriaTransacaoDto>(), "Categoria Transacao criado com Sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CategoriaTransacaoDto>(false, null!, ex, "Erro ao Criar Categoria Transacao");
        }
    }
    public async Task<ApiResponse<CategoriaTransacaoDto>> Deletar(int id)
    {
        try
        {
            await _categoriaTransacaoRepository.DeletarAsync(id);
            return new ApiResponse<CategoriaTransacaoDto>(true, null!, "Deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CategoriaTransacaoDto>(false, null!, ex, "Erro ao tentar deletar Categoria Transacao.");
        }
    }

    public async Task<ApiResponse<IEnumerable<CategoriaTransacaoDto>>> ObterTodos()
    {
        try
        {
            var categoriasTransacao = await _categoriaTransacaoRepository.ObterTodosAsync();
            return new ApiResponse<IEnumerable<CategoriaTransacaoDto>>(true, categoriasTransacao.Adapt<List<CategoriaTransacaoDto>>(), "Consulta realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<CategoriaTransacaoDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<CategoriaTransacaoDto>> ObterPorId(int id)
    {
        var categoriaTransacao = await _categoriaTransacaoRepository.ObterPorIdAsync(id);
        if (categoriaTransacao == null)
        {
            return new ApiResponse<CategoriaTransacaoDto>(false, null!, "Categoria Transacao não existe!.");
        }

        var categoriaTransacaoDto = categoriaTransacao!.Adapt<CategoriaTransacaoDto>();

        return new ApiResponse<CategoriaTransacaoDto>(true, categoriaTransacaoDto, "Consulta realizada com sucesso.");
    }

    public async Task<ApiResponse<CategoriaTransacaoDto>> Atualizar(CategoriaTransacaoDto tipoTransacao)
    {
        try
        {
            var categoriaValidacao = await _categoriaTransacaoRepository.ObterPorIdAsync(tipoTransacao.Id);
            if (categoriaValidacao == null) return new ApiResponse<CategoriaTransacaoDto>(false, null!, "Tipo Transacao nao Existe");

            var categoriaTransacaoEntity = new CategoriaTransacao
            {
                Id = tipoTransacao.Id,
                Nome = tipoTransacao.Nome

            };

            var categoriaTransacaoAtualizado = await _categoriaTransacaoRepository.AtualizarAsync(categoriaTransacaoEntity);

            return new ApiResponse<CategoriaTransacaoDto>(true, categoriaTransacaoAtualizado.Adapt<CategoriaTransacaoDto>(), "Atualização feita com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CategoriaTransacaoDto>(false, null!, ex, "Erro ao atualizar Categoria Transacao.");
        }
    }
}
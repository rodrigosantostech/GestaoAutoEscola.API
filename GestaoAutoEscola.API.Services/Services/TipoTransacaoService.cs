﻿using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;
using Mapster;

namespace GestaoAutoEscola.API.Services.Services;

public class TipoTransacaoService : ITipoTransacaoService
{
    private readonly ITipoTransacaoRepository _tipoTransacaoRepository;

    public TipoTransacaoService(ITipoTransacaoRepository tipoTransacaoRepository)
    {
        _tipoTransacaoRepository = tipoTransacaoRepository;

    }
    public async Task<ApiResponse<TipoTransacaoDto>> Adicionar(TipoTransacaoDto tipoTransacao)
    {
        try
        {
            var tipoTransacaoEntity = new TipoTransacao
            {
                Id = tipoTransacao.Id,
                Tipo = tipoTransacao.Tipo

            };

            var createdTest = await _tipoTransacaoRepository.AdicionarAsync(tipoTransacaoEntity);

            return new ApiResponse<TipoTransacaoDto>(true, createdTest.Adapt<TipoTransacaoDto>(), "Tipo Transacao criado com Sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoTransacaoDto>(false, null!, ex, "Erro ao Criar Tipo de Transacao");
        }
    }
    public async Task<ApiResponse<TipoTransacaoDto>> Deletar(int id)
    {
        try
        {
            await _tipoTransacaoRepository.DeletarAsync(id);
            return new ApiResponse<TipoTransacaoDto>(true, null!, "Deletar feito com sucesso!");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoTransacaoDto>(false, null!, ex, "Error ao deletar Tipo Transacao");
        }
    }

    public async Task<ApiResponse<IEnumerable<TipoTransacaoDto>>> ObterTodos()
    {
        try
        {
            var tipoTransacaos = await _tipoTransacaoRepository.ObterTodosAsync();
            return new ApiResponse<IEnumerable<TipoTransacaoDto>>(true, tipoTransacaos.Adapt<List<TipoTransacaoDto>>(), "Consultar realizada com sucesso.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoTransacaoDto>>(false, null!, ex, "Consultar realizada com erro.");
        }
    }

    public async Task<ApiResponse<TipoTransacaoDto>> ObterPorId(int id)
    {
        try
        {
            var tipoTransacao = await _tipoTransacaoRepository.ObterPorIdAsync(id);
            if (tipoTransacao == null) throw new ApiException("Tipo Transacao não Existe", statusCode: 404);

            var tipoTransacaoDto = tipoTransacao!.Adapt<TipoTransacaoDto>();

            return new ApiResponse<TipoTransacaoDto>(true, tipoTransacaoDto, "Consultar realizada com sucesso.");

        }
        catch (ApiException ex)
        {
            return new ApiResponse<TipoTransacaoDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
    }

    public async Task<ApiResponse<TipoTransacaoDto>> Atualizar(TipoTransacaoDto tipoTransacao)
    {
        try
        {
            var testValidation = await _tipoTransacaoRepository.ObterPorIdAsync(tipoTransacao.Id);
            if (testValidation == null) throw new ApiException("Tipo Transacao não Existe", statusCode: 404);

            var tipoTransacaoEntity = new TipoTransacao
            {
                Id = tipoTransacao.Id,
                Tipo = tipoTransacao.Tipo

            };

            var tipoTransacaoAtualizado = await _tipoTransacaoRepository.AtualizarAsync(tipoTransacaoEntity);

            return new ApiResponse<TipoTransacaoDto>(true, tipoTransacaoAtualizado.Adapt<TipoTransacaoDto>(), "Atualização feita com sucesso!");
        }
        catch (ApiException ex)
        {
            return new ApiResponse<TipoTransacaoDto>(false, ex.StatusCode, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoTransacaoDto>(false, null!, ex, "Erro ao atualizar Tipo Transacao.");
        }
    }
}

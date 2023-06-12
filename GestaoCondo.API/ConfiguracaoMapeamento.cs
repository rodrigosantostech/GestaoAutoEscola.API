using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Presentation.Dto.Output;
using Mapster;
using System.Reflection;

namespace GestaoAutoEscola.API;

public static class ConfiguracaoMapeamento
{
    public static void RegistrarMapeamento(this IServiceCollection service)
    {
        TypeAdapterConfig<Aula, AulaDtoOutput>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Data, src => src.Data)
            .Map(dest => dest.HoraFim, src => src.HoraFim)
            .Map(dest => dest.HoraInicio, src => src.HoraInicio)
            .Map(dest => dest.Pago, src => src.Pago)
            .Map(dest => dest.Finalizada, src => src.Finalizada)
            .Map(dest => dest.Veiculo, src => src.Veiculo)
            .Map(dest => dest.Instrutor, src => src.Instrutor)
            .Map(dest => dest.Aluno, src => src.Aluno);

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}

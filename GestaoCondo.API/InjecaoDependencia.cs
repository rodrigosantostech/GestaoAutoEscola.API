using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Infra.Data.Context;
using GestaoAutoEscola.API.Infra.Data.Repository;
using GestaoAutoEscola.API.Services.Services;

namespace GestaoCondo.API;

public static class InjecaoDependencia
{
    public static void AdicionarServicos(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddScoped<IAulaRepository, AulaRepository>();
        services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
        services.AddScoped<ICategoriaTransacaoRepository, CategoriaTransacaoRepository>();
        services.AddScoped<IInstrutorRepository, InstrutorRepository>();
        services.AddScoped<ITipoTransacaoRepository, TipoTransacaoRepository>();
        services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();

        services.AddScoped<ITipoTransacaoService, TipoTransacaoService>();
        services.AddScoped<ICategoriaTransacaoService, CategoriaTransacaoService>();
    }
}

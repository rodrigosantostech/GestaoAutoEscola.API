using CDT.Base2Launch.API.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using GestaoAutoEscola.API.CrossCutting;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Infra.Data.Context;
using GestaoAutoEscola.API.Infra.Data.Repository;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Validation;
using GestaoAutoEscola.API.Services.Services;
using GestaoCondo.API.Presentation;

namespace GestaoAutoEscola.API;

public static class InjecaoDependencia
{
    public static void AdicionarServicos(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpContextAccessor();

        var jwtOptions = new JwtOptions();
        configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions, c => c.BindNonPublicProperties = true);
        services.AddSingleton(jwtOptions);
        RegisterAuthentication.Register(services, jwtOptions);

        services.AddTransient<ErrorHandlerMiddleware>();
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
        services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();
        services.AddScoped<IVeiculoService, VeiculoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAutenticacaoService, AutenticacaoService>();
        services.AddScoped<IAulaService, AulaService>();

        services.AddFluentValidationAutoValidation();
        services.AddTransient<IValidator<UsuarioDto>, UsuarioDtoValidator>();
    }
}

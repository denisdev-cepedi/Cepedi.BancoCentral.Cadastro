using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.Cadastro.Compartilhado;
using Cepedi.BancoCentral.Cadastro.Dados;
using Cepedi.BancoCentral.Cadastro.Dados.Repositories;
using Cepedi.BancoCentral.Cadastro.Data.Repositories;
using Cepedi.BancoCentral.Cadastro.Data.Repositories.Queries;
using Cepedi.BancoCentral.Cadastro.Dominio;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Pipelines;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.BancoCentral.Cadastro.IoC
{
    [ExcludeFromCodeCoverage]
    public static class IoCServiceExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExcecaoPipeline<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacaoComportamento<,>));
            ConfigurarFluentValidation(services);
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEstadoCivilRepository, EstadoCivilRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<INacionalidadeRepository, NacionalidadeRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPixRepository, PixRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoRegistroRepository, TipoRegistroRepository>();
            services.AddScoped<IRegistroTransacaoBancoRepository, RegistroTransacaoBancoRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRegistroTransacaoBancoQueryRepository, RegistroTransacaoBancoQueryRepository>();
            services.AddHealthChecks()
               .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigurarFluentValidation(IServiceCollection services)
        {
            var abstractValidator = typeof(AbstractValidator<>);
            var validadores = typeof(IValida)
                .Assembly
                .DefinedTypes
                .Where(type => type.BaseType?.IsGenericType is true &&
                type.BaseType.GetGenericTypeDefinition() ==
                abstractValidator)
                .Select(Activator.CreateInstance)
                .ToArray();

            foreach (var validator in validadores)
            {
                services.AddSingleton(validator!.GetType().BaseType!, validator);
            }
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            // services.AddDbContext<AlternativeDbContext>((sp, options) =>
            // {
            //     //options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            // });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}

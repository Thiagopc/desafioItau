using desafioItau.application.Interfaces.UseCase;
using desafioItau.application.UseCase;
using desafioItau.domain.Facade;
using desafioItau.domain.Interfaces.Evento;
using desafioItau.domain.Interfaces.Facade;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;
using desafioItau.domain.Services;
using desafioItau.infra.Db;
using desafioItau.infra.Repositories.ClasseBase;
using desafioItau.infra.Sqs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.infra.IoC
{
    public static class InjetorDependencia
    {

        public static void ConfigurarIoC(this IServiceCollection servico)
        {
            servico.AddHttpClient();
            servico.AddScoped<IHttpRepository, HttpRepository>();
            servico.AddScoped<ICacheRepository, CacheRepository>();
            servico.AddScoped<IFacadeClienteRepository, FacadeClienteRepository>();
            servico.AddScoped<IEnvioSQS, EnvioSQS>();
            servico.AddScoped<ITransacaoFinanceiraUseCase, TransacaoFinanceiraUseCase>();
            servico.AddScoped<IClienteService, ClienteService>();
            servico.AddScoped<IContaService, ContaService>();            
            servico.AddScoped<ITransacaoService, TransacaoService>();            
            servico.AddScoped(typeof(IRepositoryDbBase<>), typeof(DbBaseRepository<>));            
            //Não irei pegar de arquivo externo e nem de variável de ambiente apenas por simplificação
            servico.AddDbContext<DbConnection>(options => options.UseNpgsql("User ID=user;Password=password;Host=postgres;Port=5432;Database=desafioitau;Pooling=true;"));
        }

    }
}

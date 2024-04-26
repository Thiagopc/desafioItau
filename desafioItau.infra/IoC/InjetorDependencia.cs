using desafioItau.application.Interfaces.UseCase;
using desafioItau.application.UseCase;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.infra.Db;
using desafioItau.infra.Repositories.ClasseBase;
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
            servico.AddScoped<ITransacaoFinanceiraUseCase, TransacaoFinanceiraUseCase>();
            //Não irei pegar de arquivo externo e nem de variável de ambiente apenas por simplificação
            servico.AddDbContext<DbConnection>(options => options.UseNpgsql("User ID=user;Password=password;Host=localhost;Port=5432;Database=desafioitau;Pooling=true;"));
        }

    }
}

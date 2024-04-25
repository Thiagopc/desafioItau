using desafioItau.application.Interfaces.UseCase;
using desafioItau.application.UseCase;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.infra.Repositories.ClasseBase;
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
        }

    }
}

using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.infra.Repositories.ClasseBase;
using desafioItau.test.Build;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.test
{
    [TestClass]
    public class ContaServiceTest
    {




       


        [DataRow("d0d32142-74b7-4aca-9c68-838aeacef96b", "41313d7b-bd75-4c75-9dea-1f4be434007f",
            "Transação não autorizada. Motivo: Limite diário", 2000.00, DisplayName = "ContaService 1")]

        [DataRow("d0d32142-74b7-4aca-9c68-838aeacef96b", "00313d7b-bd75-4c75-9dea-1f4be434007f",
            "Conta de destino está inativa", 2000.00, DisplayName = "ContaService 2")]

        [DataRow("00313d7b-bd75-4c75-9dea-1f4be434007f", "d0d32142-74b7-4aca-9c68-838aeacef96b", 
            "Conta de origem está inativa", 4000.00, DisplayName = "ContaService 3")]

        [DataRow("41313d7b-bd75-4c75-9dea-1f4be434007f", "d0d32142-74b7-4aca-9c68-838aeacef96b",
            "", 100.00, DisplayName = "ContaService 4")]

        [DataRow("41313d7b-bd75-4c75-9dea-1f4be434007f", "d0d32142-74b7-4aca-9c68-838aeacef96b",
            "Transacao não autorizada. Saldo insuficiente", 100000.00, DisplayName = "ContaService 5")]
        [TestMethod]
        public async Task RetornoSucesso(string contaOrigem, string contaDestino, string msgErro, double valor)
        {

            var contarService = BuilderContaService.Builder();
            try
            {
                await contarService.ValidarSolicitacao("", contaOrigem, contaDestino, (decimal)valor);

                if (!string.IsNullOrEmpty(msgErro))
                    throw new Exception("Erro não lançado");

            }
            catch (Exception ex)
            {
                Assert.AreEqual(msgErro, ex.Message);
            }         

        }
    }
}

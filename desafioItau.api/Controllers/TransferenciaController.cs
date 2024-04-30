using desafioItau.application.Dto.Request;
using desafioItau.application.Interfaces.UseCase;
using desafioItau.infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafioItau.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransacaoFinanceiraUseCase _useCase;
        private readonly ILogger<TransferenciaController> _logger;
        private readonly Guid _idTransacao;
        public TransferenciaController(ITransacaoFinanceiraUseCase useCase, ILogger<TransferenciaController> log)
        {
            _useCase = useCase;
            _logger = log;
            _idTransacao = Guid.NewGuid();

        }



        [HttpPost]
        public async Task<IActionResult> Transferencia([FromBody] TransferenciaRequest request)
        {
            //Nesse cenário estou considerando que as informações utilizadas são abstrações dos dados reais
            //que poderiam ser utilizadas em logs sem prejuízo a segurança das informações
            this._logger.LogInformation($"Iniciando processo de transação do cliente {request.IdCliente}. Identificador da chamada: ${_idTransacao.ToString()}");

            try
            {
                await this._useCase.RealizarTransacao(request, this._idTransacao.ToString());
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString(), ex);
                return StatusCode(500);
            }

        }



    }
}

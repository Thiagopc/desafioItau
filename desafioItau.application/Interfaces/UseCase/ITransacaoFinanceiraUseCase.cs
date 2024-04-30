using desafioItau.application.Dto.Request;

namespace desafioItau.application.Interfaces.UseCase
{
    public interface ITransacaoFinanceiraUseCase
    {
        Task RealizarTransacao(TransferenciaRequest requisicao,string idRequisicao, CancellationToken token = default);
    }
}

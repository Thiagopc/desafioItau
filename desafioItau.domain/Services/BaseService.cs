using desafioItau.domain.Entities;
using desafioItau.domain.Enum;
using desafioItau.domain.Interfaces.Repositories;


namespace desafioItau.domain.Services
{
    public abstract class BaseService
    {
        private readonly IRepositoryDbBase<Historico> _repositorioHistorico;
        protected  readonly IHttpRepository _clientehttp;
        public BaseService(IHttpRepository clientehttp, IRepositoryDbBase<Historico> repositorioHistorico)
        {
            _clientehttp = clientehttp;
            _repositorioHistorico = repositorioHistorico;
        }


        protected async Task salvarHistorico(EnumHistoricoTransacao status, string operacao, string idTransacao  )
        {
            var historico = new Historico
            {
                DataHora = DateTime.Now,
                IdStatus = (int)status,
                Operacao = operacao,
                IdTransacao = idTransacao
            };

            this._repositorioHistorico.Adicionar(historico);
            await this._repositorioHistorico.SalvarAsync();
        }


    }
}

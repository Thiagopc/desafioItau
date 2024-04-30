using desafioItau.domain.Interfaces.Evento;
using NATS.Client;
using System.Text.Json;
namespace desafioItau.infra.Sqs
{

    // Iria utilizar o SQS, mas por simplicidade de utilização do container, coloquei o NAST no lugar
    public class EnvioSQS : IEnvioSQS
    {

        private readonly Options _opcoes;
        private readonly string _nometopico = "BACEN";
        public EnvioSQS()
        {
            _opcoes = ConnectionFactory.GetDefaultOptions();
            _opcoes.Url = "nats://nats:4222";  // URL do servidor NATS

        }



        public async void Publicar<TEntidade>(TEntidade valor)
        {

            try
            {
                using (var conn = new ConnectionFactory().CreateConnection(_opcoes))
                {
                    string subject = _nometopico;  // Tópico onde a mensagem será publicada
                    string message = serializar(valor);  // Mensagem a ser enviada

                    // A biblioteca não possui ASYNC
                    conn.Publish(subject, System.Text.Encoding.UTF8.GetBytes(message));
                    Console.WriteLine($"Mensagem '{message}' publicada no tópico '{subject}'.");

                    // Encerrar a conexão
                    conn.Drain();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ou publicar no NATS: {ex.Message}");
            }

        }
    




    private string serializar<TEntidade>(TEntidade valor)
        => JsonSerializer.Serialize(valor);

}
}

# desafioItau

## Desafio 1

### Inicialização do Projeto via Docker

A aplicação e todas as dependências (excluindo as fornecidas pelo desafio) podem ser iniciadas com Docker Compose. Após clonar o repositório, acesse a raiz do projeto e execute o seguinte comando:

```docker-compose up --build -d ```

Observação Importante
A API requer que os seguintes endpoints estejam operacionais na máquina host:

1. Mock endpoint: http://localhost:9090
2. API endpoint: http://localhost:8080


#### As requisições podem ser enviadas para a API desenvolvida pelo seguinte endpoint:

```http://localhost:8000/api/transferencia```

### Corpo da Requisição
O corpo da requisição deve ser estruturado como segue:
```
{
    "idCliente": "2ceb26e9-7b5c-417e-bf75-ffaa66e3a76f",
    "valor": 1000.00,
    "conta": {
        "idOrigem": "d0d32142-74b7-4aca-9c68-838aeacef96b",
        "idDestino": "41313d7b-bd75-4c75-9dea-1f4be434007f"
    }
}
```

## Desafio 2

![alt text](https://github.com/Thiagopc/desafioItau/blob/main/Arquitetura.png "Desafio 2")



## Desafio 3


```


CREATE TABLE cliente(
id_cliente INT,
nome varchar(150) NOT NULL,
CONSTRAINT pk_cliente_id PRIMARY KEY(id_cliente)
);


CREATE TABLE conta(
    id_conta INT,
    id_cliente INT not null,
    saldo DECIMAL (10, 2) NOT NULL,
    CONSTRAINT pk_conta_id_conta PRIMARY KEY (id_conta),
    CONSTRAINT fk_conta_id_cliente FOREIGN KEY (id_cliente) REFERENCES cliente (id_cliente)
);


CREATE PROCEDURE transferencia
@id_conta_origem INT,
@id_conta_destino INT,
@valor DECIMAL(10,2)
AS 
BEGIN 
  
    IF NOT EXISTS (SELECT 1 FROM conta WHERE id_conta = @id_conta_origem)
    BEGIN
        PRINT 'Conta origem não existe';
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM conta WHERE id_conta = @id_conta_destino)
    BEGIN
        PRINT 'Conta destino não existe';
        RETURN;
    END

    BEGIN TRANSACTION;
    TRY
        -- Débito da conta origem
        UPDATE conta SET saldo = saldo - @valor WHERE id_conta = @id_conta_origem;

        -- Crédito na conta destino
        UPDATE conta SET saldo = saldo + @valor WHERE id_conta = @id_conta_destino;

        COMMIT TRANSACTION;
    CATCH
        PRINT 'Erro na transferência';
        ROLLBACK TRANSACTION;
    END TRY
END;
    


```
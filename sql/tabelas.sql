-- CREATE TABLE status(
--     id serial,
--     nome varchar(15),
--     constraint pk_id primary key(id)

-- );


CREATE TABLE  transacao(
    id varchar(36),
    constraint pk_id primary key(id)
);


CREATE TABLE historico_transferencia(
id varchar(36),
id_origem varchar(36),
id_destino varchar(36),
valor numeric(10, 2),
id_cliente varchar(36),
id_status int,
data_hora timestamp ,
constraint pk_id_historico_operacao primary key(id),
-- constraint fk_id_status foreign key (id_status) references status(id),
constraint fk_id foreign key(id) references transacao (id)
);


CREATE TABLE historico(
id serial,
id_transacao varchar(36),
--Deveria ser uma tabela tbm, mas não quero normalizar rs
operacao varchar(50),
id_status int,
data_hora timestamp ,
constraint pk_id_ primary key(id),
-- constraint fk_id_status foreign key (id_status) references status(id),
constraint fk_id_transacao foreign key (id_transacao) references transacao(id)

);
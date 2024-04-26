CREATE TABLE status(
    id serial,
    nome varchar(15),
    constraint pk_id_status primary key(id)

);

CREATE TABLE historico_transferencia(
id serial,
id_origem varchar(36),
id_destino varchar(36),
valor numeric(10, 2),
id_cliente varchar(36),
id_status int,
data_hora timestamp ,
constraint pk_id_historico_operacao primary key(id),
constraint fk_id_status foreign key (id_status) references status(id)
);


CREATE TABLE historico(
id int,
id_historico_operacao int,
operacao varchar(50),
id_status int,
data_hora timestamp ,
constraint pk_id_ primary key(id),
constraint fk_id_status foreign key (id_status) references status(id),
constraint fk_id_historico_operacao foreign key (id_historico_operacao) references status(id)

);
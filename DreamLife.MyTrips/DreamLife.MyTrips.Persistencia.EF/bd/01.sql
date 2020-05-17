# --- !Ups

CREATE SCHEMA mytripsschema;

GRANT USAGE ON SCHEMA mytripsschema TO dbo;

CREATE TABLE mytripsschema.cidade
(
	id serial NOT NULL,
	nome character varying(100) NOT NULL,
	pais character varying(100) NOT NULL,
	CONSTRAINT pk_cidade PRIMARY KEY (id)
);

GRANT SELECT, INSERT, UPDATE, DELETE ON TABLE mytripsschema.cidade TO dbo;
GRANT USAGE ON SEQUENCE mytripsschema.cidade_id_seq TO dbo;

COMMENT ON TABLE mytripsschema.cidade IS 'Entidade responsável por cadastrar cidade.';
COMMENT ON COLUMN mytripsschema.cidade.id IS 'Identificador único da entidade.';
COMMENT ON COLUMN mytripsschema.cidade.nome IS 'campo responsável por nomear as cidades.';
COMMENT ON COLUMN mytripsschema.cidade.pais IS 'campo responsável por nomear os paises da cidade.';


CREATE TABLE mytripsschema.hotel
(
	id serial NOT NULL,
	nome varchar(100) NOT NULL,
	preco_diaria double precision NOT NULL,
	classificacao integer NOT NULL,
	descricao varchar(1000) NOT NULL,
	imagem varchar(250) NOT NULL,
	localizacao varchar(250) NOT NULL,
	id_cidade integer NOT NULL,
	CONSTRAINT pk_hotel PRIMARY KEY (id),
	CONSTRAINT fk_h_cidade FOREIGN KEY (id_cidade) REFERENCES mytripsschema.cidade(id)
);


GRANT SELECT, INSERT, UPDATE, DELETE ON TABLE mytripsschema.hotel TO dbo;
GRANT USAGE ON SEQUENCE mytripsschema.hotel_id_seq TO dbo;

COMMENT ON TABLE mytripsschema.hotel IS 'Entidade responsável por cadastrar hotel.';
COMMENT ON COLUMN mytripsschema.hotel.id IS 'Identificador único da entidade.';
COMMENT ON COLUMN mytripsschema.hotel.nome IS 'campo responsável por nomear os hoteis.';
COMMENT ON COLUMN mytripsschema.hotel.preco_diaria IS 'campo responsável por conter o valor do hotel.';
COMMENT ON COLUMN mytripsschema.hotel.classificacao IS 'campo responsável por conter a classificacao do hotel.';
COMMENT ON COLUMN mytripsschema.hotel.descricao IS 'campo responsável por descrever o hotel.';
COMMENT ON COLUMN mytripsschema.hotel.imagem IS 'campo responsável por conter a imagem do hotel.';
COMMENT ON COLUMN mytripsschema.hotel.localizacao IS 'campo responsável por conter a localizacao do hotel.';
COMMENT ON COLUMN mytripsschema.hotel.id_cidade IS 'Identificador único da cidade';


CREATE TABLE mytripsschema.viagem
(
	id serial NOT NULL,
	data timestamp without time zone NOT NULL,
	qtd_pessoas integer NOT NULL,
	id_hotel integer NOT NULL,
	CONSTRAINT pk_viagem PRIMARY KEY (id),
	CONSTRAINT fk_v_hotel FOREIGN KEY (id_hotel) REFERENCES mytripsschema.hotel(id)
);


GRANT SELECT, INSERT, UPDATE, DELETE ON TABLE mytripsschema.viagem TO dbo;
GRANT USAGE ON SEQUENCE mytripsschema.viagem_id_seq TO dbo;


COMMENT ON TABLE mytripsschema.viagem IS 'Entidade responsável por cadastrar viagem.';
COMMENT ON COLUMN mytripsschema.viagem.id IS 'Identificador único da entidade.';
COMMENT ON COLUMN mytripsschema.viagem.data IS 'campo responsável por conter as datas da viagem.';
COMMENT ON COLUMN mytripsschema.viagem.qtd_pessoas IS 'campo responsável por conter o numero de pessoas da viagem.';
COMMENT ON COLUMN mytripsschema.viagem.id_hotel IS 'Identificador único do hotel';

# --- !Downs

DROP SCHEMA mytripsschema;
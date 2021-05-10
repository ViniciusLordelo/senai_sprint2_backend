CREATE DATABASE SENAI_HROADS_MANHA; 

USE SENAI_HROADS_MANHA;

CREATE TABLE TipoHabilidade
(
	idTipoHabilidade INT PRIMARY KEY IDENTITY
	,NomeTipoHabilidade VARCHAR(10) NOT NULL 
);
GO

CREATE TABLE Habilidades
(
	idHabilidade INT PRIMARY KEY IDENTITY
	,idTipoHabilidade INT FOREIGN KEY REFERENCES TipoHabilidade(idTipoHabilidade)
	,NomeHabilidade VARCHAR(200) NOT NULL 
);
GO

CREATE TABLE HabilidadeClasses
(
	idHabilidadeClasses INT PRIMARY KEY IDENTITY
	,idClasse INT FOREIGN KEY REFERENCES Classes(idClasse)
	,idHabilidade INT FOREIGN KEY REFERENCES Habilidades(idHabilidade)
);
GO

CREATE TABLE Classes
(
	idClasse INT PRIMARY KEY IDENTITY
	,NomeClasse VARCHAR(200) NOT NULL 
);
GO

CREATE TABLE Personagens
(
	idPersonagem INT PRIMARY KEY IDENTITY
	,idClasse INT FOREIGN KEY REFERENCES Classes(idClasse)
	,NomePersonagem VARCHAR(200) NOT NULL
	,CapacidadeMaximaVida VARCHAR(4)NOT NULL
	,CapacidadeMaximaMana VARCHAR(4)NOT NULL
	,DataAtualizacao VARCHAR(10)NOT NULL
	,DataCriacao VARCHAR(10)NOT NULL
);
GO

CREATE TABLE Usuario
(
	IdUsuario		INT PRIMARY KEY IDENTITY,
	NomeUsuario		VARCHAR(100) NOT NULL,
	EmailUsuario	VARCHAR(100) NOT NULL,
	SenhaUsuario	VARCHAR(100) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);
GO

CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo		  VARCHAR(100) NOT NULL
);
GO
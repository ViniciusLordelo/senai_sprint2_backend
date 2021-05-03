CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios
(
	IdFuncionario			INT PRIMARY KEY IDENTITY
	,NomeFuncionario		VARCHAR(100) NOT  NULL
	,SobrenomeFuncionario	VARCHAR(100) NOT NULL
)
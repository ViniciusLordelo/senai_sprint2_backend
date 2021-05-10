USE SENAI_HROADS_MANHA;

INSERT INTO TipoHabilidade(NomeTipoHabilidade)
VALUES		('Ataque')
			,('Defesa')
			,('Cura')
			,('Magia');

INSERT INTO Habilidades(idTipoHabilidade,NomeHabilidade)
VALUES		(1,'Lança Mortal')
			,(2,'Escudo Supremo')
			,(3,'Recuperar Vida');

INSERT INTO HabilidadeClasses(idClasse,idHabilidade)
VALUES		(1,1)
			,(1,2)
			,(2,2)
			,(3,1)
			,(4,3)
			,(4,2)
			,(5,null)
			,(6,3)
			,(7,null);

INSERT INTO Classes(NomeClasse)
VALUES		('Bárbaro')
			,('Cruzado')
			,('Caçadora de Demônios')
			,('Monge')
			,('Necromante')
			,('Feiticeiro')
			,('Arcanista');

INSERT Personagens(idClasse,NomePersonagem,CapacidadeMaximaVida,CapacidadeMaximaMana,DataAtualizacao,DataCriacao)
VALUES		(1,'DeuBug',100,80,'01/03/2021','18/01/2019')
			,(4,'BitBug',70,100,'01/03/2021','17/03/2016')
			,(7,'Fer8',75,60,'02/03/2021','18/03/2018');

UPDATE Personagens
SET NomePersonagem = 'Fer7'
WHERE idPersonagem = 3;

UPDATE Classes
SET NomeClasse = 'Necromancer'
WHERE idClasse = 5;

INSERT INTO Usuario(NomeUsuario, EmailUsuario, SenhaUsuario, IdTipoUsuario)
VALUES			   ('João Vitor','admin@admin.com','admin123',1)
				   ,('Vini Lordelo', 'client@client.com', 'client123',2);

INSERT INTO TipoUsuario(Titulo)
VALUES				   ('Administrador')
					   ,('Jogador');
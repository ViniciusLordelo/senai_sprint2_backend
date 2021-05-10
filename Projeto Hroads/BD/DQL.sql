USE SENAI_HROADS_MANHA;

SELECT * FROM Usuario;

SELECT * FROM TipoUsuario;

SELECT * FROM Personagens;

SELECT * FROM Classes;

SELECT NomeClasse FROM Classes;

SELECT * FROM Habilidades;

SELECT COUNT(NomeHabilidade) FROM Habilidades;

SELECT idHabilidade FROM Habilidades ORDER BY idHabilidade ASC;

SELECT * FROM TipoHabilidade;

SELECT NomeHabilidade AS Habilidade, NomeTipoHabilidade AS Tipo FROM Habilidades
INNER JOIN TipoHabilidade
ON TipoHabilidade.idTipoHabilidade = Habilidades.idTipoHabilidade;

SELECT NomePersonagem AS Personagens, NomeClasse AS Classe FROM Personagens
INNER JOIN Classes
ON Classes.idClasse = Personagens.idClasse;

SELECT NomeClasse, NomePersonagem FROM Classes
LEFT JOIN Personagens
ON Personagens.idClasse = Classes.idClasse;

SELECT NomeClasse, NomeHabilidade FROM HabilidadeClasses
INNER JOIN Habilidades
ON Habilidades.idHabilidade = HabilidadeClasses.idHabilidade
RIGHT JOIN Classes
ON Classes.idClasse = HabilidadeClasses.idClasse;

SELECT NomeHabilidade, NomeClasse FROM HabilidadeClasses
INNER JOIN Habilidades
ON Habilidades.idHabilidade = HabilidadeClasses.idHabilidade
INNER JOIN Classes
ON Classes.idClasse = HabilidadeClasses.idClasse;

SELECT NomeHabilidade, NomeClasse FROM HabilidadeClasses
LEFT JOIN Habilidades
ON Habilidades.idHabilidade = HabilidadeClasses.idHabilidade
LEFT JOIN Classes
ON Classes.idClasse = HabilidadeClasses.idClasse;


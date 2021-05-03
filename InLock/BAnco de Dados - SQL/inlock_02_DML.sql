USE inlock_games_manha;
GO

INSERT TipoUsuario(Titulo)
VALUES			  ('administrador')
				  ,('cliente');
GO

INSERT Usuario(NomeUsuario, Email, Senha, IdTipoUsuario)
VALUES		  ('Jailson Mendes', 'admin@admin.com', 'admin', 1)
			  ,('Michael Scott', 'cliente@cliente.com', 'cliente', 2);
GO

INSERT Estudio(NomeEstudio)
VALUES		  ('Blizzard')
			  ,('Rockstar Studios')
			  ,('Square Enix');
GO

INSERT Jogo(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES	   ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '20120515', 99.00, 1)
		  ,('Read Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western.', '20181026', 120.00, 2);
GO
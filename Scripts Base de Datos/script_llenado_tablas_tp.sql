USE [20212C_TP]
GO

INSERT INTO	dbo.TipoRecetas (Nombre)
VALUES	('Apta para celiacos'),
		('Casera'),
		('Diet'),
		('Gourmet'),
		('Postre'),
		('Vegana'),
		('Vegetariana');
		
INSERT INTO dbo.Usuarios (Nombre, Email, Password, Perfil, FechaRegistracion)
VALUES	('Alberto', 'albertofrenandez@email.com', 'alberto123', 1, '2021-10-01 22:00:00.200'),
		('Macricio', 'macriciomauri@email.com', 'macricio123', 2, '2021-10-05 15:00:00.200'),
		('Kestor', 'kestornirchner@email.com', 'kestor123', 1, '2021-10-07 22:00:00.200'),
		('Fernando', 'fernandoespinozo@email.com', 'fernando123', 2, '2021-10-09 22:00:00.200'),
		('Will', 'willsmith@email.com', 'will123', 1, '2021-10-07 22:22:00.200'),
		('Marta', 'martafort@email.com', 'marta123', 1, '2021-10-07 20:10:00.200'),
		('Angela', 'angelaleiva@email.com', 'angela123', 2, '2021-10-07 23:00:00.200'),
		('Ricky', 'rickyfort@email.com', 'ricky123', 1, '2021-10-07 20:01:00.200'),
		('Richard', 'richardmontaner@email.com', 'richard123', 1, '2021-02-07 20:10:00.200');
		
INSERT INTO dbo.Recetas (IdCocinero, Nombre, TiempoCoccion, Descripcion, Ingredientes, IdTipoReceta)
VALUES	(2, 'Hamburguesa de lentejas', 20, 'Hamburguesa a base lentejas', 'lentejas, pan rayado, zanahoria, cebolla', 6),
		(4, 'Ensalada', 5, 'Ensalada verde orgánica', 'rúcula, lechuga, chia, sésamo', 7),
		(2, 'Empanadas de carne', 30, 'Empanadas de carne especial', 'carne picada especial, huevo, aceitunas, cebolla', 2);	

INSERT INTO	dbo.Eventos (IdCocinero, Nombre, Fecha, CantidadComensales, Ubicacion, Foto, Precio, Estado)
VALUES	(2, 'Evento de veganos y vegetarianos', '2021-10-09 20:00:00.200', 30, 'Hotel Recoleta Grand', 'fotoevento1.jpg', 1500, 2),
		(4, 'Evento de gauchos', '2021-12-12 21:00:00.200', 30, 'Estancia Las Heras', 'fotoevento2.jpg', 2000, 0),
		(4, 'Cumpleaños de un tipo famoso', '2021-09-09 20:00:00.200', 30, 'Florencio Varela 1903', 'fotoevento3.jpg', 0, 1),
		(2, 'Aniversario en Municipalidad de La Matanza', '2021-09-09 20:00:00.200', 50, 'Club Social y Deportivo La Matanza', 'fotoevento4.jpg', 25, 2);

INSERT INTO DBO.EventosRecetas(IdEvento, IdReceta)
VALUES	(1, 1),
		(1, 2),
		(2, 1),
		(3, 1),
		(3, 2),
		(3, 3),
		(4, 1),
		(4, 2),
		(4, 3);

INSERT INTO dbo.Reservas (IdEvento, IdComensal, IdReceta, CantidadComensales, FechaCreacion)
VALUES	(1, 1, 1, 2, '2021-09-09 20:00:00.200'),
		(2, 1, 1, 3, '2021-12-10 21:00:00.200'),
		(3, 1, 1, 3, '2021-09-06 20:00:00.200'),
		(4, 1, 1, 5, '2021-09-05 20:00:00.200'),
		(1, 5, 2, 4, '2021-10-07 20:00:00.200'),
		(2, 5, 3, 1, '2021-12-11 21:00:00.200'),
		(3, 3, 2, 7, '2021-09-07 20:00:00.200'),
		(4, 5, 2, 2, '2021-09-07 20:00:00.200'),
		(1, 6, 2, 3, '2021-09-05 20:00:00.200'),
		(2, 6, 1, 5, '2021-11-12 21:00:00.200'),
		(3, 6, 3, 2, '2021-09-08 20:00:00.200'),
		(1, 1, 3, 2, '2021-07-09 20:00:00.200'),
		(2, 5, 3, 2, '2021-11-11 21:00:00.200'),
		(3, 3, 3, 2, '2021-08-07 20:00:00.200'),
		(4, 1, 3, 2, '2021-08-07 20:00:00.200'),
		(4, 5, 3, 2, '2021-03-03 20:00:00.200'),
		(4, 6, 3, 7, '2021-09-08 20:00:00.200');

INSERT INTO dbo.Calificaciones (IdEvento, IdComensal, Calificacion, Comentarios)
VALUES	(1, 1, 10, 'Muy bueno todo'),
		(2, 1, 5, 'Medio pelo'),
		(3, 3, 6, 'Masomeno'),
		(4, 1, 8, 'Zarpada la comida'),
		(1, 3, 1, 'Malisimo'),
		(2, 6, 9, 'Buenardo'),
		(1, 8, 3, 'Buena la comida, malo el servicio'),
		(2, 8, 6, 'Bueno, pero no tanto'),
		(3, 9, 7, 'Todo muy bien'),
		(4, 9, 10, 'Excelente'),
		(4, 5, 7, 'Bien'),
		(4, 6, 10, 'Epicardo');

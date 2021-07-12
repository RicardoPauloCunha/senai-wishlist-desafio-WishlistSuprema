USE WishList
GO

SELECT * FROM Desejo
SELECT * FROM Usuario
SELECT * FROM Usuario AS U INNER JOIN Desejo AS D ON U.Id = D.UsuarioId
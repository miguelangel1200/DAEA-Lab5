# DAEA-Lab5

select * from Product

CREATE PROC USP_SeleccionProducto
@Nombre varchar(50) = ''
AS
BEGIN
SELECT * FROM Product 
WHERE (@Nombre LIKE '%'+nombre+'%' OR @Nombre ='') 
END

USP_SeleccionProducto 'Pera'




CREATE PROC USP_InsertarProducto
@IdProducto INT,
@Nombre varchar(50),
@Precio decimal(5,2)
AS
BEGIN
INSERT INTO Product (id, nombre, precio, fecha_de_creacion)
VALUES (@IdProducto, @Nombre, @Precio, GETDATE())
END

USP_InsertarProducto 2,'Pera', 1.50

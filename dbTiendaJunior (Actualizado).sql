USE [dbTiendaJunior]
GO
/****** Object:  Table [dbo].[Tbl_Categoria]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Categoria](
	[Id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Descripcion] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_DetalleVenta]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_DetalleVenta](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[Id_Venta] [int] NOT NULL,
	[Id_Producto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Login]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Login](
	[Id_Login] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Contraseña] [nvarchar](100) NULL,
	[Id_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Precio]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Precio](
	[Id_Precio] [int] IDENTITY(1,1) NOT NULL,
	[PrecioUnidad] [money] NULL,
	[IdProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Precio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Producto]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Producto](
	[Id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Producto] [nvarchar](30) NULL,
	[Presentacion] [nvarchar](30) NULL,
	[Stock] [int] NULL,
	[IdCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Roles]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Roles](
	[Id_Roles] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[NivelPrivilegios] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Roles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Edad] [int] NULL,
	[Contacto] [nvarchar](100) NULL,
	[Id_Roles] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Ventas]    Script Date: 23/5/2024 12:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Ventas](
	[Id_Venta] [int] IDENTITY(1,1) NOT NULL,
	[dFecha] [datetime] NULL,
	[Cliente] [varchar](50) NULL,
	[Encargado] [varchar](50) NULL,
	[Total_Venta] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Categoria] ON 

INSERT [dbo].[Tbl_Categoria] ([Id_categoria], [Nombre], [Descripcion]) VALUES (1, N'Lacteos', N'Productos derivados de la leche')
INSERT [dbo].[Tbl_Categoria] ([Id_categoria], [Nombre], [Descripcion]) VALUES (2, N'Jarabes', N'Soluciones médicas de vía oral')
INSERT [dbo].[Tbl_Categoria] ([Id_categoria], [Nombre], [Descripcion]) VALUES (3, N'Jhon Doe', N'Prueba')
SET IDENTITY_INSERT [dbo].[Tbl_Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_DetalleVenta] ON 

INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (1, 2, CAST(4.48 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (4, 5, CAST(7.50 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (5, 9, CAST(20.70 AS Decimal(18, 2)), 1, 6)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (6, 3, CAST(6.72 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (7, 1, CAST(34.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (8, 2, CAST(4.48 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (1004, 5, CAST(170.00 AS Decimal(18, 2)), 1003, 1)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (1005, 2, CAST(3.00 AS Decimal(18, 2)), 1006, 1)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (1010, 2, CAST(4.48 AS Decimal(18, 2)), 1006, 2)
INSERT [dbo].[Tbl_DetalleVenta] ([Id_Detalle], [Cantidad], [SubTotal], [Id_Venta], [Id_Producto]) VALUES (1013, 2, CAST(4.48 AS Decimal(18, 2)), 5, 2)
SET IDENTITY_INSERT [dbo].[Tbl_DetalleVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Login] ON 

INSERT [dbo].[Tbl_Login] ([Id_Login], [UserName], [Contraseña], [Id_Usuario]) VALUES (2, N'Test', N'123', 2)
INSERT [dbo].[Tbl_Login] ([Id_Login], [UserName], [Contraseña], [Id_Usuario]) VALUES (3, N'Test2', N'123', 3)
INSERT [dbo].[Tbl_Login] ([Id_Login], [UserName], [Contraseña], [Id_Usuario]) VALUES (4, N'Test3', N'123', 4)
INSERT [dbo].[Tbl_Login] ([Id_Login], [UserName], [Contraseña], [Id_Usuario]) VALUES (5, N'Admin', N'123', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Precio] ON 

INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (1, 21.0000, 1)
INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (2, 2.2400, 2)
INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (3, 4.0000, 3)
INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (4, 2.0000, 4)
INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (5, 9999.0000, 6)
INSERT [dbo].[Tbl_Precio] ([Id_Precio], [PrecioUnidad], [IdProducto]) VALUES (6, 2.3000, 6)
SET IDENTITY_INSERT [dbo].[Tbl_Precio] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Producto] ON 

INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (1, N'Queso duroblandoS', N'1lb', 63, 1)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (2, N'Antitosín', N'Frasco 20ml', 319894, 2)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (3, N'Vacaolinita', N'Frasco 20 ml', 8146878, 1)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (4, N'Alcohol', N'Botella', 192, 2)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (5, N'Alcohol', N'Botella', 99999, 1)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (6, N'Nueva prueba', N'923232', 85246, 3)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (7, N'Alcohol para borrar', N'923232', 100, 1)
INSERT [dbo].[Tbl_Producto] ([Id_Producto], [Nombre_Producto], [Presentacion], [Stock], [IdCategoria]) VALUES (8, N'Qué diablos pasa?! ay me asust', N'Hola', 123, 2)
SET IDENTITY_INSERT [dbo].[Tbl_Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Roles] ON 

INSERT [dbo].[Tbl_Roles] ([Id_Roles], [Nombre], [Descripcion], [NivelPrivilegios]) VALUES (1, N'Administrador', N'El encargado', 1)
INSERT [dbo].[Tbl_Roles] ([Id_Roles], [Nombre], [Descripcion], [NivelPrivilegios]) VALUES (2, N'Dependiente', N'Encargado de tiendas', 2)
INSERT [dbo].[Tbl_Roles] ([Id_Roles], [Nombre], [Descripcion], [NivelPrivilegios]) VALUES (5, N'Invitado', N'Este rol es de prueba', 4)
SET IDENTITY_INSERT [dbo].[Tbl_Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] ON 

INSERT [dbo].[Tbl_Usuario] ([Id_Usuario], [Nombre], [Edad], [Contacto], [Id_Roles]) VALUES (1, N'Moncy Guevara', 54, N'7203-1234', 1)
INSERT [dbo].[Tbl_Usuario] ([Id_Usuario], [Nombre], [Edad], [Contacto], [Id_Roles]) VALUES (2, N'Nunca se olvida', 99, N'No lo sé', 5)
INSERT [dbo].[Tbl_Usuario] ([Id_Usuario], [Nombre], [Edad], [Contacto], [Id_Roles]) VALUES (3, N'Prueba 2', 100, N'Aún no lo sé', 2)
INSERT [dbo].[Tbl_Usuario] ([Id_Usuario], [Nombre], [Edad], [Contacto], [Id_Roles]) VALUES (4, N'Prueba 3', 23, N'Sigo sin saberlo', 2)
INSERT [dbo].[Tbl_Usuario] ([Id_Usuario], [Nombre], [Edad], [Contacto], [Id_Roles]) VALUES (5, N'Jorge campos', 29, N'2121-2828', 2)
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Ventas] ON 

INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (1, CAST(N'2023-02-01T00:00:00.000' AS DateTime), N'Gissellita', N'Aaron', CAST(43.88 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (2, CAST(N'2024-04-03T00:00:00.000' AS DateTime), N'Julio Jaramillo', N'Leo Dan', CAST(34.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (5, CAST(N'2024-04-05T09:15:00.000' AS DateTime), N'Aaaron', N'dss', CAST(4.48 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (1003, CAST(N'2024-04-16T12:47:00.000' AS DateTime), N'Solo dime', N'Qué vas a volver', CAST(170.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (1004, CAST(N'2024-04-24T12:52:00.000' AS DateTime), N'Aaaron', N'dss', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (1006, CAST(N'2024-04-02T08:11:00.000' AS DateTime), N'Aaaron', N'Test', CAST(9.72 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Ventas] ([Id_Venta], [dFecha], [Cliente], [Encargado], [Total_Venta]) VALUES (1010, CAST(N'2024-04-24T11:22:00.000' AS DateTime), N'Leo Salmerónw', N'Qué vas a volver', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tbl_Ventas] OFF
GO
ALTER TABLE [dbo].[Tbl_DetalleVenta]  WITH CHECK ADD FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[Tbl_Producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[Tbl_DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK__Tbl_Detal__Id_Ve__45F365D3] FOREIGN KEY([Id_Venta])
REFERENCES [dbo].[Tbl_Ventas] ([Id_Venta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbl_DetalleVenta] CHECK CONSTRAINT [FK__Tbl_Detal__Id_Ve__45F365D3]
GO
ALTER TABLE [dbo].[Tbl_Login]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Tbl_Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Tbl_Precio]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Tbl_Producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[Tbl_Producto]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Tbl_Categoria] ([Id_categoria])
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD FOREIGN KEY([Id_Roles])
REFERENCES [dbo].[Tbl_Roles] ([Id_Roles])
GO
/****** Object:  StoredProcedure [dbo].[spCategoria_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[DELETE]---
CREATE PROCEDURE [dbo].[spCategoria_Delete]
(@Id_categoria INT)
AS
BEGIN
	DELETE FROM Tbl_Categoria WHERE Id_categoria = @Id_categoria
END;
GO
/****** Object:  StoredProcedure [dbo].[spCategoria_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCategoria_GetAll]
AS
BEGIN
	SELECT Id_Categoria, Nombre, Descripcion FROM Tbl_Categoria
END;
GO
/****** Object:  StoredProcedure [dbo].[spCategoria_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCategoria_GetById]
(@Id_Categoria INT)
AS
BEGIN
	SELECT Id_Categoria, Nombre, Descripcion FROM Tbl_Categoria
    WHERE Id_Categoria = @Id_Categoria
END;
GO
/****** Object:  StoredProcedure [dbo].[spCategoria_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[INSERT]---
CREATE PROCEDURE [dbo].[spCategoria_Insert]
(@Nombre NVARCHAR(30), @Descripcion NVARCHAR(75))
AS
BEGIN
	INSERT INTO Tbl_Categoria
	VALUES(@Nombre, @Descripcion)
END;
GO
/****** Object:  StoredProcedure [dbo].[spCategoria_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[UPDATE]---
CREATE PROCEDURE [dbo].[spCategoria_Update] 
(@Id_categoria INT, @Nombre NVARCHAR(30), @Descripcion NVARCHAR(75))
AS
BEGIN
	UPDATE Tbl_Categoria SET
	Nombre = @Nombre, Descripcion = @Descripcion
	WHERE Id_categoria = @Id_categoria
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[spDetalleVenta_Delete]
(@Id_Detalle INT)
AS
BEGIN
	---[DECLARANDO VARIABLES]---
	DECLARE @PrecioUni MONEY, @SubTotal MONEY, @TotalVenta MONEY, @Cantidad INT, @Id_Venta INT, @Id_Producto INT

		---[RESTABLECIENDO STOCK]---
	SELECT @Cantidad = Cantidad, @Id_Producto = Id_Producto, @Id_Venta = Id_Venta FROM Tbl_DetalleVenta WHERE Id_Detalle = @Id_Detalle 
	UPDATE Tbl_Producto SET Stock += @Cantidad WHERE Id_Producto = @Id_Producto

	---Eliminando registro---
	DELETE FROM Tbl_DetalleVenta WHERE Id_Detalle = @Id_Detalle

	---[CALCULANDO EL TOTAL DE LA VENTA]---
	SELECT @TotalVenta = SUM(SubTotal) FROM Tbl_DetalleVenta WHERE Id_Venta = @Id_Venta

	UPDATE Tbl_Ventas SET Total_Venta = @TotalVenta WHERE Id_Venta = @Id_Venta

	
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDetalleVenta_GetAll]
AS
BEGIN
	SELECT Id_Detalle, Cantidad, SubTotal, V.dFecha, p.Nombre_Producto, v.Id_Venta, p.Id_Producto FROM Tbl_DetalleVenta Dv
	INNER JOIN Tbl_Ventas V ON Dv.Id_Venta = V.Id_Venta INNER JOIN Tbl_Producto P ON P.Id_Producto = Dv.Id_Producto
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_GetByID]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spDetalleVenta_GetByID]
(@Id_Detalle INT)
AS
BEGIN
	SELECT Id_Detalle, Cantidad, SubTotal, V.dFecha, p.Nombre_Producto, v.Id_Venta, p.Id_Producto FROM Tbl_DetalleVenta Dv
	INNER JOIN Tbl_Ventas V ON Dv.Id_Venta = V.Id_Venta INNER JOIN Tbl_Producto P ON P.Id_Producto = Dv.Id_Producto
	WHERE Id_Detalle = @Id_Detalle
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_GetByIdVenta]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spDetalleVenta_GetByIdVenta]
(@Id_Venta INT)
AS
BEGIN
	SELECT Id_Detalle, Cantidad, SubTotal, V.dFecha, p.Nombre_Producto, v.Id_Venta, p.Id_Producto FROM Tbl_DetalleVenta Dv
	INNER JOIN Tbl_Ventas V ON Dv.Id_Venta = V.Id_Venta INNER JOIN Tbl_Producto P ON P.Id_Producto = Dv.Id_Producto
	WHERE DV.Id_Venta = @Id_Venta
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---INSERT---
CREATE   PROC [dbo].[spDetalleVenta_Insert]
(@Cantidad INT, @Id_Venta INT, @Id_Producto INT)
AS
BEGIN
	---[DECLARANDO VARIABLES INTERNAS]---
	DECLARE @PrecioUni MONEY, @SubTotal MONEY, @TotalVenta MONEY

	---[CALCULANDO STOCK]---
	UPDATE Tbl_Producto SET Stock = Stock - @Cantidad WHERE Id_Producto = @Id_Producto
	
	---[CALCULANDO SUB TOTAL]---
	SELECT @PrecioUni = PrecioUnidad FROM Tbl_Precio WHERE IdProducto = @Id_Producto
	SET @SubTotal = (@PrecioUni * @Cantidad)

	INSERT INTO Tbl_DetalleVenta VALUES (@Cantidad, @SubTotal, @Id_Venta, @Id_Producto)

	---[CALCULANDO EL TOTAL DE LA VENTA]---
	SELECT @TotalVenta = SUM(SubTotal) FROM Tbl_DetalleVenta WHERE Id_Venta = @Id_Venta

	UPDATE Tbl_Ventas SET Total_Venta = @TotalVenta WHERE Id_Venta = @Id_Venta
END;
GO
/****** Object:  StoredProcedure [dbo].[spDetalleVenta_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spDetalleVenta_Update]
(@Id_Detalle INT, @Cantidad INT, @Id_Producto INT)
AS
BEGIN
	---[DECLARANDO VARIABLES]---
	DECLARE @PrecioUni MONEY, @SubTotal MONEY, @TotalVenta MONEY, @Stock INT, @Id_Venta INT
	SELECT @Id_Venta = Id_Venta FROM Tbl_DetalleVenta WHERE Id_Detalle = @Id_Detalle
	SET @Id_Venta = @Id_Venta

	---[RESTABLECIENDO STOCK]---
	SELECT @Stock = Cantidad FROM Tbl_DetalleVenta WHERE Id_Detalle = @Id_Detalle 
	UPDATE Tbl_Producto SET Stock += Stock WHERE Id_Producto = @Id_Producto

	---[DEFINIENDO NUEVO STOCK]---
	UPDATE Tbl_Producto SET Stock -= @Cantidad WHERE Id_Producto = @Id_Producto

	---[CALCULANDO SUB TOTAL]---
	SELECT @PrecioUni = PrecioUnidad FROM Tbl_Precio WHERE IdProducto = @Id_Producto
	SET @SubTotal = (@PrecioUni * @Cantidad)

	
	---Actualizando registro---
	UPDATE Tbl_DetalleVenta SET Cantidad = @Cantidad, Id_Producto = @Id_Producto, SubTotal= @SubTotal WHERE Id_Detalle = @Id_Detalle

	---[CALCULANDO EL TOTAL DE LA VENTA]---
	SELECT @TotalVenta = SUM(SubTotal) FROM Tbl_DetalleVenta WHERE Id_Venta = @Id_Venta

	UPDATE Tbl_Ventas SET Total_Venta = @TotalVenta WHERE Id_Venta = @Id_Venta

END;
GO
/****** Object:  StoredProcedure [dbo].[spLogin_Credentials]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spLogin_Credentials]
(@UserName NVARCHAR(20), @Contraseña NVARCHAR(255))
AS
BEGIN
	SELECT L.UserName, L.Contraseña, r.Nombre, u.Id_Usuario, r.Id_Roles  FROM Tbl_Login L 
	INNER JOIN Tbl_Usuario U ON L.Id_Usuario = U.Id_Usuario INNER JOIN Tbl_Roles R ON U.Id_Roles = R.Id_Roles
	WHERE UserName = @UserName AND Contraseña = @Contraseña
END
GO
/****** Object:  StoredProcedure [dbo].[spLogin_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spLogin_Delete]
(@Id_Login INT)
AS
	DECLARE @Rol VARCHAR(50)
	SELECT @Rol = rol.Nombre FROM Tbl_Login L INNER JOIN Tbl_Usuario U ON U.Id_Usuario = L.Id_Usuario
	INNER JOIN Tbl_Roles Rol ON U.Id_Roles = Rol.Id_Roles WHERE Id_Login = @Id_Login
	
 IF @Rol = 'Administrador'
    BEGIN
		PRINT 'No se puede eliminar el login del administrador'
    END
    ELSE
    BEGIN
        DELETE FROM Tbl_Login WHERE Id_Login = @Id_Login 
    END
GO
/****** Object:  StoredProcedure [dbo].[spLogin_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[spLogin_GetAll]
 AS
	SELECT Id_Login, UserName, Contraseña, U.Nombre, L.Id_Usuario FROM Tbl_Login L 
	INNER JOIN Tbl_Usuario U ON L.Id_Usuario = U.Id_Usuario
GO
/****** Object:  StoredProcedure [dbo].[spLogin_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spLogin_GetById]
 (@Id_Login INT)
 AS
	SELECT Id_Login, UserName, Contraseña, Id_Usuario FROM Tbl_Login WHERE Id_Login = @Id_Login
GO
/****** Object:  StoredProcedure [dbo].[spLogin_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spLogin_Insert]
 (@UserName NVARCHAR(50), @Contraseña NVARCHAR(50), @Id_Usuario INT)
 AS
	INSERT INTO Tbl_Login (UserName, Contraseña, Id_Usuario)
	VALUES (@UserName, @Contraseña, @Id_Usuario)
GO
/****** Object:  StoredProcedure [dbo].[spLogin_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spLogin_Update]
 (@Id_Login INT, @UserName NVARCHAR(50), @Contraseña NVARCHAR(50), @Id_Usuario INT)
 AS
	UPDATE Tbl_Login SET UserName = @UserName, Contraseña = @Contraseña,
	Id_Usuario = @Id_Usuario WHERE Id_Login = @Id_Login
GO
/****** Object:  StoredProcedure [dbo].[spPrecio_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[DELETE]---
CREATE PROCEDURE [dbo].[spPrecio_Delete]
(@Id_Precio INT)
AS
BEGIN
	DELETE FROM Tbl_Precio WHERE Id_Precio = @Id_Precio
END;
GO
/****** Object:  StoredProcedure [dbo].[spPrecio_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[GET ALL Y GET BY ID]---
CREATE PROCEDURE [dbo].[spPrecio_GetAll]
AS
BEGIN
	SELECT Price.Id_Precio, Price.PrecioUnidad, Price.IdProducto, Product.Nombre_Producto FROM Tbl_Precio Price
	INNER JOIN Tbl_Producto Product ON Price.IdProducto = Product.Id_Producto
END;
GO
/****** Object:  StoredProcedure [dbo].[spPrecio_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPrecio_GetById]
(@Id_Precio INT)
AS
BEGIN
	SELECT Price.Id_Precio, Price.PrecioUnidad, Price.IdProducto, Product.Nombre_Producto FROM Tbl_Precio Price
	INNER JOIN Tbl_Producto Product ON Price.IdProducto = Product.Id_Producto WHERE Price.Id_Precio = @Id_Precio
END;
GO
/****** Object:  StoredProcedure [dbo].[spPrecio_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spPrecio_Insert]
(@PrecioUnidad MONEY, @IdProducto INT)
AS
BEGIN
	INSERT INTO Tbl_Precio
	VALUES(@PrecioUnidad, @IdProducto)
END;
GO
/****** Object:  StoredProcedure [dbo].[spPrecio_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spPrecio_Update] 
(@Id_Precio INT, @Id_Producto INT, @PrecioUnidad MONEY)
AS
BEGIN
	UPDATE Tbl_Precio SET
	IdProducto = @Id_Producto, PrecioUnidad = @PrecioUnidad
	WHERE Id_Precio = @Id_Precio
END;
GO
/****** Object:  StoredProcedure [dbo].[spProducto_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[DELETE]---
CREATE PROCEDURE [dbo].[spProducto_Delete]
(@Id_Producto INT)
AS
BEGIN
	DELETE FROM Tbl_Producto WHERE Id_Producto = @Id_Producto
END;
GO
/****** Object:  StoredProcedure [dbo].[spProducto_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProducto_GetAll]
AS
BEGIN
	SELECT P.Id_Producto, P.Nombre_Producto, P.Presentacion, P.Stock, P.IdCategoria,  C.Nombre FROM Tbl_Producto P
	INNER JOIN Tbl_Categoria C ON P.IdCategoria = C.Id_categoria
END;
GO
/****** Object:  StoredProcedure [dbo].[spProducto_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProducto_GetById]
(@Id_Producto INT)
AS
BEGIN
	SELECT P.Id_Producto, P.Nombre_Producto, P.Presentacion, C.Nombre, P.Stock, P.IdCategoria, c.Nombre FROM Tbl_Producto P
	INNER JOIN Tbl_Categoria C ON P.IdCategoria = C.Id_categoria WHERE P.Id_Producto = @Id_Producto
END;
GO
/****** Object:  StoredProcedure [dbo].[spProducto_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[INSERT]---
CREATE PROCEDURE [dbo].[spProducto_Insert]
(@Nombre_Producto NVARCHAR(30), @Presentacion NVARCHAR(30), @Stock NVARCHAR(30), @IdCategoria INT)
AS
BEGIN
	INSERT INTO Tbl_Producto VALUES(@Nombre_Producto, @Presentacion, @Stock, @IdCategoria)
END;
GO
/****** Object:  StoredProcedure [dbo].[spProducto_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[UPDATE]---
CREATE PROCEDURE [dbo].[spProducto_Update] 
(@Id_Producto INT, @Nombre_Producto NVARCHAR(30), @Presentacion NVARCHAR(30), @IdCategoria INT, @Stock NVARCHAR(30))
AS
BEGIN
	UPDATE Tbl_Producto SET
	Nombre_Producto = @Nombre_Producto, Presentacion = @Presentacion, IdCategoria = @IdCategoria, Stock = @Stock
	WHERE Id_Producto = @Id_Producto
END;
GO
/****** Object:  StoredProcedure [dbo].[spRoles_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spRoles_Delete]
(@Id_Roles INT)
AS
DECLARE @Rol VARCHAR(50)
	SELECT @Rol = Nombre FROM Tbl_Roles WHERE @Id_Roles = @Id_Roles
	
 IF @Rol = 'Administrador'
    BEGIN
		PRINT 'No se puede eliminar el rol del administrador'
    END
    ELSE
    BEGIN
		DELETE FROM Tbl_Roles WHERE Id_Roles = @Id_Roles 
    END
GO
/****** Object:  StoredProcedure [dbo].[spRoles_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spRoles_GetAll]
 AS
	SELECT Id_Roles, Nombre, Descripcion, NivelPrivilegios FROM Tbl_Roles
GO
/****** Object:  StoredProcedure [dbo].[spRoles_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spRoles_GetById]
 (@Id_Roles INT)
 AS
	SELECT Id_Roles, Nombre, Descripcion, NivelPrivilegios FROM Tbl_Roles WHERE Id_Roles = @Id_Roles
GO
/****** Object:  StoredProcedure [dbo].[spRoles_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spRoles_Insert]
 (@Nombre NVARCHAR(60), @Descripcion NVARCHAR(90), @NivelPrivilegios INT)
 AS
 IF @Nombre = 'Administrador' OR @NivelPrivilegios = 1
    BEGIN
		PRINT 'Solo puede existir un rol de administrador y de privilegios 1'
    END
    ELSE
    BEGIN
		INSERT INTO Tbl_Roles (Nombre, Descripcion, NivelPrivilegios)
		VALUES (@Nombre, @Descripcion, @NivelPrivilegios)
    END
GO
/****** Object:  StoredProcedure [dbo].[spRoles_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[spRoles_Update]
 (@Id_Roles INT, @Nombre NVARCHAR(60), @Descripcion NVARCHAR(90), @NivelPrivilegios INT)
 AS
	IF @Id_Roles = 1 OR @NivelPrivilegios = 1
    BEGIN
		PRINT 'No se puede editar el administrador, tampoco establecer otro nivel de privilegios 1'
    END
    ELSE
    BEGIN
	UPDATE Tbl_Roles SET Nombre = @Nombre, Descripcion = @Descripcion,
	NivelPrivilegios = @NivelPrivilegios WHERE Id_Roles = @Id_Roles
	END
GO
/****** Object:  StoredProcedure [dbo].[spUsuario_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUsuario_Delete]
(@Id_Usuario INT)
AS
	DECLARE @Rol VARCHAR(50)
	SELECT @Rol = Rol.Nombre FROM Tbl_Usuario U INNER JOIN Tbl_Roles Rol ON U.Id_Roles = Rol.Id_Roles WHERE Id_Usuario = @Id_Usuario
	
	IF @Rol = 'Administrador'
    BEGIN
		PRINT 'No se puede eliminar este administrador'
    END
    ELSE
    BEGIN
		DELETE FROM Tbl_Usuario WHERE Id_Usuario = @Id_Usuario
    END
GO
/****** Object:  StoredProcedure [dbo].[spUsuario_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[spUsuario_GetAll]
 AS
	SELECT U.Id_Usuario, U.Nombre, U.Edad, U.Contacto, U.Id_Roles, rol.Nombre FROM Tbl_Usuario U 
	INNER JOIN Tbl_Roles rol ON U.Id_Roles = Rol.Id_Roles 
GO
/****** Object:  StoredProcedure [dbo].[spUsuario_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUsuario_GetById]
 (@Id_Usuario INT)
 AS
	SELECT U.Id_Usuario, U.Nombre, U.Edad, U.Contacto, U.Id_Roles, rol.Nombre FROM Tbl_Usuario U 
	INNER JOIN Tbl_Roles rol ON U.Id_Roles = Rol.Id_Roles WHERE U.Id_Usuario = @Id_Usuario
GO
/****** Object:  StoredProcedure [dbo].[spUsuario_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spUsuario_Insert]
 (@Nombre NVARCHAR(60), @Edad INT, @Contacto NVARCHAR(60), @Id_Roles INT)
 AS
	INSERT INTO Tbl_Usuario (Nombre, Edad, Contacto, Id_Roles)
	VALUES (@Nombre, @Edad, @Contacto, @Id_Roles)
GO
/****** Object:  StoredProcedure [dbo].[spUsuario_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[spUsuario_Update]
 (@Id_Usuario INT, @Nombre NVARCHAR(60), @Edad INT, @Contacto NVARCHAR(60), @Id_Roles INT)
 AS
	UPDATE Tbl_Usuario SET Nombre = @Nombre, Edad = @Edad, Contacto = @Contacto,
	Id_Roles = @Id_Roles WHERE Id_Usuario = @Id_Usuario
GO
/****** Object:  StoredProcedure [dbo].[spVentas_Delete]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVentas_Delete]
(@Id_Venta INT)
AS
BEGIN
	
	DELETE FROM Tbl_Ventas WHERE Id_Venta = @Id_Venta
END;
GO
/****** Object:  StoredProcedure [dbo].[spVentas_GetAll]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVentas_GetAll]
AS
BEGIN
    SELECT Id_Venta, dFecha, Cliente, Encargado, Total_Venta FROM Tbl_Ventas
END;
GO
/****** Object:  StoredProcedure [dbo].[spVentas_GetById]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVentas_GetById]
(@Id_Venta INT)
AS
BEGIN
	SELECT Id_Venta, dFecha, Cliente, Encargado, Total_Venta FROM Tbl_Ventas WHERE Id_Venta = @Id_Venta 
END;
GO
/****** Object:  StoredProcedure [dbo].[spVentas_Insert]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[INSERT]---
CREATE PROCEDURE [dbo].[spVentas_Insert]
(@dFecha DATETIME, @Cliente VARCHAR(50), @Encargado VARCHAR(50))
AS
BEGIN
	INSERT INTO Tbl_Ventas VALUES(@dFecha, @Cliente, @Encargado, 0)
END;
GO
/****** Object:  StoredProcedure [dbo].[spVentas_Update]    Script Date: 23/5/2024 12:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[UPDATE]---
CREATE PROCEDURE [dbo].[spVentas_Update] 
(@Id_Venta INT, @dFecha DATETIME, @Cliente VARCHAR(50), @Encargado VARCHAR(50))
AS
BEGIN
	UPDATE Tbl_Ventas SET
	dFecha = @dFecha, Cliente = @Cliente, Encargado = @Encargado
	WHERE Id_Venta = @Id_Venta
END;
GO

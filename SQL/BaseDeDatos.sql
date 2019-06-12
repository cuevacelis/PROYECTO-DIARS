USE [master]
GO
/** Object:  Database [DBHotelDelRey]    Script Date: 11/06/2019 16:08:21 **/
CREATE DATABASE [DBHotelDelRey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBHotelDelRey', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBHotelDelRey.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBHotelDelRey_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBHotelDelRey_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBHotelDelRey] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBHotelDelRey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBHotelDelRey] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBHotelDelRey] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBHotelDelRey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBHotelDelRey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBHotelDelRey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBHotelDelRey] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBHotelDelRey] SET  MULTI_USER 
GO
ALTER DATABASE [DBHotelDelRey] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBHotelDelRey] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBHotelDelRey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBHotelDelRey] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBHotelDelRey]
GO
/** Object:  StoredProcedure [dbo].[spBuscarCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[spBuscarCliente](
@prmintidCliente int
)
	
AS
BEGIN


	SELECT C.IdCliente, C.NombreCliente, C.ApellidoCliente, C.Dni,
	C.Telefono, C.EstCliente, C.IdTipoCliente
	FROM Cliente C
	INNER JOIN TipoCliente TC ON TC.IdTipoCliente = C.IdTipoCliente
	where C.IdCliente=@prmintidCliente
	ORDER BY C.IdCliente
	
END
GO
/** Object:  StoredProcedure [dbo].[spConsultarReservasDisponibles]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConsultarReservasDisponibles]
(
@prmdateFechaInicio DATETIME,
@prmdateFechaFin DATETIME
)
AS
	SELECT R.IdReserva, R.IdCliente,R.IdHabitacion, C.NombreCliente, C.ApellidoCliente, 
	C.EstCliente,  H.NumeroHabitacion, H.DescHabitacion, 
	TH.DesTipoHabitacion,R.FechaInicioReserva, R.FechaFinReserva,R.EstReserva
	FROM Reserva R
	INNER JOIN Cliente C ON C.IdCliente = R.IdCliente
	INNER JOIN Habitacion H ON H.IdHabitacion = R.IdHabitacion
	INNER JOIN TipoHabitacion TH ON TH.IdTipoHabitacion =h.IdTipoHabitacion
	where (R.FechaInicioReserva>=@prmdateFechaInicio) and (R.FechaFinReserva<=@prmdateFechaFin)
	ORDER BY R.FechaInicioReserva
GO
/** Object:  StoredProcedure [dbo].[spEditarCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[spEditarCliente](
@prmintidCliente int,
@prmstrNombre varchar(50),
@prmstrApellido varchar(50),
@prmIdDni char(8),
@prmIdTelefono int,
@prmbitEstado bit,
@prmIdTipoCliente int
)
	
AS
BEGIN

update Cliente set
NombreCliente=@prmstrNombre,
ApellidoCliente=@prmstrApellido,
Dni=@prmIdDni,
Telefono=@prmIdTelefono,
EstCliente=@prmbitEstado,
IdTipoCliente =@prmIdTipoCliente
where IdCliente=@prmintidCliente

END

GO
/** Object:  StoredProcedure [dbo].[spEliminarCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEliminarCliente] 
(  @prmintidCliente int
   )
AS
BEGIN
	
	update Cliente Set EstCliente = 0 
    where IdCliente=@prmintidCliente
END

GO
/** Object:  StoredProcedure [dbo].[spEliminarReserva]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spEliminarReserva] 
(  @prmintidReserva int
   )
AS
BEGIN
	
	update Reserva Set EstReserva = 0 
    where IdReserva=@prmintidReserva
END

GO
/** Object:  StoredProcedure [dbo].[spInsertarCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spInsertarCliente](
@prmstrNombre varchar(50),
@prmstrApellido varchar(50),
@prmIdDni INT,
@prmIdTelefono INT,
@prmbitEstado bit,
@prmIdTipoCliente INT
)
AS
BEGIN
	INSERT INTO Cliente(NombreCliente,ApellidoCliente,Dni,Telefono,EstCliente,IdTipoCliente)
	VALUES(@prmstrNombre, @prmstrApellido, @prmIdDni, @prmIdTelefono,@prmbitEstado,@prmIdTipoCliente)
END

GO
/** Object:  StoredProcedure [dbo].[spInsertarReserva]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarReserva](
@prmdateFechaInicio DATETIME,
@prmdateFechaFin DATETIME,
@prmIdCliente INT,
@prmIdHabitacion INT
)
AS
BEGIN
	INSERT INTO Reserva(FechaInicioReserva, FechaFinReserva, IdCliente, IdHabitacion,EstReserva)
	VALUES(@prmdateFechaInicio, @prmdateFechaFin, @prmIdCliente, @prmIdHabitacion,1)
END

GO
/** Object:  StoredProcedure [dbo].[spInsertarReservaCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarReservaCliente](
@prmstrNombre varchar(50),
@prmIdTelefono INT,

@prmdateFechaInicio DATETIME,
@prmdateFechaFin DATETIME,
@prmIdCliente INT,
@prmIdHabitacion INT

)
AS
BEGIN

	INSERT INTO Cliente(NombreCliente,ApellidoCliente,Dni,Telefono,EstCliente,IdTipoCliente)
	VALUES(@prmstrNombre,'Falta ingresar', '000000', @prmIdTelefono,1,1)


	INSERT INTO Reserva(FechaInicioReserva, FechaFinReserva, IdCliente, IdHabitacion,EstReserva)
	VALUES(@prmdateFechaInicio, @prmdateFechaFin, @prmIdCliente, @prmIdHabitacion,1)
END
GO
/** Object:  StoredProcedure [dbo].[spListarCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarCliente]
AS
	SELECT C.IdCliente, C.NombreCliente, C.ApellidoCliente, C.Dni,
	C.Telefono, C.EstCliente, C.IdTipoCliente, TC.DesTipoCliente
	FROM Cliente C
	INNER JOIN TipoCliente TC ON TC.IdTipoCliente = C.IdTipoCliente
	where C.EstCliente = 1
	ORDER BY C.IdCliente

GO
/** Object:  StoredProcedure [dbo].[spListarHabitacion]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarHabitacion]
AS
	SELECT H.IdHabitacion, H.NumeroHabitacion, H.DescHabitacion, H.EstHabitacions,
	H.IdTipoHabitacion, TH.DesTipoHabitacion
	FROM Habitacion H
	INNER JOIN TipoHabitacion TH ON TH.IdTipoHabitacion = H.IdTipoHabitacion
	ORDER BY H.IdHabitacion

GO
/** Object:  StoredProcedure [dbo].[spListarReserva]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarReserva]
AS
	SELECT R.IdReserva, R.IdCliente,R.IdHabitacion, C.NombreCliente, C.ApellidoCliente, 
	C.EstCliente,  H.NumeroHabitacion, H.DescHabitacion, 
	TH.DesTipoHabitacion,R.FechaInicioReserva, R.FechaFinReserva,R.EstReserva
	FROM Reserva R
	INNER JOIN Cliente C ON C.IdCliente = R.IdCliente
	INNER JOIN Habitacion H ON H.IdHabitacion = R.IdHabitacion
	INNER JOIN TipoHabitacion TH ON TH.IdTipoHabitacion =h.IdTipoHabitacion
	where R.EstReserva =1
	ORDER BY R.FechaInicioReserva
GO
/** Object:  StoredProcedure [dbo].[spListarTipoCliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarTipoCliente]
AS
	SELECT TP.IdTipoCliente, TP.DesTipoCliente, TP.EstTipoCliente
	FROM TipoCliente TP
	ORDER BY TP.IdTipoCliente

GO
/** Object:  StoredProcedure [dbo].[spListarTipoHabitacion]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarTipoHabitacion]
AS
	SELECT TH.IdTipoHabitacion, TH.DesTipoHabitacion, TH.EstTipoHabitacion
	FROM TipoHabitacion TH
	ORDER BY TH.IdTipoHabitacion

GO
/** Object:  StoredProcedure [dbo].[spVerificarAcceso]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarAcceso](
@prmstrUsuario varchar(50),
@prmstrPassword varchar(50)
)
AS
BEGIN
	SELECT U.idUsuario, U.fecCreacion,U.nomUsuario,U.correo,U.estUsuario,U.tipo,C.NombreCliente,C.ApellidoCliente,C.Dni,C.Telefono,C.EstCliente
	FROM Usuario U
	INNER JOIN Cliente C ON C.IdCliente = U.IdCliente
	where (@prmstrUsuario=u.correo) and (@prmstrPassword=u.contrasenia)

END

GO
/** Object:  Table [dbo].[Cliente]    Script Date: 11/06/2019 16:08:21 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[ApellidoCliente] [varchar](50) NOT NULL,
	[Dni] [char](8) NOT NULL,
	[Telefono] [int] NOT NULL,
	[EstCliente] [bit] NOT NULL,
	[IdTipoCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/** Object:  Table [dbo].[Habitacion]    Script Date: 11/06/2019 16:08:22 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Habitacion](
	[IdHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[NumeroHabitacion] [int] NOT NULL,
	[DescHabitacion] [varchar](50) NOT NULL,
	[EstHabitacions] [bit] NOT NULL,
	[IdTipoHabitacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/** Object:  Table [dbo].[Reserva]    Script Date: 11/06/2019 16:08:22 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdHabitacion] [int] NOT NULL,
	[FechaInicioReserva] [datetime] NOT NULL,
	[FechaFinReserva] [datetime] NOT NULL,
	[EstReserva] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/** Object:  Table [dbo].[TipoCliente]    Script Date: 11/06/2019 16:08:22 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoCliente](
	[IdTipoCliente] [int] IDENTITY(1,1) NOT NULL,
	[DesTipoCliente] [varchar](50) NOT NULL,
	[EstTipoCliente] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/** Object:  Table [dbo].[TipoHabitacion]    Script Date: 11/06/2019 16:08:22 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoHabitacion](
	[IdTipoHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[DesTipoHabitacion] [varchar](50) NOT NULL,
	[EstTipoHabitacion] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/** Object:  Table [dbo].[Usuario]    Script Date: 11/06/2019 16:08:22 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[nomUsuario] [varchar](50) NULL,
	[correo] [varchar](50) NULL,
	[contrasenia] [varchar](50) NULL,
	[estUsuario] [bit] NULL,
	[fecCreacion] [datetime] NULL,
	[tipo] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1, N'Jose', N'Cueva', N'71104419', 957161897, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (2, N'Adrian', N'Alva', N'23456789', 986486461, 1, 2)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (3, N'Gonzalo', N'Martinez', N'65748392', 978645, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (4, N'Dylan', N'Armas', N'74848989', 9875416, 1, 2)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (5, N'Raul', N'Romero', N'6974688 ', 9889676, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (6, N'Pedrito', N'Blas', N'8879214 ', 1799956, 0, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (7, N'Juancito', N'Perales', N'71105598', 48593, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1007, N'Pedrooo', N'Zevallos', N'34432223', 45345345, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1008, N'Kelly', N'Romero', N'19684684', 168468998, 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1011, N'p', N'Falta ingresar', N'000000  ', 15, 0, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1012, N'pp', N'Falta ingresar', N'000000  ', 33334, 0, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCliente], [ApellidoCliente], [Dni], [Telefono], [EstCliente], [IdTipoCliente]) VALUES (1013, N'Zevallos', N'Vargas', N'7116589 ', 111111, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Habitacion] ON 

GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (1, 101, N'Primer Piso', 1, 1)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (3, 102, N'Primer Piso', 1, 1)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (9, 103, N'Primer Piso', 1, 1)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (11, 104, N'Primer Piso', 1, 1)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (12, 105, N'Primer Piso', 1, 1)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (15, 201, N'Segundo Piso', 1, 2)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (16, 202, N'Segundo Piso', 1, 2)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (17, 203, N'Segundo Piso', 1, 2)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (19, 204, N'Segundo Piso', 1, 2)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (20, 205, N'Segundo Piso', 1, 2)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (22, 301, N'Tercer Piso', 1, 3)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (24, 302, N'Tercer Piso', 1, 3)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (25, 303, N'Tercer Piso', 1, 3)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (26, 304, N'Tercer Piso', 1, 3)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (27, 305, N'Tercer Piso', 1, 3)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (28, 401, N'Cuarto Piso', 1, 4)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (29, 402, N'Cuarto Piso', 1, 4)
GO
INSERT [dbo].[Habitacion] ([IdHabitacion], [NumeroHabitacion], [DescHabitacion], [EstHabitacions], [IdTipoHabitacion]) VALUES (30, 501, N'Quinto Piso', 1, 5)
GO
SET IDENTITY_INSERT [dbo].[Habitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1, 1, 1, CAST(0x0000AA4700000000 AS DateTime), CAST(0x0000AA4F00000000 AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (2, 2, 1, CAST(0x0000AA4400000000 AS DateTime), CAST(0x0000AA5300000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1002, 3, 1, CAST(0x0000AA5300000000 AS DateTime), CAST(0x0000AA7200000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1003, 1, 1, CAST(0x0000AA4400000000 AS DateTime), CAST(0x0000AA6400000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1004, 3, 9, CAST(0x0000AA7300000000 AS DateTime), CAST(0x0000AA6400000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1005, 2, 9, CAST(0x0000AA9600000000 AS DateTime), CAST(0x0000AA6400000000 AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1006, 3, 9, CAST(0x0000AA8300000000 AS DateTime), CAST(0x0000AAC300000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1007, 1, 1, CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000A9E800000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1008, 5, 1, CAST(0x0000AA7200000000 AS DateTime), CAST(0x0000AA7A00000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1009, 1, 1, CAST(0x0000AA6400000000 AS DateTime), CAST(0x0000AA6500000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1010, 1, 1, CAST(0x0000AA4400000000 AS DateTime), CAST(0x0000AA4400000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1011, 2, 1, CAST(0x0000AA6500000000 AS DateTime), CAST(0x0000AA6600000000 AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1012, 1007, 9, CAST(0x0000AA7B00000000 AS DateTime), CAST(0x0000AA8200000000 AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1013, 1, 15, CAST(0x0000AA6300000000 AS DateTime), CAST(0x0000AA6400000000 AS DateTime), 1)
GO
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdHabitacion], [FechaInicioReserva], [FechaFinReserva], [EstReserva]) VALUES (1017, 1012, 17, CAST(0x0000AB3300000000 AS DateTime), CAST(0x0000AB3400000000 AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCliente] ON 

GO
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [DesTipoCliente], [EstTipoCliente]) VALUES (1, N'Natural', 1)
GO
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [DesTipoCliente], [EstTipoCliente]) VALUES (2, N'Juridico', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] ON 

GO
INSERT [dbo].[TipoHabitacion] ([IdTipoHabitacion], [DesTipoHabitacion], [EstTipoHabitacion]) VALUES (1, N'Individual', 1)
GO
INSERT [dbo].[TipoHabitacion] ([IdTipoHabitacion], [DesTipoHabitacion], [EstTipoHabitacion]) VALUES (2, N'Doble', 1)
GO
INSERT [dbo].[TipoHabitacion] ([IdTipoHabitacion], [DesTipoHabitacion], [EstTipoHabitacion]) VALUES (3, N'Triple', 1)
GO
INSERT [dbo].[TipoHabitacion] ([IdTipoHabitacion], [DesTipoHabitacion], [EstTipoHabitacion]) VALUES (4, N'Matrimonial', 1)
GO
INSERT [dbo].[TipoHabitacion] ([IdTipoHabitacion], [DesTipoHabitacion], [EstTipoHabitacion]) VALUES (5, N'Suite Junior', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([idUsuario], [idCliente], [nomUsuario], [correo], [contrasenia], [estUsuario], [fecCreacion], [tipo]) VALUES (1, 1, N'jose', N'cuevacelis@hotmail.com', N'12345', 1, CAST(0x0000AA6700000000 AS DateTime), 1)
GO
INSERT [dbo].[Usuario] ([idUsuario], [idCliente], [nomUsuario], [correo], [contrasenia], [estUsuario], [fecCreacion], [tipo]) VALUES (2, 2, N'adrian', N'adrian@gmail.com', N'12345', 1, CAST(0x0000AA6700000000 AS DateTime), 1)
GO
INSERT [dbo].[Usuario] ([idUsuario], [idCliente], [nomUsuario], [correo], [contrasenia], [estUsuario], [fecCreacion], [tipo]) VALUES (3, 3, N'gonzalo', N'gonzalo@hotmail.com', N'12345', 1, CAST(0x0000AA6700000000 AS DateTime), 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [idCliente], [nomUsuario], [correo], [contrasenia], [estUsuario], [fecCreacion], [tipo]) VALUES (4, 4, N'dylan', N'dylan@hotmail.com', N'12345', 1, CAST(0x0000AA6700000000 AS DateTime), 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [idCliente], [nomUsuario], [correo], [contrasenia], [estUsuario], [fecCreacion], [tipo]) VALUES (5, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdTipoCliente])
REFERENCES [dbo].[TipoCliente] ([IdTipoCliente])
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD FOREIGN KEY([IdTipoHabitacion])
REFERENCES [dbo].[TipoHabitacion] ([IdTipoHabitacion])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([IdHabitacion])
REFERENCES [dbo].[Habitacion] ([IdHabitacion])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cliente]
GO
USE [master]
GO
ALTER DATABASE [DBHotelDelRey] SET  READ_WRITE 
GO
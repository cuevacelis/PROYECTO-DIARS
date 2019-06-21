USE [master]
GO
/****** Object:  Database [DBHotelDelRey]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spBuscarCliente]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spConsultarReservasDisponibles]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spEditarCliente]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spEliminarCliente]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spEliminarReserva]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spInsertarCliente]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarCliente](
@prmstrNombres varchar(50),
@prmIdDni INT,
@prmIdTelefono INT,
@prmIdTipoCliente INT,
@prmdateFechaNacimiento datetime
)
AS
BEGIN

	INSERT INTO Persona (Dni,EstPersona,fechaNacimiento,Nombres,RazonSocial,Telefono)
	values(@prmIdDni,1,@prmdateFechaNacimiento,@prmstrNombres,'Persona Natural',@prmIdTelefono)
	SELECT @@IDENTITY AS 'Identity';

	insert into Cliente(IdPersona)
	values(@@IDENTITY)

END

GO
/****** Object:  StoredProcedure [dbo].[spInsertarReserva]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spInsertarReservaCliente]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spListarHabitacion]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spListarPersona]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarPersona]
AS
	SELECT C.IdCliente, C.NombreCliente, C.ApellidoCliente, C.Dni,
	C.Telefono, C.EstCliente, C.IdTipoCliente, TC.DesTipoCliente
	FROM Cliente C
	INNER JOIN TipoCliente TC ON TC.IdTipoCliente = C.IdTipoCliente
	where C.EstCliente = 1
	ORDER BY C.IdCliente

GO
/****** Object:  StoredProcedure [dbo].[spListarReserva]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spListarTipoCliente]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spListarTipoHabitacion]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[spVerificarAcceso]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarAcceso](
@prmstrCorreo varchar(50),
@prmstrPassword varchar(50)
)
AS
BEGIN

	SELECT u.Correo,u.estUsuario,u.fechaCreacion,u.Hash,u.Password,u.Username,p.Nombres,p.Dni,p.RazonSocial,tp.Privilegio
	FROM Usuario U
	INNER JOIN Persona P ON P.IdPersona = U.IdPersona
	INNER JOIN TipoPersona TP ON TP.IdTipoPersona = P.IdTipoPersona
	where (@prmstrCorreo=u.correo) and (@prmstrPassword=u.Password)

END

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  Table [dbo].[Persona]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoPersona] [int] NULL,
	[Nombres] [varchar](50) NULL,
	[Dni] [char](8) NULL,
	[Telefono] [int] NULL,
	[EstPersona] [bit] NULL,
	[RazonSocial] [varchar](50) NULL,
	[fechaNacimiento] [datetime] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NULL,
	[IdHabitacion] [int] NULL,
	[FechaInicioReserva] [datetime] NULL,
	[FechaFinReserva] [datetime] NULL,
	[EstReserva] [bit] NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoHabitacion]    Script Date: 21/06/2019 0:33:12 ******/
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
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[IdTipoPersona] [int] IDENTITY(1,1) NOT NULL,
	[Privilegio] [int] NULL,
	[DesTipoPersona] [varchar](50) NULL,
	[EstTipoPersona] [bit] NULL,
 CONSTRAINT [PK_TipoPersona] PRIMARY KEY CLUSTERED 
(
	[IdTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trabajador](
	[IdTrabajador] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NULL,
	[Ingresos] [float] NULL,
	[Profesion] [varchar](50) NULL,
	[Rol] [varchar](50) NULL,
 CONSTRAINT [PK_Trabajador] PRIMARY KEY CLUSTERED 
(
	[IdTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/06/2019 0:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsusario] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NULL,
	[Username] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Hash] [varchar](50) NULL,
	[estUsuario] [bit] NULL,
	[fechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsusario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([IdCliente], [IdPersona]) VALUES (1, 1)
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
SET IDENTITY_INSERT [dbo].[Persona] ON 

GO
INSERT [dbo].[Persona] ([IdPersona], [IdTipoPersona], [Nombres], [Dni], [Telefono], [EstPersona], [RazonSocial], [fechaNacimiento]) VALUES (1, 1, N'jose', N'444444  ', 4444, 1, N'Persona Natural', CAST(0x0000AA4400000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
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
SET IDENTITY_INSERT [dbo].[TipoPersona] ON 

GO
INSERT [dbo].[TipoPersona] ([IdTipoPersona], [Privilegio], [DesTipoPersona], [EstTipoPersona]) VALUES (1, 1, N'Cliente', 1)
GO
INSERT [dbo].[TipoPersona] ([IdTipoPersona], [Privilegio], [DesTipoPersona], [EstTipoPersona]) VALUES (2, 2, N'Cliente-Registrado', 1)
GO
INSERT [dbo].[TipoPersona] ([IdTipoPersona], [Privilegio], [DesTipoPersona], [EstTipoPersona]) VALUES (3, 3, N'Recepcionista', 1)
GO
INSERT [dbo].[TipoPersona] ([IdTipoPersona], [Privilegio], [DesTipoPersona], [EstTipoPersona]) VALUES (4, 4, N'Gerente', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoPersona] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([IdUsusario], [IdPersona], [Username], [Correo], [Password], [Hash], [estUsuario], [fechaCreacion]) VALUES (1, 1, N'jose', N'cuevacelis@hotmail.com', N'12345', NULL, 1, CAST(0x0000AA4400000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD FOREIGN KEY([IdTipoHabitacion])
REFERENCES [dbo].[TipoHabitacion] ([IdTipoHabitacion])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_TipoPersona] FOREIGN KEY([IdTipoPersona])
REFERENCES [dbo].[TipoPersona] ([IdTipoPersona])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_TipoPersona]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Habitacion] FOREIGN KEY([IdHabitacion])
REFERENCES [dbo].[Habitacion] ([IdHabitacion])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Habitacion]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Persona]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
USE [master]
GO
ALTER DATABASE [DBHotelDelRey] SET  READ_WRITE 
GO

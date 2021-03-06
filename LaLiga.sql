USE [master]
GO
/****** Object:  Database [LaLiga]    Script Date: 21/01/2022 13:04:49 ******/
CREATE DATABASE [LaLiga]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LaLiga', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LaLiga.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LaLiga_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LaLiga_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LaLiga] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LaLiga].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LaLiga] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LaLiga] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LaLiga] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LaLiga] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LaLiga] SET ARITHABORT OFF 
GO
ALTER DATABASE [LaLiga] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LaLiga] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LaLiga] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LaLiga] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LaLiga] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LaLiga] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LaLiga] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LaLiga] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LaLiga] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LaLiga] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LaLiga] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LaLiga] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LaLiga] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LaLiga] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LaLiga] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LaLiga] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LaLiga] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LaLiga] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LaLiga] SET  MULTI_USER 
GO
ALTER DATABASE [LaLiga] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LaLiga] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LaLiga] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LaLiga] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LaLiga] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LaLiga] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LaLiga] SET QUERY_STORE = OFF
GO
USE [LaLiga]
GO
/****** Object:  Table [dbo].[Clubes]    Script Date: 21/01/2022 13:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clubes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Presupuesto] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Clubes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 21/01/2022 13:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NULL,
	[Posicion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JugadoresClubes]    Script Date: 21/01/2022 13:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadoresClubes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idClub] [int] NOT NULL,
	[idJugador] [int] NOT NULL,
	[Salario] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_JugadoresClubes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_Roles]    Script Date: 21/01/2022 13:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](50) NOT NULL,
	[Limite] [int] NULL,
 CONSTRAINT [PK_m_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clubes] ON 

INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (1, N'Real Madrid', CAST(5000000000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (2, N'FC Barcelona', CAST(20000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (3, N'Atletico de Madrid', CAST(100000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (4, N'Valencia', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (5, N'Sevilla', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (6, N'Betis', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (8, N'FC Prueba-modificado', CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (10, N'Rayo Vallecano', CAST(5000000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (11, N'Levante', CAST(100000.00 AS Numeric(18, 2)))
INSERT [dbo].[Clubes] ([id], [Nombre], [Presupuesto]) VALUES (12, N'Real Sociedad', CAST(10000000.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Clubes] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (1, N'Benzema', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Delantero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (3, N'Kross', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Centrocampista')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (4, N'Curtois', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Portero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (5, N'Mendí', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Defensa')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (6, N'Piqué', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Defensa')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (7, N'Jugador prueba-modificado', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Delantero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (8, N'Marcelo', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Defensa')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (9, N'Iñaki Willians', CAST(N'1998-12-31T00:00:00.000' AS DateTime), N'Delantero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (10, N'Oblack', CAST(N'1980-01-01T00:00:00.000' AS DateTime), N'Portero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (11, N'Luis Suarez', NULL, N'Delantero')
INSERT [dbo].[Jugadores] ([id], [Nombre], [FechaNacimiento], [Posicion]) VALUES (12, N'Casemiro', NULL, N'Centrocampista')
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[JugadoresClubes] ON 

INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (1, 1, 1, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (3, 1, 3, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (4, 1, 4, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (5, 1, 5, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (6, 2, 6, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (10, 3, 11, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[JugadoresClubes] ([id], [idClub], [idJugador], [Salario]) VALUES (11, 1, 8, CAST(5000.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[JugadoresClubes] OFF
GO
SET IDENTITY_INSERT [dbo].[m_Roles] ON 

INSERT [dbo].[m_Roles] ([id], [NombreRol], [Limite]) VALUES (1, N'Jugador', 5)
INSERT [dbo].[m_Roles] ([id], [NombreRol], [Limite]) VALUES (2, N'Entrenador', 1)
INSERT [dbo].[m_Roles] ([id], [NombreRol], [Limite]) VALUES (3, N'Canterano', -1)
SET IDENTITY_INSERT [dbo].[m_Roles] OFF
GO
ALTER TABLE [dbo].[Clubes] ADD  CONSTRAINT [DF_Clubes_Presupuesto]  DEFAULT ((0)) FOR [Presupuesto]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Jugadores] FOREIGN KEY([id])
REFERENCES [dbo].[Jugadores] ([id])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Jugadores]
GO
ALTER TABLE [dbo].[JugadoresClubes]  WITH CHECK ADD  CONSTRAINT [FK_JugadoresClubes_Clubes] FOREIGN KEY([idClub])
REFERENCES [dbo].[Clubes] ([id])
GO
ALTER TABLE [dbo].[JugadoresClubes] CHECK CONSTRAINT [FK_JugadoresClubes_Clubes]
GO
ALTER TABLE [dbo].[JugadoresClubes]  WITH CHECK ADD  CONSTRAINT [FK_JugadoresClubes_Jugadores] FOREIGN KEY([idJugador])
REFERENCES [dbo].[Jugadores] ([id])
GO
ALTER TABLE [dbo].[JugadoresClubes] CHECK CONSTRAINT [FK_JugadoresClubes_Jugadores]
GO
USE [master]
GO
ALTER DATABASE [LaLiga] SET  READ_WRITE 
GO

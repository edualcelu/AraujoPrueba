USE [master]
GO
/****** Object:  Database [AraujoDatos]    Script Date: 20/3/2022 22:33:24 ******/
CREATE DATABASE [AraujoDatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AraujoDatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AraujoDatos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AraujoDatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AraujoDatos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AraujoDatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AraujoDatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AraujoDatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AraujoDatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AraujoDatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AraujoDatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [AraujoDatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AraujoDatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AraujoDatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AraujoDatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AraujoDatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AraujoDatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AraujoDatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AraujoDatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AraujoDatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AraujoDatos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AraujoDatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AraujoDatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AraujoDatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AraujoDatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AraujoDatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AraujoDatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AraujoDatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AraujoDatos] SET RECOVERY FULL 
GO
ALTER DATABASE [AraujoDatos] SET  MULTI_USER 
GO
ALTER DATABASE [AraujoDatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AraujoDatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AraujoDatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AraujoDatos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AraujoDatos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AraujoDatos', N'ON'
GO
ALTER DATABASE [AraujoDatos] SET QUERY_STORE = OFF
GO
USE [AraujoDatos]
GO
/****** Object:  Table [dbo].[p_cliente]    Script Date: 20/3/2022 22:33:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[p_cliente](
	[cl_id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cl_identificacion] [varchar](30) NOT NULL,
	[cl_contrasenia] [varchar](30) NOT NULL,
	[cl_estado] [bit] NOT NULL,
	[cl_nombre] [varchar](30) NOT NULL,
	[cl_genero] [varchar](30) NOT NULL,
	[cl_edad] [varchar](3) NOT NULL,
	[cl_direccion] [varchar](50) NULL,
	[cl_telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cl_id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[p_cuentas]    Script Date: 20/3/2022 22:33:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[p_cuentas](
	[cu_numero_cuenta] [varchar](30) NOT NULL,
	[cu_id_cliente] [int] NOT NULL,
	[cu_tipo] [varchar](30) NOT NULL,
	[cu_estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cu_numero_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[p_movimientos]    Script Date: 20/3/2022 22:33:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[p_movimientos](
	[mo_id_movimiento] [int] IDENTITY(1,1) NOT NULL,
	[mo_numero_cuenta] [varchar](30) NOT NULL,
	[mo_fecha] [datetime] NOT NULL,
	[mo_tipo_movimiento] [varchar](30) NOT NULL,
	[mo_saldo_inicial] [money] NOT NULL,
	[mo_movimiento] [money] NOT NULL,
	[mo_saldo_disponible] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mo_id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[p_cliente] ON 
GO
INSERT [dbo].[p_cliente] ([cl_id_cliente], [cl_identificacion], [cl_contrasenia], [cl_estado], [cl_nombre], [cl_genero], [cl_edad], [cl_direccion], [cl_telefono]) VALUES (1, N'1720477346', N'1234', 1, N'Jose Lema', N'Masculino', N'20', N'Otavalo sn y principal', N'098254785')
GO
INSERT [dbo].[p_cliente] ([cl_id_cliente], [cl_identificacion], [cl_contrasenia], [cl_estado], [cl_nombre], [cl_genero], [cl_edad], [cl_direccion], [cl_telefono]) VALUES (2, N'1720477347', N'5678', 1, N'Marianela Montalvo', N'Femenino', N'20', N'Amazonas y NNUU', N'097548965')
GO
INSERT [dbo].[p_cliente] ([cl_id_cliente], [cl_identificacion], [cl_contrasenia], [cl_estado], [cl_nombre], [cl_genero], [cl_edad], [cl_direccion], [cl_telefono]) VALUES (3, N'1720477348', N'1245', 1, N'Juan Osorio', N'Femenino', N'20', N'13 junio y Equinoccial', N'098874587')
GO
SET IDENTITY_INSERT [dbo].[p_cliente] OFF
GO
INSERT [dbo].[p_cuentas] ([cu_numero_cuenta], [cu_id_cliente], [cu_tipo], [cu_estado]) VALUES (N'225487', 2, N'Corriente', 1)
GO
INSERT [dbo].[p_cuentas] ([cu_numero_cuenta], [cu_id_cliente], [cu_tipo], [cu_estado]) VALUES (N'478758', 1, N'Ahorro', 1)
GO
INSERT [dbo].[p_cuentas] ([cu_numero_cuenta], [cu_id_cliente], [cu_tipo], [cu_estado]) VALUES (N'495878', 3, N'Ahorros', 1)
GO
INSERT [dbo].[p_cuentas] ([cu_numero_cuenta], [cu_id_cliente], [cu_tipo], [cu_estado]) VALUES (N'496825', 2, N'Ahorros', 1)
GO
SET IDENTITY_INSERT [dbo].[p_movimientos] ON 
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (1, N'478758', CAST(N'2022-03-20T16:12:15.967' AS DateTime), N'Credito', 0.0000, 2000.0000, 2000.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (2, N'225487', CAST(N'2022-03-20T16:12:15.967' AS DateTime), N'Credito', 0.0000, 100.0000, 100.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (3, N'495878', CAST(N'2022-03-20T16:12:15.967' AS DateTime), N'Credito', 0.0000, 0.0000, 0.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (4, N'496825', CAST(N'2022-03-20T16:12:15.967' AS DateTime), N'Credito', 0.0000, 540.0000, 540.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (6, N'478758', CAST(N'2022-03-20T21:50:16.260' AS DateTime), N'Debito', 2000.0000, -575.0000, 1425.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (7, N'225487', CAST(N'2022-03-20T21:54:42.533' AS DateTime), N'Credito', 0.0000, 1000.0000, 1000.0000)
GO
INSERT [dbo].[p_movimientos] ([mo_id_movimiento], [mo_numero_cuenta], [mo_fecha], [mo_tipo_movimiento], [mo_saldo_inicial], [mo_movimiento], [mo_saldo_disponible]) VALUES (8, N'495878', CAST(N'2022-03-20T22:00:49.773' AS DateTime), N'Credito', 0.0000, 150.0000, 150.0000)
GO
SET IDENTITY_INSERT [dbo].[p_movimientos] OFF
GO
ALTER TABLE [dbo].[p_cuentas]  WITH CHECK ADD FOREIGN KEY([cu_id_cliente])
REFERENCES [dbo].[p_cliente] ([cl_id_cliente])
GO
ALTER TABLE [dbo].[p_movimientos]  WITH CHECK ADD FOREIGN KEY([mo_numero_cuenta])
REFERENCES [dbo].[p_cuentas] ([cu_numero_cuenta])
GO
USE [master]
GO
ALTER DATABASE [AraujoDatos] SET  READ_WRITE 
GO

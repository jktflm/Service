USE [master]
GO
/****** Object:  Database [TransactionServiceDb]    Script Date: 6/21/2024 1:07:32 AM ******/
CREATE DATABASE [TransactionServiceDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransactionServiceDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TransactionServiceDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TransactionServiceDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TransactionServiceDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TransactionServiceDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransactionServiceDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransactionServiceDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransactionServiceDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransactionServiceDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TransactionServiceDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransactionServiceDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TransactionServiceDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET RECOVERY FULL 
GO
ALTER DATABASE [TransactionServiceDb] SET  MULTI_USER 
GO
ALTER DATABASE [TransactionServiceDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransactionServiceDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransactionServiceDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransactionServiceDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TransactionServiceDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TransactionServiceDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TransactionServiceDb', N'ON'
GO
ALTER DATABASE [TransactionServiceDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [TransactionServiceDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TransactionServiceDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/21/2024 1:07:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 6/21/2024 1:07:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNumber] [nvarchar](max) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Symbol] [nvarchar](max) NOT NULL,
	[OrderSide] [nvarchar](max) NOT NULL,
	[OrderStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TransactionServiceDb] SET  READ_WRITE 
GO

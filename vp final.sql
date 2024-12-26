USE [master]
GO

/****** Object:  Database [vp proje]    Script Date: 24-Dec-2024 1:01:27 pm ******/
CREATE DATABASE [vp proje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'vp proje', FILENAME = N'D:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\vp proje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'vp proje_log', FILENAME = N'D:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\vp proje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vp proje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [vp proje] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [vp proje] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [vp proje] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [vp proje] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [vp proje] SET ARITHABORT OFF 
GO

ALTER DATABASE [vp proje] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [vp proje] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [vp proje] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [vp proje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [vp proje] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [vp proje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [vp proje] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [vp proje] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [vp proje] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [vp proje] SET  DISABLE_BROKER 
GO

ALTER DATABASE [vp proje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [vp proje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [vp proje] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [vp proje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [vp proje] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [vp proje] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [vp proje] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [vp proje] SET RECOVERY FULL 
GO

ALTER DATABASE [vp proje] SET  MULTI_USER 
GO

ALTER DATABASE [vp proje] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [vp proje] SET DB_CHAINING OFF 
GO

ALTER DATABASE [vp proje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [vp proje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [vp proje] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [vp proje] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [vp proje] SET QUERY_STORE = ON
GO

ALTER DATABASE [vp proje] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [vp proje] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [snippet_tool]    Script Date: 6/19/2017 10:04:52 AM ******/
CREATE DATABASE [snippet_tool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'snippet_tool', FILENAME = N'C:\Users\epicodus\snippet_tool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'snippet_tool_log', FILENAME = N'C:\Users\epicodus\snippet_tool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [snippet_tool] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [snippet_tool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [snippet_tool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [snippet_tool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [snippet_tool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [snippet_tool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [snippet_tool] SET ARITHABORT OFF 
GO
ALTER DATABASE [snippet_tool] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [snippet_tool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [snippet_tool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [snippet_tool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [snippet_tool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [snippet_tool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [snippet_tool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [snippet_tool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [snippet_tool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [snippet_tool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [snippet_tool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [snippet_tool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [snippet_tool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [snippet_tool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [snippet_tool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [snippet_tool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [snippet_tool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [snippet_tool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [snippet_tool] SET  MULTI_USER 
GO
ALTER DATABASE [snippet_tool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [snippet_tool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [snippet_tool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [snippet_tool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [snippet_tool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [snippet_tool] SET QUERY_STORE = OFF
GO
USE [snippet_tool]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [snippet_tool]
GO
/****** Object:  Table [dbo].[end_user]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[end_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[password] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_end_user_snippet]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_end_user_snippet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_snippet] [int] NULL,
	[id_end_user] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_end_user_tag]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_end_user_tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_end_user] [int] NULL,
	[id_tag] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_favorite]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_favorite](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_tag] [int] NULL,
	[id_end_user] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_snippet_tag]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_snippet_tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_snippet] [int] NULL,
	[id_tag] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[snippet]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[snippet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[image] [varbinary](max) NULL,
	[text] [varchar](max) NULL,
	[timestamp] [timestamp] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tag]    Script Date: 6/19/2017 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](255) NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [snippet_tool] SET  READ_WRITE 
GO

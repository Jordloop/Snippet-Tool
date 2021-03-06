CREATE DATABASE [snippet_tool_test]
GO
USE [snippet_tool_test]
GO
/****** Object:  Table [dbo].[end_users]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[end_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[password] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_end_users_snippets]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_end_users_snippets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_snippet] [int] NULL,
	[id_end_user] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_end_users_tags]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_end_users_tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_end_user] [int] NULL,
	[id_tag] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_favorites]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_favorites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_tag] [int] NULL,
	[id_end_user] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_snippets_tags]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_snippets_tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_snippet] [int] NULL,
	[id_tag] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[snippets]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[snippets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[text] [varchar](max) NULL,
	[time] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tags]    Script Date: 6/20/2017 10:49:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](255) NULL
) ON [PRIMARY]

GO

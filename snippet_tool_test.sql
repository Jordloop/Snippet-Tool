USE [snippet_tool_test]
GO
/****** Object:  Table [dbo].[end_user]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[join_end_user_snippet]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[join_end_user_tag]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[join_favorite]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[join_snippet_tag]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[snippet]    Script Date: 6/19/2017 10:57:36 AM ******/
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
/****** Object:  Table [dbo].[tag]    Script Date: 6/19/2017 10:57:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](255) NULL
) ON [PRIMARY]

GO

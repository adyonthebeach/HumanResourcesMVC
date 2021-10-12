USE [master]
GO

/****** Object:  Database [Accredit]    Script Date: 12/10/2021 16:27:48 ******/
CREATE DATABASE [AccreditHr]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HumanResources', FILENAME = N'C:\Databases\Accredit\AccreditHr.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HumanResources_log', FILENAME = N'C:\Databases\Accredit\AccreditHr_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

USE [AccreditHr]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [AccreditHr]
GO

/****** Object:  Table [dbo].[HumanResource]    Script Date: 12/10/2021 21:54:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [AccreditHr]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReferenceCodes](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [varchar](100) NOT NULL,
	[StatusGroup] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ReferenceCodes] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HumanResource](
	[HumanResourceId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[Department] [varchar](100) NOT NULL,
	[StatusId] [int] NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
 CONSTRAINT [PK_HumanResource] PRIMARY KEY CLUSTERED 
(
	[HumanResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_ReferenceCodes] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ReferenceCodes] ([StatusId])
GO

ALTER TABLE [dbo].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_ReferenceCodes]
GO



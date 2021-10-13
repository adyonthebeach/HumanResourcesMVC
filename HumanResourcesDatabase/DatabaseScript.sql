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

SET IDENTITY_INSERT [dbo].[ReferenceCodes] ON 
GO
INSERT [dbo].[ReferenceCodes] ([StatusId], [StatusDescription], [StatusGroup]) VALUES (1, N'Approved', N'HumanResourceStatus')
GO
INSERT [dbo].[ReferenceCodes] ([StatusId], [StatusDescription], [StatusGroup]) VALUES (2, N'Pending', N'HumanResourceStatus')
GO
INSERT [dbo].[ReferenceCodes] ([StatusId], [StatusDescription], [StatusGroup]) VALUES (3, N'Disabled', N'HumanResourceStatus')
GO
SET IDENTITY_INSERT [dbo].[ReferenceCodes] OFF
GO


CREATE TABLE [dbo].[HumanResource](
	[EmployeeNumber] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[Department] [varchar](100) NOT NULL,
	[StatusId] [int] NOT NULL
 CONSTRAINT [PK_HumanResource] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_ReferenceCodes] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ReferenceCodes] ([StatusId])
GO

ALTER TABLE [dbo].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_ReferenceCodes]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Adrian Walsh
-- Create date: 13/10/2021
-- Description:	
-- =============================================
CREATE PROCEDURE CreateResource 
	-- Add the parameters for the stored procedure here
	@firstname varchar(100),
    @lastname varchar(100),
    @dateOfBirth date,
    @email varchar(200),
    @department varchar(100),
    @status varchar (100)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO HumanResource (FirstName, LastName, DateOfBirth, Email, Department, StatusId)
	VALUES (@firstname, 
			@lastname, 
			@dateOfBirth, 
			@email, 
			@department, 
		(SELECT statusId 
		 FROM ReferenceCodes 
		 WHERE StatusDescription = @status 
			AND StatusGroup = 'HumanResourceStatus'))

	SELECT SCOPE_IDENTITY() EmployeeNumber
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Adrian Walsh
-- Create date: 13/10/2021
-- Description:	
-- =============================================
CREATE PROCEDURE UpdateResource 
	@employeenumber int,
    @firstname varchar(100),
    @lastname varchar(100),
    @dateOfBirth datetime,
    @email varchar(200),
    @department varchar(100),
    @status varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE HumanResource
	SET FirstName = @firstname,
		LastName = @lastname,
		DateOfBirth = @dateOfBirth,
		Email = @email,
		Department = @department,
		StatusId = (SELECT statusId 
					 FROM ReferenceCodes 
					 WHERE StatusDescription = @status 
						AND StatusGroup = 'HumanResourceStatus')
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Adrian Walsh
-- Create date: 13/10/2021
-- Description:	
-- =============================================
CREATE PROCEDURE DeleteResource 
	@employeenumber int
AS
BEGIN
	Delete from HumanResource
	Where EmployeeNumber = @employeenumber
END
GO

USE [BotStore]
GO
/****** Object:  Table [dbo].[AttributeDetails]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeDetails](
	[AttributeDetailID] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentID] [int] NOT NULL,
	[AttributeMasterID] [int] NOT NULL,
	[AttributeValue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AttributeDetails] PRIMARY KEY CLUSTERED 
(
	[AttributeDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotAssignment]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotAssignment](
	[BotAssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[BotID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[TeamID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_BotAssignment] PRIMARY KEY CLUSTERED 
(
	[BotAssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotAttributeMaster]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotAttributeMaster](
	[BotAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[BotID] [int] NOT NULL,
	[AttributeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotAttributeDetails] PRIMARY KEY CLUSTERED 
(
	[BotAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotImageDetails]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotImageDetails](
	[BotImageID] [int] IDENTITY(1,1) NOT NULL,
	[BotImageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotImageDetails] PRIMARY KEY CLUSTERED 
(
	[BotImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotIntendMaster]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotIntendMaster](
	[BotIntendID] [int] IDENTITY(1,1) NOT NULL,
	[BotID] [int] NOT NULL,
	[IntendName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotCustomIntendDetails] PRIMARY KEY CLUSTERED 
(
	[BotIntendID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotMaster]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotMaster](
	[BotID] [int] IDENTITY(1,1) NOT NULL,
	[BotName] [nvarchar](50) NOT NULL,
	[Active] [bit] NULL,
	[ImagePath] [nvarchar](50) NULL,
	[BotImageID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_BotDetails] PRIMARY KEY CLUSTERED 
(
	[BotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BotSkillMaster]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotSkillMaster](
	[BotSkillID] [int] IDENTITY(1,1) NOT NULL,
	[BotID] [int] NOT NULL,
	[SkillName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotSkillDetails] PRIMARY KEY CLUSTERED 
(
	[BotSkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IntendDetails]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntendDetails](
	[IntendDetailID] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentID] [int] NOT NULL,
	[IntendMasterID] [int] NOT NULL,
	[IntendValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_IntendDetails] PRIMARY KEY CLUSTERED 
(
	[IntendDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamDetails]    Script Date: 5/18/2020 1:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamDetails](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[Active] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_TeamDetails] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AttributeDetails]  WITH CHECK ADD  CONSTRAINT [FK_AttributeDetails_BotAssignment] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[BotAssignment] ([BotAssignmentID])
GO
ALTER TABLE [dbo].[AttributeDetails] CHECK CONSTRAINT [FK_AttributeDetails_BotAssignment]
GO
ALTER TABLE [dbo].[AttributeDetails]  WITH CHECK ADD  CONSTRAINT [FK_AttributeDetails_BotAttributeMaster] FOREIGN KEY([AttributeMasterID])
REFERENCES [dbo].[BotAttributeMaster] ([BotAttributeID])
GO
ALTER TABLE [dbo].[AttributeDetails] CHECK CONSTRAINT [FK_AttributeDetails_BotAttributeMaster]
GO
ALTER TABLE [dbo].[BotAssignment]  WITH CHECK ADD  CONSTRAINT [FK_BotAssignment_BotMaster] FOREIGN KEY([BotID])
REFERENCES [dbo].[BotMaster] ([BotID])
GO
ALTER TABLE [dbo].[BotAssignment] CHECK CONSTRAINT [FK_BotAssignment_BotMaster]
GO
ALTER TABLE [dbo].[BotAssignment]  WITH CHECK ADD  CONSTRAINT [FK_BotAssignment_TeamDetails] FOREIGN KEY([TeamID])
REFERENCES [dbo].[TeamDetails] ([TeamID])
GO
ALTER TABLE [dbo].[BotAssignment] CHECK CONSTRAINT [FK_BotAssignment_TeamDetails]
GO
ALTER TABLE [dbo].[BotAttributeMaster]  WITH CHECK ADD  CONSTRAINT [FK_BotAttributeDetails_BotDetails] FOREIGN KEY([BotID])
REFERENCES [dbo].[BotMaster] ([BotID])
GO
ALTER TABLE [dbo].[BotAttributeMaster] CHECK CONSTRAINT [FK_BotAttributeDetails_BotDetails]
GO
ALTER TABLE [dbo].[BotIntendMaster]  WITH CHECK ADD  CONSTRAINT [FK_BotCustomIntendDetails_BotDetails] FOREIGN KEY([BotID])
REFERENCES [dbo].[BotMaster] ([BotID])
GO
ALTER TABLE [dbo].[BotIntendMaster] CHECK CONSTRAINT [FK_BotCustomIntendDetails_BotDetails]
GO
ALTER TABLE [dbo].[BotMaster]  WITH CHECK ADD  CONSTRAINT [FK_BotMaster_BotImageDetails] FOREIGN KEY([BotImageID])
REFERENCES [dbo].[BotImageDetails] ([BotImageID])
GO
ALTER TABLE [dbo].[BotMaster] CHECK CONSTRAINT [FK_BotMaster_BotImageDetails]
GO
ALTER TABLE [dbo].[BotSkillMaster]  WITH CHECK ADD  CONSTRAINT [FK_BotSkillDetails_BotDetails] FOREIGN KEY([BotID])
REFERENCES [dbo].[BotMaster] ([BotID])
GO
ALTER TABLE [dbo].[BotSkillMaster] CHECK CONSTRAINT [FK_BotSkillDetails_BotDetails]
GO

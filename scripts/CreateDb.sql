-- =============================================
-- Author: Travis Boatman
-- Create date: March 17, 2016
-- Last modifed: April 6, 2016
-- =============================================

/****** Object:  Table [dbo].[Accounts]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Hash] [varchar](32) NOT NULL,
	[Salt] [varchar](44) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Complaints]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Complaints](
	[ComplaintId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ConstructionAddress] [varchar](25) NOT NULL,
	[OccupantContactId] [int] NOT NULL,
	[SubContractorContactId] [int] NULL,
	[StatusId] [int] NULL,
	[EmailStatusId] [int] NULL,
	[ComplaintName] [varchar](255) NOT NULL,
	[StorageDirectory] [varchar](50) NULL,
	[Vo] [bit] NULL,
	[SolvedSub] [bit] NULL,
	[SolvedPm] [bit] NULL,
	[SolvedAll] [bit] NULL,
	[Price] [decimal](18, 0) NULL,
	[ActionByNotEc] [varchar](50) NULL,
	[AffirmationInhabitant] [varchar](50) NULL,
	[RemarkArchitect] [int] NULL,
	[RemarkClient] [int] NULL,
	[RemarkEc] [int] NULL,
	[RemarkEngineer] [int] NULL,
	[RemarkExpert] [int] NULL,
	[InternalRemarkEc] [int] NULL,
	[LastUpdated] [date] NULL,
	[ActionDate] [date] NULL,
	[DueDate] [date] NULL,
	[DateCreated] [date] NOT NULL,
	[RowVer] [timestamp] NULL,
PRIMARY KEY CLUSTERED 
(
	[ComplaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Phone] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[EmailStatuses]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailStatuses](
	[EmailStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](255) NOT NULL,
	[ProjectAddress] [varchar](50) NOT NULL,
	[ClientContactId] [int] NOT NULL,
	[ArchitectContactId] [int] NOT NULL,
	[ProjectManagerContactId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Remarks]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remarks](
	[RemarkId] [int] IDENTITY(1,1) NOT NULL,
	[RemarkText] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RemarkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 3/31/2016 2:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[DbVersion] (
    [Version] VARCHAR (128) NOT NULL
)

GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[DbVersion] ([Version]) VALUES (N'3.4')
SET IDENTITY_INSERT [dbo].[EmailStatuses] ON 

INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (1, N'EmailToSubContractor')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (2, N'ProposeDateToOccupant')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (3, N'ConfrimDateToSub')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (4, N'InformOfActionDate')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (5, N'FollowUp')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (6, N'SubNotResponding')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (7, N'OccupantNotResponding')
INSERT [dbo].[EmailStatuses] ([EmailStatusId], [StatusDescription]) VALUES (8, N'OnHold')
SET IDENTITY_INSERT [dbo].[EmailStatuses] OFF
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (1, N'NeedTechnicalCouncil')
INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (2, N'LessValue')
INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (3, N'ActionNeeded')
INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (4, N'Ungrounded')
INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (5, N'Resolved')
INSERT [dbo].[Statuses] ([StatusId], [StatusDescription]) VALUES (6, N'OnHold')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_EmailStatusId] FOREIGN KEY([EmailStatusId])
REFERENCES [dbo].[EmailStatuses] ([EmailStatusId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_EmailStatusId]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_OccupantContactId] FOREIGN KEY([OccupantContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_OccupantContactId]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_ProjectId]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_StatusId]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_SubContractorContactId] FOREIGN KEY([SubContractorContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_SubContractorContactId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ArchitectContactId] FOREIGN KEY([ArchitectContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ArchitectContactId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ClientContactId] FOREIGN KEY([ClientContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ClientContactId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectManagerContactId] FOREIGN KEY([ProjectManagerContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectManagerContactId]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_RemarkArchitect] FOREIGN KEY([RemarkArchitect])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_RemarkArchitect]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_RemarkClient] FOREIGN KEY([RemarkClient])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_RemarkClient]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_RemarkEc] FOREIGN KEY([RemarkEc])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_RemarkEc]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_RemarkEngineer] FOREIGN KEY([RemarkEngineer])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_RemarkEngineer]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_RemarkExpert] FOREIGN KEY([RemarkExpert])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_RemarkExpert]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_InternalRemarkEc] FOREIGN KEY([InternalRemarkEc])
REFERENCES [dbo].[Remarks] ([RemarkId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_InternalRemarkEc]
GO
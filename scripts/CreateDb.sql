-- =============================================
-- Author: Travis Boatman
-- Create date: March 17, 2016
-- Last modifed: March 24, 2016
-- =============================================

/****** Object:  Table [dbo].[Accounts]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](35) NOT NULL,
	[LastName] [nvarchar](35) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[Hash] [varchar](32) NOT NULL,
	[Salt] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Complaints]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complaints](
	[ComplaintId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectDataId] [int] NOT NULL,
	[ComplaintName] [nvarchar](50) NOT NULL,
	[SubContractorContact] [int] NULL,
	[DateCreated] [date] NOT NULL,
	[EmailSentDate] [date] NULL,
	[Status] [int] NULL,
	[Remarks] [text] NULL,
	[CreatedBy] [int] NOT NULL,
	[ClosedBy] [int] NULL,
	[ClosedDate] [date] NULL,
	[AppointmentDate] [date] NULL,
	[DueDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ComplaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConstructionAddresses]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConstructionAddresses](
	[ConstructionAddressId] [int] IDENTITY(1,1) NOT NULL,
	[ConstructionAddress] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConstructionAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Telephone] [varchar](50) NULL,
	[Email] [nvarchar](320) NULL,
	[FirstName] [nvarchar](35) NULL,
	[LastName] [nvarchar](35) NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContactTypes]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactTypes](
	[ContactTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeDescription] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectData]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectData](
	[ProjectDataId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ConstructionAddress] [int] NULL,
	[InhabitantContact] [int] NULL,
	[InhabitantAddress] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](128) NOT NULL,
	[ClientAddress] [int] NULL,
	[ClientContact] [int] NULL,
	[ArchitectContact] [int] NULL,
	[ArchitectAddress] [int] NULL,
	[ProjectManagerContact] [int] NULL,
	[ProjectAddress] [int] NULL,
	[StorageDirectory] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 3/17/2016 5:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusTypes](
	[StatusTypeId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Complaints] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Complaints] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_ClosedBy] FOREIGN KEY([ClosedBy])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_ClosedBy]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_CreatedBy]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_ProjectData] FOREIGN KEY([ProjectDataId])
REFERENCES [dbo].[ProjectData] ([ProjectDataId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_ProjectData]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusTypes] ([StatusTypeId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_Status]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_SubContractorContact] FOREIGN KEY([SubContractorContact])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_SubContractorContact]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[ContactTypes] ([ContactTypeId])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Type]
GO
ALTER TABLE [dbo].[ProjectData]  WITH CHECK ADD  CONSTRAINT [FK_ProjectData_ConstructionAddress] FOREIGN KEY([ConstructionAddress])
REFERENCES [dbo].[ConstructionAddresses] ([ConstructionAddressId])
GO
ALTER TABLE [dbo].[ProjectData] CHECK CONSTRAINT [FK_ProjectData_ConstructionAddress]
GO
ALTER TABLE [dbo].[ProjectData]  WITH CHECK ADD  CONSTRAINT [FK_ProjectData_InhabitantAddress] FOREIGN KEY([InhabitantAddress])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[ProjectData] CHECK CONSTRAINT [FK_ProjectData_InhabitantAddress]
GO
ALTER TABLE [dbo].[ProjectData]  WITH CHECK ADD  CONSTRAINT [FK_ProjectData_InhabitantContact] FOREIGN KEY([InhabitantContact])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[ProjectData] CHECK CONSTRAINT [FK_ProjectData_InhabitantContact]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ArchitectAddress] FOREIGN KEY([ArchitectAddress])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ArchitectAddress]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ArchitectContact] FOREIGN KEY([ArchitectContact])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ArchitectContact]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ClientAddress] FOREIGN KEY([ProjectAddress])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ClientAddress]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ClientContact] FOREIGN KEY([ClientContact])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ClientContact]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectAddress] FOREIGN KEY([ProjectAddress])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectAddress]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectManagerContact] FOREIGN KEY([ProjectManagerContact])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectManagerContact]
GO
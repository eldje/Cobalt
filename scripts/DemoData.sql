INSERT INTO [dbo].[Accounts]
           ([Username]
           ,[Email]
           ,[FirstName]
           ,[LastName]
           ,[Hash]
           ,[Salt])
     VALUES
           ('Hazinge65','LauraPHayes@inbound.plus','Laura','Hayes','DBrg7l7Oa0gIlsNiRg6yThUP2RA=','VJ65asnyKAC5+aPMzh+xWgzpKuJJSFacAGJIfrMdUk4='),
		   ('Knoid1955','NancyJAnderson@inbound.plus','Nancy','Anderson','ubQlvIiqKJ7ctqeokjUhFWJ1k9E=','I6wurRqAL4hh54x5Lyj34aqAwxBfT0HvU9UwruB/Mu8='),
		   ('Nouse1962','RandyIRay@inbound.plus','Randy','Ray','cgtf+nDhViXwYSf6YZRzcFFbuKM=','wqXbqkNDn9MvEGPVdubLxl27BzM4jyBn2FEhhRc1CmE=')
GO

INSERT INTO [dbo].[Contacts]
           ([Street]
           ,[Number]
           ,[Email]
           ,[Phone]
           ,[FirstName]
           ,[LastName])
     VALUES
           ('Williams Avenue','3053','JoanneJHarman@inbound.plus','661-313-7635','Joanne','Harman'),
		   ('Brown Street','2049','AnniePBailey@inbound.plus','925-932-6394','Annie','Bailey'),
		   ('Shinn Avenue','303','LewisSJohnson@inbound.plus','724-562-3684','Lewis','Johnson'),
		   ('Nickel Road','1696','KevinTPittman@inbound.plus','626-668-6960','Kevin','Pittman'),
		   ('Wolf Pen Road','3958','GenevaPJacobson@inbound.plus','650-375-5919','Geneva','Jacobson'),
		   ('Harvest Lane','1980','KeeshaCWhitlock@inbound.plus','661-205-2018','Keesha','Whitlock'),
		   ('Kimberly Way','3088','WilliamSSommerfield@inbound.plus','616-846-0467','William','Sommerfield'),
		   ('Carriage Court','4703','CarloARosner@inbound.plus','760-454-8720','Carlo','Rosner'),
		   ('Todds Lane','3679','OliviaEFournier@inbound.plus','210-530-5281','Olivia','Fournier'),
		   ('Pinewood Drive','4987','ArdithGMast@inbound.plus','847-814-6174','Ardith','Mast')
GO

INSERT INTO [dbo].[Projects]
           ([ProjectName]
           ,[ProjectAddress]
           ,[ClientContactId]
           ,[ArchitectContactId]
           ,[ProjectManagerContactId])
     VALUES
           ('Lake Road Construction','1211 Lake Road', 3, 2, 4),
		   ('Jennifer Lane Renovation','705 Jennifer Lane', 6, 2, 4),
		   ('Alpha Ave Construction','1798 Alpha Avenue', 5, 2, 1)
GO

INSERT INTO [dbo].[ConstructionAddresses]
           ([ConstructionAddress])
     VALUES
           ('A1'),
		   ('A2'),
		   ('A3'),
		   ('A4'),
		   ('A5'),
		   ('B1'),
		   ('B2'),
		   ('B3'),
		   ('B4'),
		   ('B5'),
		   ('C1'),
		   ('C2'),
		   ('C3')
GO

INSERT INTO [dbo].[Remarks]
           ([RemarkText])
     VALUES
           ('Cracks found in the foundation.'),
		   ('Drywall has not been installed yet.'),
		   ('Drywall will be installed next week.'),
		   ('Light fixtures not install yet.'),
		   ('Light fixtures have been delayed for two weeks.'),
		   ('Plumbing must be redone due to new blueprint designs.')
GO

INSERT INTO [dbo].[Complaints]
           ([ProjectId]
           ,[ConstructionAddressId]
           ,[OccupantContactId]
           ,[SubContractorContactId]
           ,[StatusId]
           ,[EmailStatusId]
           ,[ComplaintName]
           ,[StorageDirectory]
           ,[Vo]
           ,[SolvedSub]
           ,[SolvedPm]
           ,[SolvedAll]
           ,[Price]
           ,[ActionByNotEc]
           ,[AffirmationInhabitant]
           ,[RemarkArchitect]
           ,[RemarkClient]
           ,[RemarkEc]
           ,[RemarkEngineer]
           ,[RemarkExpert]
           ,[InternalRemarkEc]
		   ,[ActionDate]
           ,[LastUpdated]
           ,[DueDate]
           ,[DateCreated])
     VALUES
           (1, 1, 7, 8, null, null, 'Foundation Cracks', null, null, null, null, null, 14500, null, null, null, 1, null, null, null, null, null, null, '4/28/2016', GETDATE()),
		   (1, 1, 7, 8, null, null, 'Drywall', null, null, null, null, null, 500, null, null, null, 2, 3, null, null, null, null, null, '4/28/2016', GETDATE()),
		   (2, 4, 9, 10, null, null, 'Light Fixture', null, null, null, null, null, 150, null, null, null, 4, 5, null, null, null, null, null, '4/30/2016', GETDATE()),
		   (2, 4, 9, 10, null, null, 'Plumbing', null, null, null, null, null, 14500, null, null, 6, null, null, null, null, null, null, null, '4/30/2016', GETDATE())
GO
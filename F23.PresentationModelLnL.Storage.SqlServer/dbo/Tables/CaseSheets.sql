CREATE TABLE [dbo].[CaseSheets]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [CaseSheetNumber] VARCHAR (10) NOT NULL,
	[LocationId] INT NOT NULL,
	[VendorId] INT NOT NULL,
	[CaseDate] DATETIME2(2) NOT NULL,
	[IsProcessed] BIT,
    CONSTRAINT [PK_CaseSheets] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_CaseSheets_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id]),
	CONSTRAINT [FK_CaseSheets_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([Id])
)

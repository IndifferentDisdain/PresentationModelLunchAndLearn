CREATE TABLE [dbo].[CaseSheetProducts]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[CaseSheetId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[ProductSku] VARCHAR(20) NOT NULL,
	[ProductDescription] VARCHAR(500) NOT NULL,
	[Quantity] INT NOT NULL,
	[VendorPrice] MONEY NOT NULL,
	[SellingPrice] MONEY NOT NULL,
	CONSTRAINT [PK_CaseSheetProducts] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_CaseSheetProducts_CaseSheets] FOREIGN KEY ([CaseSheetId]) REFERENCES [dbo].[CaseSheets] ([Id]),
	CONSTRAINT [FK_CaseSheetProducts_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
)

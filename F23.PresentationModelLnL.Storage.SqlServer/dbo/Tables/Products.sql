CREATE TABLE [dbo].[Products]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[VendorId] INT NOT NULL,
    [ProductSku] VARCHAR (20) NOT NULL,
	[Description] VARCHAR(500) NOT NULL,
	[VendorPrice] MONEY NOT NULL,
	[SellingPrice] MONEY NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Products_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([Id])
)

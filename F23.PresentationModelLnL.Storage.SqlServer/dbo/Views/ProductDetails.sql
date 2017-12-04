CREATE VIEW [dbo].[ProductDetails]
	AS
SELECT
	p.Id,
	p.VendorId,
	v.Name AS VendorName,
	p.ProductSku,
	p.Description,
	p.VendorPrice,
	p.SellingPrice

FROM Products p
INNER JOIN Vendors v ON v.Id = p.VendorId

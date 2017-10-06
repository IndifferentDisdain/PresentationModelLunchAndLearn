CREATE VIEW [dbo].[VCaseSheetDetails]
	AS 
	SELECT 
		cs.Id,
		cs.CaseSheetNumber,
		cs.LocationId,
		l.Name AS LocationName,
		cs.VendorId,
		v.Name AS VendorName,
		cs.CaseDate,
		0.00 AS TotalCost,
		cs.IsProcessed
	FROM CaseSheets cs
		INNER JOIN Locations l ON l.Id = cs.LocationId
		INNER JOIN Vendors v ON v.Id = cs.VendorId


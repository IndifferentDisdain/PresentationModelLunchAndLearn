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
		csp.TotalCost,
		cs.IsProcessed
	FROM CaseSheets cs
		INNER JOIN Locations l ON l.Id = cs.LocationId
		INNER JOIN Vendors v ON v.Id = cs.VendorId
		INNER JOIN
		(
			SELECT CaseSheetId, SUM(VendorPrice * Quantity) AS TotalCost FROM CaseSheetProducts csp GROUP BY CaseSheetId
		) AS csp ON cs.Id = csp.CaseSheetId


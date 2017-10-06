/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM Locations)
BEGIN
	SET IDENTITY_INSERT Locations ON

	INSERT INTO Locations (Id, Name) VALUES
	(1, 'Joe''s Garage'),
	(2, 'Joe''s Apartment')

	SET IDENTITY_INSERT Locations OFF

END

IF NOT EXISTS (SELECT 1 FROM Vendors)
BEGIN
	SET IDENTITY_INSERT Vendors ON

	INSERT INTO Vendors (Id, Name) VALUES
	(1, 'First Vendor'),
	(2, 'Second Vendor')

	SET IDENTITY_INSERT Vendors OFF

END


IF NOT EXISTS (SELECT 1 FROM CaseSheets)
BEGIN
	SET IDENTITY_INSERT CaseSheets ON

	INSERT INTO CaseSheets (Id, CaseSheetNumber, LocationId, VendorId, CaseDate, IsProcessed) VALUES
	(1, 'CS-1', 1, 1, '2017-10-01', 0),
	(2, 'CS-2', 2, 1, '2017-10-03', 0)

	SET IDENTITY_INSERT CaseSheets OFF

END
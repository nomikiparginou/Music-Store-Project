CREATE PROCEDURE InvStats 
AS 
BEGIN
DECLARE @CreateTable NVARCHAR(30)='Create Table Invoice Statistics'
DECLARE @UpdateTable NVARCHAR(30)='Update Table Invoice Statistics'
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'InvoiceStatistics')
 BEGIN
	  BEGIN TRY
	    BEGIN TRAN @UpdateTable
        	DELETE FROM InvoiceStatistics
		COMMIT TRAN @UpdateTable
	  END TRY
      BEGIN CATCH
	    PRINT 'ERROR NUMBER: -2'
		ROLLBACK TRAN @UpdateTable
	  END CATCH
	  BEGIN TRY
	    BEGIN TRAN @UpdateTable
	     INSERT INTO InvoiceStatistics
	     SELECT Track.GenreId, Track.TrackId, TotalTrackCharge=(InvoiceLine.Quantity*InvoiceLine.UnitPrice), Invoice.InvoiceDate
         FROM Invoice, InvoiceLine, Track
         WHERE InvoiceLine.TrackId = Track.TrackId;
	    COMMIT TRAN @UpdateTable
	  END TRY
	  BEGIN CATCH 
	   PRINT 'ERROR NUMBER: -3'
	   ROLLBACK TRAN @UpdateTable
	  END CATCH
 END 
 ELSE BEGIN 	
   	  BEGIN TRY
	    BEGIN TRAN @Createtable
	       SELECT Track.GenreId, Track.TrackId, TotalTrackCharge=(InvoiceLine.Quantity*InvoiceLine.UnitPrice), Invoice.InvoiceDate
           INTO InvoiceStatistics
           FROM Invoice, InvoiceLine, Track
           WHERE InvoiceLine.TrackId = Track.TrackId;
		COMMIT TRAN @Createtable 
	  END TRY
	  BEGIN CATCH 
	   PRINT 'ERROR NUMBER: -1'
	   ROLLBACK TRAN @Createtable
	  END CATCH         
 END
END

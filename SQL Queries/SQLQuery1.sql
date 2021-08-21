CREATE PROCEDURE [ReportI]
@TopNum INT,
@BeginDate DATETIME,
@EndDate DATETIME	
AS 
BEGIN
SELECT TOP (@TopNum) Artist.Name, SUM(InvoiceLine.Quantity) as Sales
FROM Artist, Album, Track, InvoiceLine, Invoice
WHERE InvoiceDate > (@BeginDate) AND InvoiceDate < (@EndDate) AND 
Invoice.InvoiceId = InvoiceLine.InvoiceId AND
Artist.ArtistId=Album.ArtistId AND
Track.AlbumId = Album.AlbumId AND
InvoiceLine.TrackId = Track.TrackId
GROUP BY Artist.Name
ORDER BY Sales DESC
END
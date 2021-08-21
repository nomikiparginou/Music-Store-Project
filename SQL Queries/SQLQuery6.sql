CREATE PROCEDURE ReportVI
(@Year INT)
AS
BEGIN
SELECT TrackName=Track.Name, ArtistName=Artist.Name, Year=DATEPART(yy,Invoice.InvoiceDate), 
Sales1st = SUM(CASE WHEN DATEPART(q,Invoice.InvoiceDate)=1 THEN InvoiceLine.Quantity ELSE 0 end), 
Sales2nd  = SUM(CASE WHEN DATEPART(q,Invoice.InvoiceDate)=2 THEN InvoiceLine.Quantity  ELSE 0 end),
Sales3rd = SUM(CASE WHEN DATEPART(q,Invoice.InvoiceDate)=3 THEN InvoiceLine.Quantity  ELSE 0 end),
Sales4th = SUM(CASE WHEN DATEPART(q,Invoice.InvoiceDate)=4 THEN InvoiceLine.Quantity ELSE 0 end)
FROM Track, Invoice, InvoiceLine, Album, Artist WHERE 
DATEPART(YY,Invoice.InvoiceDate) = @Year AND
Track.TrackId = InvoiceLine.TrackId AND 
Invoice.InvoiceId = InvoiceLine.InvoiceId AND
Track.AlbumId = Album.AlbumId AND
Album.ArtistId = Artist.ArtistId
GROUP BY Track.Name, Artist.Name, Invoice.InvoiceDate
ORDER BY  Artist.Name ASC, Track.Name ASC
END


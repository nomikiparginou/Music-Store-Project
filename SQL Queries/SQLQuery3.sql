CREATE PROCEDURE [ReportIII]
@TopNum INT
AS 
BEGIN
SELECT TOP(@TopNum) Genre.Name, SUM(InvoiceLine.Quantity) AS TotalSales 
FROM Genre, Track, InvoiceLine
WHERE Genre.GenreId = Track.GenreId and
Track.TrackId = InvoiceLine.TrackId
group by Genre.Name
ORDER BY TotalSales DESC
END
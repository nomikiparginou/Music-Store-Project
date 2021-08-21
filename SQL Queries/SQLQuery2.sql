CREATE PROCEDURE [ReportII]
@BeginDate DATETIME,
@EndDate DATETIME
AS
BEGIN
SELECT TOP 10 Track.Name, SUM(InvoiceLine.Quantity) AS Sales
FROM Track, InvoiceLine, Invoice, Artist, Album
WHERE InvoiceDate > (@BeginDate) AND InvoiceDate < (@EndDate) AND 
Invoice.InvoiceId = InvoiceLine.InvoiceId AND
InvoiceLine.TrackId = Track.TrackId
GROUP BY Track.Name
ORDER BY Sales DESC
END
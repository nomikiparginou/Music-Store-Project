CREATE PROCEDURE [ReportIV]
@BeginDate DATE, @EndDate DATE
AS
BEGIN
SELECT Customer.CustomerId,FirstName, LastName, Phone, Fax, Email , SUM(Invoice.Total) AS Income FROM Customer, Invoice WHERE 
Customer.CustomerId = Invoice.CustomerId AND
Invoice.InvoiceDate > @BeginDate AND Invoice.InvoiceDate < @EndDate
GROUP BY Customer.CustomerId, FirstName, LastName, Phone, Fax, Email
ORDER BY Income DESC
END
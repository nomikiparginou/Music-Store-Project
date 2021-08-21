CREATE PROCEDURE ReportV 
(@BeginDate DATE, @EndDate DATE, @CustomerFName NVARCHAR(30), @CustomerLName NVARCHAR(30),
@EmployeeFName NVARCHAR(30), @EmployeeLName NVARCHAR(30) )
AS
BEGIN
SELECT Invoice.InvoiceId, InvoiceDate, CustomerFirstName=Customer.FirstName, CustomerLastName=Customer.LastName,EmployeeFirstName=Employee.FirstName, employeeLastName=Employee.LastName
FROM Customer , Invoice , Employee 
WHERE Customer.FirstName = @CustomerFName and
Customer.LastName = @CustomerLName and
Employee.FirstName = @EmployeeFName and
Employee.LastName = @EmployeeLName and
Customer.SupportRepId = Employee.EmployeeId and
Invoice.InvoiceDate >= @BeginDate and Invoice.InvoiceDate <= @EndDate
GROUP BY InvoiceId, InvoiceDate, Customer.FirstName, Customer.LastName, Employee.FirstName, Employee.LastName
END
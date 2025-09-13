-- Create View 1: 
-- Requirement: Use EF Core to query a database view that lists all the reservations with their associated customer and restaurant information.

DROP VIEW view_ReservationDetails;
CREATE VIEW view_ReservationDetails AS
SELECT 
	Rev.ReservationId, Rev. ReservationDate, Rev.PartySize,
	Res.Name, Res.Address,
	Cus.FirstName, Cus.LastName
FROM Reservations Rev
JOIN Restaurants Res ON Res.RestaurantId = Rev.RestaurantId
JOIN Customers Cus ON Cus.CustomerId = Rev.CustomerId;

-- Create View 2:
-- Requirement: Generate a query that retrieves employees with their respective restaurant details from a database view.

CREATE VIEW view_EmployeeDetails AS
SELECT 
	Emp.EmployeeId, Emp.FirstName, Emp.LastName, Emp.Position,
	Res.Name, Res.Address
FROM Employees Emp
JOIN Restaurants Res ON Res.RestaurantId = Emp.RestaurantId;

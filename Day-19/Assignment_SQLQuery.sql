-- Stored Procedure to Retrieve Books by Author
CREATE PROCEDURE proc_AuthorBook
    @authorFirstName VARCHAR(20)
AS
BEGIN
    SELECT t.title, p.pub_name
    FROM authors AS a
    JOIN titleauthor AS ta ON a.au_id = ta.au_id
    JOIN titles AS t ON ta.title_id = t.title_id 
    JOIN publishers AS p ON t.pub_id = p.pub_id
    WHERE a.au_fname = @authorFirstName;
END
GO

-- Stored Procedure to Retrieve Titles Sold by Employee
CREATE PROCEDURE proc_EmpDetails
    @employeeFirstName VARCHAR(20)
AS
BEGIN
    SELECT t.title, t.price, s.qty, (t.price * s.qty) AS cost
    FROM employee AS e
    JOIN titles AS t ON e.pub_id = t.pub_id
    JOIN sales AS s ON t.title_id = s.title_id
    WHERE e.fname = @employeeFirstName;
END
GO

-- Query to Retrieve Names from Authors and Employees
SELECT au_fname AS name
FROM authors
UNION
SELECT fname AS name
FROM employee;
GO

-- Query to Retrieve Book, Publisher, Author, Quantity, and Price of Orders
SELECT TOP 5
    t.title AS Booktitle,
    p.pub_name,
    CONCAT(a.au_fname, ' ', a.au_lname) AS Authorname,
    s.qty,
    t.price * s.qty AS TotalPrice
FROM sales AS s
JOIN titles AS t ON s.title_id = t.title_id
JOIN publishers AS p ON t.pub_id = p.pub_id
JOIN titleauthor AS ta ON t.title_id = ta.title_id
JOIN authors AS a ON ta.au_id = a.au_id
ORDER BY t.price;

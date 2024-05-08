-- 1. Create a stored procedure that will take the author firstname and print all the books pulished by him with the publisher's name
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

EXEC proc_AuthorBook 'Albert'

-- 2. Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
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

exec proc_EmpDetails 'Paolo'

-- 3. Create a query that will print all names from authors and employees
SELECT au_fname AS name
FROM authors
UNION
SELECT fname AS name
FROM employee;


/* 4. Create a  query that will float the data from sales, titles, publisher and authors table to print title name, Publisher's name, 
   author's full name with quantity ordered and price for the order for all orders,
   print first 5 orders after sorting them based on the price of order
*/
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

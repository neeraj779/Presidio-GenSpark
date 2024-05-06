-- 1. Print the store ID and number of orders for each store.
SELECT st.stor_id, COUNT(*) AS "Number of Orders"
FROM stores st 
JOIN sales sl ON st.stor_id = sl.stor_id 
GROUP BY st.stor_id;

-- 2. Print the number of orders for every title.
SELECT s.title_id, t.title, COUNT(*) AS "Number of Orders"
FROM titles t 
JOIN sales s ON s.title_id = t.title_id 
GROUP BY s.title_id, t.title;

-- 3. Print the publisher name and book name.
SELECT p.pub_name AS "Publisher Name", t.title AS "Book Name"
FROM titles t 
JOIN publishers p ON t.pub_id = p.pub_id;

-- 4. Print the full name of each author.
SELECT CONCAT(au_fname, ' ', au_lname) AS "Author Full Name"
FROM authors 
ORDER BY au_fname;

-- 5. Print the price of every book with tax (price + price * 12.36/100).
SELECT title, price AS "Price before Tax", (price + (price * (12.36/100))) AS "Price with Tax"
FROM titles;

-- 6. Print the author name and title name.
SELECT t.title, CONCAT(au_fname, ' ', au_lname) AS "Author Name"
FROM authors a 
JOIN titleauthor ta ON a.au_id = ta.au_id 
JOIN titles t ON t.title_id = ta.title_id;

-- 7. Print the author name, title name, and publisher name.
SELECT CONCAT(au_fname, ' ', au_lname) AS "Author Name", t.title, p.pub_name
FROM authors a 
JOIN titleauthor ta ON a.au_id = ta.au_id 
JOIN titles t ON t.title_id = ta.title_id 
JOIN publishers p ON p.pub_id = t.pub_id;

-- 8. Print the average price of books published by each publisher.
SELECT p.pub_name, AVG(t.price) AS "Average Price of Books Published"
FROM publishers p 
JOIN titles t ON t.pub_id = p.pub_id 
GROUP BY p.pub_name;

-- 9. Print the books published by 'Marjorie'.
SELECT t.title, CONCAT(a.au_fname, ' ', a.au_lname) AS "Author Name"
FROM authors a 
JOIN titleauthor ta ON ta.au_id = a.au_id 
JOIN titles t ON t.title_id = ta.title_id 
WHERE CONCAT(a.au_fname, ' ', a.au_lname) LIKE ('%Marjorie%');

-- 10. Print the order numbers of books published by 'New Moon Books'.
SELECT s.ord_num, t.title, p.pub_name
FROM titles t 
JOIN publishers p ON t.pub_id = p.pub_id 
JOIN sales s ON s.title_id = t.title_id 
WHERE p.pub_name = 'New Moon Books';

-- 11. Print the number of orders for every publisher.
SELECT t.pub_id, p.pub_name, COUNT(*) AS "Number of Orders"
FROM titles t 
JOIN publishers p ON t.pub_id = p.pub_id 
JOIN sales s ON s.title_id = t.title_id 
GROUP BY t.pub_id, p.pub_name;

-- 12. Print the order number, book name, quantity, price, and total price for all orders.
SELECT s.ord_num, t.title, s.qty, t.price, (t.price * s.qty) AS "Total Price"
FROM sales s 
JOIN titles t ON s.title_id = t.title_id 
ORDER BY ord_num;

-- 13. Print the total order quantity for every book.
SELECT s.title_id, t.title, SUM(qty) AS "Total Order Quantity"
FROM sales s 
JOIN titles t ON s.title_id = t.title_id 
GROUP BY s.title_id, t.title;

-- 14. Print the total order value for every book.
SELECT s.title_id, t.title, SUM(t.price * s.qty) AS "Total Order Value"
FROM sales s 
JOIN titles t ON s.title_id = t.title_id 
GROUP BY s.title_id, t.title;

-- 15. Print the orders for books published by the publisher for which 'Paolo' works.
SELECT s.ord_num
FROM employee e 
JOIN titles t ON t.pub_id = e.pub_id 
JOIN sales s ON s.title_id = t.title_id 
WHERE CONCAT(e.fname, ' ', e.minit, ' ', e.lname) LIKE ('%Paolo%');

-- Use the 'pubs' database
USE pubs;

-- Print all the titles' names
SELECT title FROM titles;

-- Print all the titles that have been published by '1389'
SELECT title FROM titles
WHERE pub_id = 1389;

-- Print the books that have a price in the range of $10 to $15
SELECT title FROM titles
WHERE price BETWEEN 10 AND 15;

-- Print those books that have no listed price
SELECT title FROM titles
WHERE price IS NULL;

-- Print the book names that start with 'The'
SELECT title FROM titles
WHERE title LIKE 'The%';

-- Print the book names that do not contain the letter 'v'
SELECT title FROM titles
WHERE title NOT LIKE '%v%';

-- Print the books sorted by royalty in descending order
SELECT title FROM titles
ORDER BY royalty DESC;

-- Print the books sorted by publisher in descending order, then by type in ascending order, then by price in descending order
SELECT title FROM titles
ORDER BY pub_id DESC, type ASC, price DESC;

-- Print the average price of books in each type
SELECT type, AVG(price) AS 'Average Price' FROM titles
GROUP BY type;

-- Print all unique types of books
SELECT DISTINCT type FROM titles;

-- Print the first 2 most expensive books
SELECT TOP 2 title, price
FROM titles
ORDER BY price DESC;

-- Print books that are of type 'business', have a price less than $20, and have an advance greater than $7000
SELECT title FROM titles
WHERE type = 'business' AND price < 20 AND advance > 7000;

-- Select the publisher IDs and the number of books which have a price between $15 to $25 and contain 'It' in the title. 
-- Print only those with a count greater than 2. Also, sort the result in ascending order of the count.
SELECT pub_id, COUNT(pub_id) AS 'Number of Books' FROM titles
WHERE price BETWEEN 15 AND 25 AND title LIKE '%It%'
GROUP BY pub_id
HAVING COUNT(pub_id) > 2
ORDER BY COUNT(pub_id);

-- Print the authors who are from 'CA'
SELECT au_fname FROM authors
WHERE state = 'CA';

-- Print the count of authors from every state
SELECT state, COUNT(au_id) AS 'Author Count' FROM authors
GROUP BY state;

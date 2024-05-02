-- Use the NorthWind database
USE NorthWind;

-- Basic selects
SELECT * FROM Products;
SELECT ProductName, QuantityPerUnit FROM Products;
SELECT ProductName AS Name_Of_Product, QuantityPerUnit AS Quantity_Per_Unit FROM Products;
SELECT ProductName AS 'Name Of Product', QuantityPerUnit AS Quantity_Per_Unit FROM Products;

-- Filtering based on conditions
SELECT * FROM Products WHERE UnitPrice > 10;
SELECT * FROM Products WHERE UnitsInStock = 0;
SELECT * FROM Products WHERE Discontinued = 1;
SELECT * FROM Products WHERE Discontinued = 1 AND UnitsInStock > 0;
SELECT * FROM Products WHERE UnitPrice > 10 AND UnitPrice < 30;
SELECT * FROM Products WHERE UnitPrice BETWEEN 10 AND 30;

-- Select with calculated columns
SELECT ProductName, UnitPrice AS Price, UnitsInStock, (UnitPrice * UnitsInStock) AS "Amount worth" FROM Products;
SELECT ProductName, UnitPrice AS Price, UnitsInStock, (UnitPrice * UnitsInStock) AS "Amount worth" FROM Products WHERE CategoryID = 3;

-- Pattern matching
SELECT * FROM Products WHERE QuantityPerUnit LIKE '%boxes%'; -- Any number of characters before and after boxes
SELECT * FROM Products WHERE QuantityPerUnit LIKE '__ Boxes'; -- First two characters are any characters and then Boxes 

-- Aggregation
SELECT SUM(UnitsInStock) AS "Stock of products in category 3" FROM Products WHERE CategoryID = 3;
SELECT AVG(UnitPrice) AS "Average Price" FROM Products WHERE SupplierID = 2;
SELECT SUM(UnitsInStock * ReorderLevel) AS "Expected amount to be paid" FROM Products;
SELECT CategoryId, SUM(UnitsInStock) AS 'Stock Available' FROM Products GROUP BY CategoryId;
SELECT SupplierID, COUNT(ProductName) AS Number_Of_Products, SUM(UnitsInStock) AS 'Items in stock', AVG(UnitPrice) AS 'Average Price' FROM Products GROUP BY SupplierID;

-- Grouping with HAVING clause
SELECT SupplierID, CategoryId, AVG(UnitPrice) AS Average_Price FROM Products GROUP BY CategoryId, SupplierId HAVING AVG(UnitPrice) > 15;

-- Ordering
SELECT CategoryID, COUNT(ProductName) AS 'Count of Products' FROM Products GROUP BY CategoryID HAVING COUNT(ProductName) > 10;
SELECT * FROM Products ORDER BY CategoryID, SupplierID, ProductName;
SELECT * FROM Products ORDER BY ProductName;
SELECT ProductName, UnitPrice FROM Products WHERE UnitPrice > 15 ORDER BY CategoryId;
SELECT * FROM Products WHERE Discontinued = 1 ORDER BY UnitPrice;
SELECT CategoryId, SUM(UnitPrice) AS 'Total Price' FROM Products WHERE Discontinued != 1 GROUP BY CategoryId ORDER BY CategoryId;
SELECT CategoryId, SUM(UnitPrice) AS 'Total Price' FROM Products WHERE Discontinued != 1 GROUP BY CategoryId HAVING SUM(UnitPrice) > 200 ORDER BY 1 DESC;
SELECT * FROM Products ORDER BY UnitPrice DESC;
SELECT ProductName, RANK() OVER (ORDER BY UnitPrice DESC) AS "Price Rank" FROM Products;

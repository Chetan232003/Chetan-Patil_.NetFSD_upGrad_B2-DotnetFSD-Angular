USE ECOMDB;

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes'),
(5,'Accessories');


INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannondale'),
(5,'Scott');

INSERT INTO products VALUES
(1,'Trek Marlin 7',1,1,2023,85000),
(2,'Giant Escape 3',2,2,2022,45000),
(3,'Specialized Turbo',3,3,2023,120000),
(4,'Cannondale Trail',4,1,2022,78000),
(5,'Scott Voltage',5,4,2023,30000);

INSERT INTO customers VALUES
(1,'Rahul','Sharma','Mumbai'),
(2,'Amit','Patil','Pune'),
(3,'Sneha','Kulkarni','Nashik'),
(4,'Rohit','Verma','Mumbai'),
(5,'Priya','Joshi','Pune');

INSERT INTO stores VALUES
(1,'Bike World','Mumbai'),
(2,'Cycle Hub','Pune'),
(3,'Speed Bikes','Nashik'),
(4,'Pro Riders','Delhi'),
(5,'Urban Cycles','Bangalore');



---Retrieve Products with Brand and Category
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

---Customers From Specific City

SELECT *
FROM customers
WHERE city = 'Mumbai';

---Total Products in Each Category
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;
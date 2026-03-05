CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

INSERT INTO customers VALUES
(1,'Rahul','Sharma'),
(2,'Anita','Patil'),
(3,'Vikas','Kumar'),
(4,'Sneha','Joshi'),
(5,'Amit','Patel'),
(6,'Pooja','Desai'),
(7,'Rohit','Verma'),
(8,'Neha','Shah'),
(9,'Karan','Singh'),
(10,'Priya','Nair'),
(11,'Arjun','Reddy'),
(12,'Meera','Iyer'),
(13,'Sanjay','Gupta'),
(14,'Kavita','Kulkarni'),
(15,'Deepak','Yadav');

INSERT INTO orders VALUES
(101,1,'2026-03-01',1),
(102,2,'2026-03-02',4),
(103,3,'2026-03-03',2),
(104,4,'2026-03-04',1),
(105,5,'2026-03-05',4),
(106,6,'2026-03-06',3),
(107,7,'2026-03-07',1),
(108,8,'2026-03-08',4),
(109,9,'2026-03-09',2),
(110,10,'2026-03-10',1),
(111,11,'2026-03-11',4),
(112,12,'2026-03-12',3),
(113,13,'2026-03-13',1),
(114,14,'2026-03-14',4),
(115,15,'2026-03-15',2);

SELECT 
c.first_name,
c.last_name,
o.order_id,
o.order_date,
o.order_status
FROM customers c
INNER JOIN orders o 
ON c.customer_id = o.customer_id
WHERE o.order_status = 1 OR o.order_status = 4
ORDER BY o.order_date DESC;

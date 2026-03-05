CREATE TABLE archived_orders
AS
SELECT * FROM orders
WHERE 1=0;

INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(year,-1,GETDATE());

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(year,-1,GETDATE());

SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) = COUNT(CASE WHEN order_status = 4 THEN 1 END);

SELECT 
order_id,
DATEDIFF(day, order_date, shipped_date) AS processing_delay,
CASE 
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS order_status
FROM orders;
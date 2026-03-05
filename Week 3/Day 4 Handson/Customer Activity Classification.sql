SELECT 
    CONCAT(c.first_name,' ',c.last_name) AS customer_name,
    t.total_value,
    IF(t.total_value > 10000,'Premium',
        IF(t.total_value BETWEEN 5000 AND 10000,'Regular','Basic')
      ) AS customer_type
FROM customers c
LEFT JOIN
(
    SELECT 
        o.customer_id,
        SUM(oi.quantity * oi.list_price) AS total_value
    FROM orders o
    JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t
ON c.customer_id = t.customer_id;
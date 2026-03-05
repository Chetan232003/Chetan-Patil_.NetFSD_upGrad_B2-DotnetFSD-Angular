-- Products sold in stores



SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM orders o
JOIN order_items oi ON o.order_id = oi.order_id
JOIN stores s ON o.store_id = s.store_id
JOIN products p ON oi.product_id = p.product_id
WHERE (o.store_id, oi.product_id) IN
(


    -- Products sold but having zero stock
    SELECT store_id, product_id FROM stocks
    WHERE quantity = 0
)
GROUP BY s.store_name, p.product_name;
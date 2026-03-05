SELECT 
p.product_name,
s.store_name,
st.quantity AS available_stock,
SUM(oi.quantity) AS total_quantity_sold
FROM products p, stores s, stocks st, order_items oi
WHERE p.product_id = st.product_id
AND s.store_id = st.store_id
AND p.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;
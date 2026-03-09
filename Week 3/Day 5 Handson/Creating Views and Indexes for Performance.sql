---View for Product Information

CREATE VIEW vw_ProductDetails AS
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


--CHECK VIEW
SELECT * FROM vw_ProductDetails;

---View for Order Details
CREATE VIEW vw_OrderDetails AS
SELECT 
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name
FROM orders o
JOIN customers c 
ON o.customer_id = c.customer_id
JOIN stores s 
ON o.store_id = s.store_id
JOIN staffs st 
ON o.staff_id = st.staff_id;

---CHECK VIEW
SELECT * FROM vw_OrderDetails;

---Create Index on Foreign Keys
CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);


---Check Execution Plan (Performance Test)

SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT * 
FROM products
WHERE brand_id = 1;


-- 1. Procedure to find total sales of each store


CREATE PROCEDURE store_sales
AS
BEGIN

    SELECT 
        s.store_id,
        s.store_name,
        SUM(oi.quantity * oi.list_price) AS total_sales
    FROM stores s
    JOIN orders o 
        ON s.store_id = o.store_id
    JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY s.store_id, s.store_name

END
GO

-- execute
EXEC store_sales
GO




-- 2. Procedure to get orders between two dates


CREATE PROCEDURE orders_between_dates
    @start DATE,
    @end DATE
AS
BEGIN

    SELECT *
    FROM orders
    WHERE order_date BETWEEN @start AND @end

END
GO

-- example
EXEC orders_between_dates '2016-01-01','2016-12-31'
GO





-- 3. Function to calculate final price after discount


CREATE FUNCTION final_price
(
    @price DECIMAL(10,2),
    @qty INT,
    @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN

    DECLARE @amount DECIMAL(10,2)

    SET @amount = (@price * @qty) - (@price * @qty * ISNULL(@discount,0))

    RETURN @amount

END
GO

-- example
SELECT dbo.final_price(1000,2,0.10)
GO




-- 4. Function to get top 5 selling products

CREATE FUNCTION top5_products()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS sold_qty
    FROM products p
    JOIN order_items oi 
        ON p.product_id = oi.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY sold_qty DESC
)
GO


-- run function
SELECT * FROM dbo.top5_products()
GO
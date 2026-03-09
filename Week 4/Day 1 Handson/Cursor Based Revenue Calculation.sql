-- Cursor to calculate revenue for completed orders 

BEGIN TRY

    BEGIN TRANSACTION

    -- temporary table to store revenue
    CREATE TABLE #store_revenue
    (
        store_id INT,
        order_id INT,
        revenue DECIMAL(10,2)
    )

    DECLARE @order_id INT
    DECLARE @store_id INT
    DECLARE @rev DECIMAL(10,2)

    -- cursor for completed orders
    DECLARE order_cursor CURSOR
    FOR
    SELECT order_id, store_id
    FROM orders
    WHERE order_status = 4


    OPEN order_cursor

    FETCH NEXT FROM order_cursor 
    INTO @order_id, @store_id


    WHILE @@FETCH_STATUS = 0
    BEGIN

        -- calculate revenue for that order
        SELECT @rev =
        SUM(quantity * list_price * (1 - ISNULL(discount,0)))
        FROM order_items
        WHERE order_id = @order_id


        -- store result in temp table
        INSERT INTO #store_revenue
        VALUES(@store_id, @order_id, @rev)


        FETCH NEXT FROM order_cursor
        INTO @order_id, @store_id

    END


    CLOSE order_cursor
    DEALLOCATE order_cursor


    -- display store wise revenue
    SELECT store_id,
           SUM(revenue) AS total_revenue
    FROM #store_revenue
    GROUP BY store_id


    COMMIT TRANSACTION

END TRY


BEGIN CATCH

    ROLLBACK TRANSACTION
    PRINT ERROR_MESSAGE()

END CATCH
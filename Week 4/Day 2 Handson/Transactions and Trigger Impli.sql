/* Trigger: Reduce stock when order_items are inserted */

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN

    -- Check if stock will become negative
    IF EXISTS (
        SELECT 1
        FROM products p
        JOIN inserted i ON p.product_id = i.product_id
        WHERE p.stock_qty < i.quantity
    )
    BEGIN
        -- Stop operation if stock is not enough
        RAISERROR ('Stock not available for this product',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock from products table
    UPDATE p
    SET p.stock_qty = p.stock_qty - i.quantity
    FROM products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END;



/* Transaction to place order and insert order items */

BEGIN TRY

    BEGIN TRANSACTION;

    -- Insert into Orders table
    INSERT INTO orders (customer_id, order_date, order_status)
    VALUES (1, GETDATE(), 1);

    -- Get the newly created order id
    DECLARE @order_id INT;

    SELECT @order_id = SCOPE_IDENTITY();

    -- Insert items for that order
    INSERT INTO order_items (order_id, product_id, quantity)
    VALUES
    (@order_id, 101, 2),
    (@order_id, 102, 1);

    -- If everything is successful
    COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    -- Rollback if any error occurs
    ROLLBACK TRANSACTION;

    PRINT 'Order failed due to stock issue or other error';

END CATCH;
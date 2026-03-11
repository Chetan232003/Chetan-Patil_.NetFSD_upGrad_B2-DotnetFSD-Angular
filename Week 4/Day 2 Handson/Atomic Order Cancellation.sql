/* Cancel order and restore stock using SAVEPOINT */

BEGIN TRY

    BEGIN TRANSACTION;

    DECLARE @order_id INT = 1;

    -- Create savepoint before restoring stock
    SAVE TRANSACTION restore_point;

    /* Restore stock quantities */
    UPDATE p
    SET p.stock_qty = p.stock_qty + oi.quantity
    FROM products p
    JOIN order_items oi
    ON p.product_id = oi.product_id
    WHERE oi.order_id = @order_id;

    /* Update order status to Rejected (3) */
    UPDATE orders
    SET order_status = 3
    WHERE order_id = @order_id;

    -- If all steps succeed
    COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    -- Rollback only to savepoint
    ROLLBACK TRANSACTION restore_point;

    PRINT 'Stock restoration failed. Transaction partially rolled back';

END CATCH;
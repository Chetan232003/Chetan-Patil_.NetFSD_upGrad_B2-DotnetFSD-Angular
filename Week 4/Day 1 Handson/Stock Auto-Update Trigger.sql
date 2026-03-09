/* Trigger to update stock after a new order item is inserted */

CREATE TRIGGER trg_update_stock
ON order_items
AFTER INSERT
AS
BEGIN

    BEGIN TRY

        -- check if ordered quantity is more than available stock
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN stocks s
            ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            -- if stock is not enough stop the transaction
            RAISERROR('Stock not available',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END


        -- reduce stock when order is placed
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id


    END TRY

    BEGIN CATCH

        -- rollback if any error occurs
        ROLLBACK TRANSACTION

        -- show error message
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO
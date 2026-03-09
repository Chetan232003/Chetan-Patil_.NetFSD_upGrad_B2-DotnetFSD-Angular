-- Trigger to check shipped_date when order status becomes Completed 

CREATE TRIGGER trg_check_order_status
ON orders
AFTER UPDATE
AS
BEGIN

    BEGIN TRY

        -- check if order status is set to 4 but shipped_date is NULL
        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 4 
            AND shipped_date IS NULL
        )

        BEGIN
            -- stop update if condition is wrong
            RAISERROR('Shipped date must be provided when order is completed',16,1)

            ROLLBACK TRANSACTION
            RETURN
        END

    END TRY


    BEGIN CATCH

        -- rollback if any error happens
        ROLLBACK TRANSACTION

        PRINT ERROR_MESSAGE()

    END CATCH

END
GO
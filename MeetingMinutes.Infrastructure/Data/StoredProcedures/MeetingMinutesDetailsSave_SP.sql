IF NOT EXISTS (SELECT * FROM sys.types WHERE name = 'MeetingMinutesListType')
BEGIN
    CREATE TYPE dbo.MeetingMinutesListType AS TABLE
    (
        Quantity DECIMAL(18, 2) NULL,
        Unit DECIMAL(18, 2) NULL,
        ProductId INT  NULL,
        MeetingMinutesMasterId INT NULL       
    );
END
GO


CREATE PROCEDURE [dbo].[Meeting_Minutes_Details_Save_SP]
    @MeetingMinutesList dbo.MeetingMinutesListType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Insert new records
        INSERT INTO Meeting_Minutes_Details_Tbl
            (
             Quantity,
             Unit, 
             ProductId, 
             MeetingMinutesMasterId
             )
            SELECT 
            Quantity, 
            Unit, 
            ProductId, 
            MeetingMinutesMasterId

        FROM @MeetingMinutesList

        -- Return the inserted IDs (assuming your details table has an identity column)
        --SELECT SCOPE_IDENTITY() AS Id; -- Returns the last identity value
        
        COMMIT TRANSACTION;
        
        SELECT 'Success' AS Status, 'Bulk operation completed successfully' AS Message;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        SELECT 'Error' AS Status, @ErrorMessage AS Message;
        
        THROW;
    END CATCH
END
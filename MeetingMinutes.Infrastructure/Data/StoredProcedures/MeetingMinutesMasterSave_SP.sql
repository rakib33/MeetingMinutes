---- Step 1: Check if SP exists
--IF NOT EXISTS (SELECT * 
--               FROM sys.objects 
--               WHERE type = 'P' AND name = 'Meeting_Minutes_Master_Save_SP')
--BEGIN
--    -- If not exists, create a dummy SP
--    EXEC('
--    CREATE PROCEDURE dbo.Meeting_Minutes_Master_Save_SP
--    AS
--    BEGIN
--        SET NOCOUNT ON;
--    END
--    ')
--END
--GO

-- Step 2: Alter the SP (works whether it existed or we just created it)
CREATE PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP]
    @Id INT = NULL,
    @MeetingDateTime DATETIME = NULL,
    @MeetingPlace NVARCHAR(250),
    @AttendClientSide NVARCHAR(500),
    @AttendHostSide NVARCHAR(500),
    @MeetingAgenda NVARCHAR(500),
    @MeetingDiscussion NVARCHAR(500),
    @MeetingDecision NVARCHAR(500),
    @CorporateCustomerId INT = NULL,
    @IndividualCustomerId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
    -- Example insert logic
    IF @Id IS NULL OR @Id = 0
    BEGIN
        INSERT INTO Meeting_Minutes_Master_Tbl
            (MeetingDateTime, MeetingPlace, AttendClientSide, AttendHostSide,
             MeetingAgenda, MeetingDiscussion, MeetingDecision, CorporateCustomerId, IndividualCustomerId)
        VALUES
            (@MeetingDateTime, @MeetingPlace, @AttendClientSide, @AttendHostSide,
             @MeetingAgenda, @MeetingDiscussion, @MeetingDecision, @CorporateCustomerId, @IndividualCustomerId);

	    -- Ensure this returns an INT
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;        
    END
	END TRY
	BEGIN CATCH
	  SELECT -1 AS Id;
	END CATCH
END

EXEC [dbo].[Meeting_Minutes_Master_Save_SP] 

    @MeetingDateTime = '2025-08-22 10:30:00',   -- Example datetime
    @MeetingPlace = N'Head Office, Dhaka',
    @AttendClientSide = N'John, Michael',
    @AttendHostSide = N'Sara, David',
    @MeetingAgenda = N'Discuss project deadlines',
    @MeetingDiscussion = N'Project is delayed due to resources',
    @MeetingDecision = N'Add more resources, extend deadline by 2 weeks',
    @CorporateCustomerId = 1,
	@IndividualCustomerId = null;


	DELETE FROM Meeting_Minutes_Master_Tbl;

    -- Reset identity back to 1
    DBCC CHECKIDENT ('Meeting_Minutes_Master_Tbl', RESEED, 0);

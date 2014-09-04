USE phoenix
GO

--Procedure create a new tournament in EventTable
CREATE PROCEDURE CreateNewTournament
@tournamentId uniqueidentifier,
@registrationID uniqueidentifier,
@gameId uniqueidentifier,
@location varchar(50),
@createdById uniqueidentifier,
@tournmentName varchar(50),
@tournamentInfo varchar(4000),
@registrationStartDate datetime,
@registrationEndDate datetime,
@tournamentStartDate datetime,
@tournamentEndDate datetime
AS
BEGIN
	--Tournament
	INSERT INTO EventTable(event_id, created_by_id, parent_id, name, timeCreated, startDate, endDate, event_description,location,typetable_id)
	VALUES(@tournamentId, @createdById, null, @tournmentName, GETDATE(),@registrationStartDate ,@tournamentEndDate,@tournamentInfo,@location ,'77ecf921-425d-46fb-90b1-48c34543e1e0' )
	--Registration
	INSERT INTO EventTable(event_id, created_by_id, parent_id, name, timeCreated, startDate, endDate, event_description,location,typetable_id)
	VALUES(@registrationID, @createdById, @tournamentId, 'Registration', GETDATE(),@registrationStartDate ,@registrationEndDate,null,null,'45e62ce0-81c4-406d-8c84-981a6e59b01e'  )
	--Game
	INSERT INTO EventTable(event_id, created_by_id, parent_id, name, timeCreated, startDate, endDate, event_description,location,typetable_id)
	VALUES(@gameId, @createdById, @tournamentId, 'Game', GETDATE(),@tournamentStartDate ,@tournamentEndDate,null,null, '0546f422-b2c5-403d-bc45-1ca34489537f'  )
END
GO


--Procedure retrieves all future tournaments  
CREATE PROCEDURE GetAllTournaments
AS
BEGIN
	SELECT  ETT.event_id AS tournamentId, 
			ETT.name AS tournamentName, 
			ETT.event_description AS tournamentInfo,
			ETX.RegistrationStartDate as registrationStartDate, 
			ETX.RegistrationEndDate as registrationEndDate, 
			ETX.tournamentStartDate as tournamentStartDate,
			ETX.tournamentEndDate as tournamentEndDate,
			ETT.location AS tournamentLocation
	FROM EventTable ETT
	INNER JOIN 
	(select ETR.parent_id AS parentID, 
			ETR.startDate AS registrationStartDate, 
			ETR.endDate AS registrationEndDate, 
			ETG.startDate AS tournamentStartDate, 
			ETG.endDate AS tournamentEndDate
	from EventTable ETR, EventTable ETG
		where  ETR.typetable_id = '45e62ce0-81c4-406d-8c84-981a6e59b01e' and ETG.typetable_id = '0546f422-b2c5-403d-bc45-1ca34489537f' and ETR.parent_id = ETG.parent_id) ETX ON ETX.parentID = ETT.event_id
		WHERE ETT.typetable_id = '77ecf921-425d-46fb-90b1-48c34543e1e0' -- and ETX.tournamentEndDate >= GETDATE()
END
GO

CREATE PROCEDURE GetTournamentById
@tournamentId uniqueidentifier
AS
BEGIN
	SELECT  ETT.event_id AS tournamentId, 
			ETT.name AS tournamentName, 
			ETT.event_description AS tournamentInfo,
			ETX.RegistrationStartDate as registrationStartDate, 
			ETX.RegistrationEndDate as registrationEndDate, 
			ETX.tournamentStartDate as tournamentStartDate,
			ETX.tournamentEndDate as tournamentEndDate,
			ETT.location AS tournamentLocation
	FROM EventTable ETT
	INNER JOIN 
	(select ETR.parent_id AS parentID, 
			ETR.startDate AS registrationStartDate, 
			ETR.endDate AS registrationEndDate, 
			ETG.startDate AS tournamentStartDate, 
			ETG.endDate AS tournamentEndDate
	from EventTable ETR, EventTable ETG
	where  ETR.typetable_id = '45e62ce0-81c4-406d-8c84-981a6e59b01e' and ETG.typetable_id = '0546f422-b2c5-403d-bc45-1ca34489537f' and ETR.parent_id = ETG.parent_id) ETX ON ETX.parentID = ETT.event_id
		WHERE ETT.typetable_id = '77ecf921-425d-46fb-90b1-48c34543e1e0' and ETT.event_id = @tournamentId
END
GO


CREATE PROCEDURE UpdateTournamentByID
@tournamentID uniqueidentifier,
@tournamentName varchar(50),
@tournamentInfo varchar(4000),
@location varchar(50),
@registrationStartDate datetime,
@registrationEndDate datetime,
@tournamentStartDate datetime,
@tournamentEndDate datetime
AS
BEGIN
	UPDATE EventTable
	SET  
	name = @tournamentName,
	event_description = @tournamentInfo,
	location = @location,
	startDate = @registrationStartDate,
	endDate = @tournamentEndDate
	WHERE event_id = @tournamentID
	
	UPDATE EventTable
	SET
	startDate = @registrationStartDate,
	endDate = @registrationEndDate
	WHERE parent_id = @tournamentID AND typetable_id = '45e62ce0-81c4-406d-8c84-981a6e59b01e'

	UPDATE EventTable
	SET
	startDate = @tournamentStartDate,
	endDate = @tournamentEndDate
	WHERE parent_id = @tournamentID AND typetable_id = '0546f422-b2c5-403d-bc45-1ca34489537f'
END
GO

CREATE PROCEDURE DeleteTournamentByID
@tournamentID uniqueidentifier
AS
BEGIN
	DELETE FROM TeamApplication
	WHERE tournament_id = @tournamentID

	DELETE FROM EventTable
	WHERE parent_id = @tournamentID
	
	DELETE FROM EventTable
	WHERE event_id = @tournamentID
END
GO

CREATE PROCEDURE GetAllTeamApplicationByTournamentID
@tournamentID uniqueidentifier
AS
BEGIN
	Select TA.teamapp_id AS TeamApplicationID,
		 TA.team_name AS TeamName,
		 TA.category AS Category,
		 TA.coach_name AS CoachName,
		 TA.statusfield AS StatusField,
		 TA.team_message AS TeamMessage,
		 TA.submission_date AS SubmissionDate,
		 O.org_name AS OrganizationName
	FROM TeamApplication TA
		INNER JOIN Organization O ON TA.org_id = O.org_id 
	WHERE TA.tournament_id = @tournamentID AND TA.statusfield <> 0
END
GO

CREATE PROCEDURE ApproveOrDenyTeamApplication
@teamApplicationID uniqueidentifier,
@statusField int,
@teamMessage varchar(4000)
AS
BEGIN
	UPDATE TeamApplication
	SET statusfield = @statusField, team_message = @teamMessage
	WHERE teamapp_id = @teamApplicationID
END
GO
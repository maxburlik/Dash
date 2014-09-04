USE phoenix
GO

--Procedure crates new entry in TeamApplication Table
CREATE PROCEDURE CreateNewTeamApplication
@teamapplicationid uniqueidentifier,
@organizationid uniqueidentifier,
@tournamentid uniqueidentifier,
@teamname varchar(50),
@category varchar(20),
@coachname varchar(100)
AS
BEGIN
	INSERT INTO TeamApplication(teamapp_id, org_id, tournament_id, team_name, category, coach_name, statusfield, team_message)
	VALUES(@teamapplicationid, @organizationid, @tournamentid, @teamname, @category, @coachname, 0, null)
END
GO


--Procedure gets existing team applications for the chosen tournaments, under the corresponding logged in organization account
CREATE PROCEDURE GetExistingTeamApplications
@organizationid uniqueidentifier,
@tournamentid uniqueidentifier
AS
BEGIN
	SELECT teamapp_id AS teamappid, org_id AS orgid, tournament_id AS tournamentid, team_name AS teamname, category, coach_name AS coachname, statusfield, team_message AS teammessage
	FROM TeamApplication
	WHERE ((org_id = @organizationid) AND (tournament_id = @tournamentid))
	ORDER BY statusfield DESC, team_name ASC
END
GO

--Procedure retrieves organization id corresponding to the organization user that is logged in
CREATE PROCEDURE GetOrgIdByUserId
@userid varchar(25)
AS
BEGIN
	SELECT org_id AS orgid
	FROM Person
	WHERE Person.person_id in
	(
		SELECT TOP 1 person_id FROM UserAccount WHERE username = @userid
	)
END
GO

--Procedure retrieves all tournaments where the input @datetime is within the registration period
CREATE PROCEDURE [dbo].[GetRegistrationAvailableTournaments]
@inputdate datetime
AS
BEGIN
	SELECT 
			ETT.event_id AS tournamentid,
			ETT.name AS tournamentname,
			ETT.event_description AS tournament_info,
			(SELECT startDate FROM EventTable ET WHERE parent_id = ETT.event_id and typetable_id in(SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentRegistration'))  AS registration_start_date,
			(SELECT endDate FROM EventTable ET WHERE parent_id = ETT.event_id and typetable_id in(SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentRegistration'))  AS registration_end_date,
			ETT.startDate as tournament_start_date,
			ETT.endDate as tournament_end_date
		FROM EventTable ETT
		WHERE ETT.typetable_id in (SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentEvent')
		 AND @inputDate BETWEEN (SELECT startDate FROM EventTable ET WHERE parent_id = ETT.event_id and typetable_id in(SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentRegistration'))
		 AND (SELECT endDate FROM EventTable ET WHERE parent_id = ETT.event_id and typetable_id in(SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentRegistration'))
		
END
GO

--Procedure retrieves tournament called by its unique id
CREATE PROCEDURE GetSelectedTournamentById
@tournamentId uniqueidentifier
AS
BEGIN
	SELECT 	distinct
		ETT.event_id AS tournamentId, 
		ETT.name AS tournamentName, 
		ETT.event_description as tournamentInfo,
		ETR.startDate as registrationStartDate, 
		ETR.endDate as registrationEndDate, 
		ETT.startDate as tournamentStartDate,
		ETT.endDate as tournamentEndDate,
		ETT.location AS tournamentLocation
	FROM EventTable ETT 
		INNER JOIN EventTable ETR ON ETT.event_id = ETR.parent_id
	WHERE 	ETT.event_id = @tournamentId
		AND ETT.typetable_id in (SELECT typetable_id FROM TypeTable WHERE typename = 'TournamentEvent')
		AND ETR.parent_id = ETT.event_id
END
GO

--Procedure updates statusfield from 0 to 1 on selected Team Application to indicate that it has been submitted IF AND ONLY IF there is not already a team with the same name enrolled in the current tournament
CREATE PROCEDURE SubmitTeamApplication
@teamappId uniqueidentifier
AS
BEGIN
	UPDATE TeamApplication
	SET statusfield = 1,
	submission_date = GetDate()
	WHERE	teamapp_id = @teamappId  
		AND statusfield = 0
	--	AND NOT EXISTS 
	--		(SELECT * FROM TeamApplication TA1 
	--			JOIN (SELECT * FROM TeamApplication WHERE teamapp_id = @teamappId) TA2 on TA1.team_name=TA2.team_name
	--		 WHERE TA1.tournament_id = TA2.tournament_id 
	--			AND ((TA1.statusfield BETWEEN 1 and 2) OR (TA2.statusfield BETWEEN 1 and 2)))
END
GO

--Procedure retrieves tournament id using team application id
CREATE PROCEDURE GetTournamentIdByTeamApp
@teamappid uniqueidentifier
AS
BEGIN
	SELECT tournament_id as TournamentID
	FROM TeamApplication
	WHERE teamapp_id = @teamappid
END
GO

--Procedure obtains information for a single team application by its id
CREATE PROCEDURE GetTeamApplication
@teamappid uniqueidentifier
AS
BEGIN
	SELECT teamapp_id AS teamappid, org_id AS orgid, tournament_id AS tournamentid, team_name AS teamname, category, coach_name AS coachname, statusfield, team_message AS teammessage
	FROM TeamApplication
	WHERE teamapp_id = @teamappid
END
GO

--Prodedure edits existing team application info
CREATE PROCEDURE EditTeamApplication
@tournid uniqueidentifier,
@orgid uniqueidentifier,
@teamappid uniqueidentifier,
@teamname varchar(50),
@category varchar(30),
@coachname varchar(100)
AS
BEGIN
	UPDATE TeamApplication
	SET 	team_name = @teamname,
		category = @category,
		coach_name = @coachname
	WHERE 	tournament_id = @tournid 
		AND org_id = @orgid
		AND teamapp_id = @teamappid 
		AND statusfield = 0
END
GO

--Procedure deletes a team application by indexing its id
CREATE PROCEDURE DeleteTeamApplication
@tournid uniqueidentifier,
@orgid uniqueidentifier,
@teamappid uniqueidentifier
AS
BEGIN
	DELETE FROM TeamApplication
	WHERE 	tournament_id = @tournid
		AND org_id = @orgid
		AND teamapp_id = @teamappid 
		AND statusfield <> 2
END
GO
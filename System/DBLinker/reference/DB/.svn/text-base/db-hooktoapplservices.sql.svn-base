USE phoenix
GO

----------------------------------------------------------------
--Tables and Stored Procedures added by Bhupinder
--This table will connect with aspnet_Role (provided by ASP.NET app services) and Roles table
----------------------------------------------------------------
CREATE TABLE RoleAvailableFunctions(
	RoleID uniqueidentifier NOT NULL
		foreign key references Roles(role_id),
	AvailableFunctionID uniqueidentifier NOT NULL references aspnet_Roles(RoleID)
)
GO

CREATE PROCEDURE CreateNewRole
	@roleName varchar(50),
	@roleID uniqueidentifier
AS
INSERT INTO Roles(role_id,role_name) VALUES(@roleID,@roleName)
GO
----------------------------------------------------------------

CREATE PROCEDURE CreateRoleAvailableFunction 
@roleID uniqueidentifier,
@availableFunctionID uniqueidentifier
AS
BEGIN
	INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
	VALUES (@roleID,@availableFunctionID)
END
GO
----------------------------------------------------------------

CREATE PROCEDURE [dbo].[GetAllRoles]
AS
BEGIN
	SELECT R.role_id AS RoleID, R.role_name as RoleName FROM Roles R 
END

GO
----------------------------------------------------------------



CREATE PROCEDURE [dbo].[GetAllAvailableFunctions]
AS
BEGIN
	SELECT RoleId as AvailableFunctionID, RoleName as FunctionName, Description FROM aspnet_Roles
	WHERE RoleId <>  '9C1A8D66-3C71-4EC1-AE23-09D7070F9BB8'
END
GO
----------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetAllAvailableFunctionsForRole]
@roleID uniqueidentifier
AS
BEGIN
	SELECT RAF.AvailableFunctionID as AvailableFunctionID, AF.RoleName AS AvailableFunctionName FROM RoleAvailableFunctions RAF 
			INNER JOIN aspnet_Roles AF
			ON RAF.AvailableFunctionID = AF.RoleId
	WHERE RAF.RoleID = @roleID
END
GO
----------------------------------------------------------------

CREATE PROCEDURE GetRoleByID 
@roleID uniqueidentifier
AS
BEGIN
	SELECT role_name as RoleName FROM Roles	WHERE role_id = @roleID
END
GO
----------------------------------------------------------------

CREATE PROCEDURE CreatePerson
@personID uniqueidentifier,
@addressId uniqueidentifier,
@personType uniqueidentifier,
@email varchar(60),
@firstName varchar(30),
@lastName varchar(30),
@mainphone varchar(30),
@workphone varchar(30),
@org_id uniqueidentifier

AS
BEGIN	
	INSERT INTO Person(address_id,email,firstname,lastname,mainphone,org_id,person_id,person_type_id,workphone)
	VALUES(@addressId,@email,@firstName,@lastName, @mainphone, @org_id, @personID, @personType,@workphone)
END
GO
------------------------------------------------------------------

USE [phoenix]
GO
CREATE PROCEDURE [dbo].[CreateAddress]
@addressId uniqueidentifier,
@streetAddress varchar(100),
@city varchar(50),
@province varchar(50),
@country varchar(50),
@postalCode varchar(10)

AS
BEGIN
	INSERT INTO Address(address_id,city,country,postalcode,province,streetaddress)
	VALUES(@addressId, @city,@country,@postalCode,@province,@streetAddress)
END
GO
------------------------------------------------------------------
CREATE PROCEDURE GetTypeID
@typeName varchar(50)
AS
BEGIN
	SELECT TOP 1 typetable_id FROM TypeTable
	WHERE typename = @typeName
END
GO

------------------------------------------------------------------

CREATE PROCEDURE CreateUserAccount 
@personID uniqueidentifier,
@username varchar(25),
@roleId uniqueidentifier
AS
BEGIN
	INSERT INTO UserAccount(person_id,role_id,username)
	VALUES(@personID,@roleId,@username)
END
GO
------------------------------------------------------------------

CREATE PROCEDURE [dbo].[GetUserAccounts]

AS
BEGIN
	select username, UA.person_id as person_id, role_id, firstname, lastname, mainphone, workphone, email, address_id, org_id, person_type_id  from UserAccount UA with(nolock) inner join Person P on UA.person_id = P.person_id

END
GO
------------------------------------------------------------------

CREATE PROCEDURE GetPerson
@id uniqueidentifier
AS
BEGIN
	SELECT * FROM Person WHERE person_id = @id
END
GO
------------------------------------------------------------------

CREATE PROCEDURE [dbo].[GetTypeName]
@typeID uniqueidentifier
AS
BEGIN
	SELECT TOP 1 typename FROM TypeTable
	WHERE typetable_id = @typeID
END
GO
------------------------------------------------------------------

CREATE PROCEDURE DeleteRole
	@roleid uniqueidentifier
AS
BEGIN

	DELETE FROM RoleAvailableFunctions WHERE RoleID = @roleid
	DELETE FROM Roles WHERE role_id = @roleid
END
GO
-----------------------------------------------------------------
CREATE PROCEDURE NumOfUsersInRole
	@roleid uniqueidentifier
AS
BEGIN
	SELECT COUNT(*) FROM UserAccount WHERE role_id = @roleid

END
GO

------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetUserAccount]
@username varchar(25)
AS
BEGIN
select username, UA.person_id as person_id, role_id, firstname, lastname, mainphone, workphone, email, address_id, org_id, person_type_id  from UserAccount UA with(nolock) inner join Person P on UA.person_id = P.person_id
where username = @username

END
GO

---------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetAddress]
@id uniqueidentifier
AS
BEGIN
	
	SELECT TOP 1 * FROM Address
	WHERE address_id = @id

END

GO
---------------------------------------------------------------------

CREATE PROCEDURE UpdatePerson
@personID uniqueidentifier,
@addressID uniqueidentifier,
@addressProvince varchar(50),
@addressStreet varchar(100),
@addressPostal varchar(50),
@addressCity varchar(50),
@email varchar(60),
@firstName varchar(30),
@lastName varchar(30),
@mainPhone varchar(30),
@workPhone varchar(30)

AS
BEGIN

UPDATE Address
SET 
	province = @addressProvince,
	streetaddress = @addressStreet,
	postalcode = @addressPostal,
	city = @addressCity
WHERE address_id = @addressID


UPDATE Person
SET
	email = @email,
	firstname = @firstName,
	lastname = @lastName,
	mainphone =  @mainPhone,
	workphone = @workPhone
WHERE person_id = @personID
	

END
GO

------------------------------------------------------------------------
CREATE PROCEDURE GetPersonID
@username varchar(25)
AS
BEGIN
	SELECT person_id from UserAccount
	WHERE username = @username
END
GO
------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[UpdateUserAccount]
@username varchar(25),
@roleID uniqueidentifier
AS
BEGIN
	UPDATE UserAccount
	SET role_id = @roleID
	WHERE username = @username
END
GO
-------------------------------------------------------------------------


CREATE PROCEDURE [dbo].[DeleteUserAccount] 
@username varchar(25)
AS
BEGIN
	
	DECLARE @org_id uniqueidentifier;
	DECLARE @role_id uniqueidentifier;
	DECLARE @person_id uniqueidentifier;
	
	SET @person_id = (SELECT person_id FROM UserAccount WHERE username = @username)
	SET @role_id = (SELECT role_id FROM UserAccount WHERE username = @username)
	SET @org_id = (SELECT org_id FROM Person WHERE person_id = @person_id)
	
	SELECT * FROM TeamApplication
	WHERE org_id = @org_id
	
	DELETE FROM UserAccount
	WHERE username = @username
	
	DELETE FROM TeamApplication
	WHERE TeamApplication.org_id = @org_id

END
GO
-------------------------------------------------------------------------
CREATE Procedure GetCoachUnassignedPlayers
	@coach_id uniqueidentifier
	AS
BEGIN
	select * from PlayerApplication inner join Person on PlayerApplication.player_id = Person.person_id
where coach_id is not null and coach_id = @coach_id
and player_id not in
(
	select player_id from TeamPlayersMap
	where PlayerApplication.player_id = player_id
)
END
GO
----------------------------------------------------------------------------

CREATE PROCEDURE CreateOrganizationAuthoriationCode 
	-- Add the parameters for the stored procedure here
	@guid uniqueidentifier 
AS
BEGIN
	INSERT INTO AuthorizationCode(AuthorizationCode,IsUsed)
	VALUES (@guid,0)

END
GO
------------------------------------------------------------------------------

CREATE PROCEDURE CreateTeam
@team_id uniqueidentifier,
@team_name varchar(50),
@category varchar(30),
@coach_id uniqueidentifier
AS
BEGIN
	INSERT INTO Team(team_id,team_name,category,coach_id)
	VALUES (@team_id,@team_name,@category,@coach_id)
END
GO
---------------------------------------------------------------------------


CREATE PROCEDURE GetTeams
@coach_id uniqueidentifier
AS
BEGIN
SELECT * FROM Team
WHERE coach_id = @coach_id
END
GO
--------------------------------------------------------------------------
CREATE PROCEDURE AssignTeamToPlayer
@team_id uniqueidentifier,
@player_id uniqueidentifier,
@coach_id uniqueidentifier
AS
BEGIN
	INSERT INTO TeamPlayersMap(player_id,coach_id,team_id)
	VALUES (@player_id,@coach_id,@team_id)
END
GO
----------------------------------------------------------------------------

CREATE PROCEDURE GetTeamPlayers
@team_id uniqueidentifier
AS
BEGIN
	SELECT player_id FROM TeamPlayersMap
	WHERE team_id = @team_id
	
END
GO
---------------------------------------------------------------------------
CREATE PROCEDURE GetTeamID 
@player_id uniqueidentifier
AS
BEGIN
	SELECT team_id FROM TeamPlayersMap
	WHERE player_id = @player_id
END
GO
---------------------------------------------------------------------------

CREATE PROCEDURE ChangePlayersTeam 
@player_id uniqueidentifier,
@team_id uniqueidentifier
AS
BEGIN
	UPDATE TeamPlayersMap
	SET team_id = @team_id
	WHERE player_id = @player_id
END
GO
----------------------------------------------------------------------------
CREATE PROCEDURE AssignPlayerBackToRegistrar
@player_id uniqueidentifier
AS
BEGIN
	DELETE FROM TeamPlayersMap
	WHERE player_id = @player_id
	
	UPDATE PlayerApplication
	SET coach_id = null
	WHERE player_id = @player_id
END
GO
------------------------------------------------------------------------------
CREATE PROCEDURE UnassignTeamPlayer
@player_id uniqueidentifier
AS
BEGIN
	DELETE TeamPlayersMap
	WHERE player_id = @player_id
END
GO

---------------------------------------------------------------------------

CREATE PROCEDURE GetAllTeams
AS
BEGIN
select P.firstname as FirstName, P.lastname as LastName, T.team_name as TeamName,
T.category as Category, T.team_id


from team T 
			inner join Person P 
						inner join UserAccount UA
					on UA.person_id = P.person_id
			on T.coach_id = P.person_id
WHERE UA.role_id in

(
	select role_id from RoleAvailableFunctions
	where AvailableFunctionID in
	('26ff5349-2fca-472a-b419-dfe1c1835104',
	'3b11dd51-2cd6-4d58-b376-aa1c83a4e69b'
	)
)

END
GO

------------------------------------------------------------------------------
CREATE PROCEDURE GetTeam
@team_id uniqueidentifier
AS
BEGIN
	SELECT * FROM Team
	WHERE team_id = @team_id
END
GO
------------------------------------------------------------------------------

CREATE PROCEDURE GetNumOfPlayersInTeam
@team_id uniqueidentifier
AS
BEGIN
	SELECT COUNT(*) AS Total_Players FROM TeamPlayersMap
	WHERE team_id = @team_id
END
GO
-----------------------------------------------------------------------------

CREATE PROCEDURE DeleteTeam
@team_id uniqueidentifier
AS
BEGIN
	DELETE FROm Team
	WHERE team_id = @team_id
END
GO

-----------------------------------------------------------------------------
CREATE PROCEDURE CreateEvent
@event_id uniqueidentifier,
@created_by_id uniqueidentifier,
@name varchar(50),
@scheduledTime DateTime,
@location varchar(50),
@typetable_id uniqueidentifier,
@event_description varchar(4000)
AS
BEGIN
	INSERT INTO EventTable(event_id,created_by_id,name,timeCreated,event_description, location, typetable_id,parent_id, startDate, endDate)
	VALUES (@event_id, @created_by_id, @name, GETDATE(), @event_description, @location, @typetable_id, null, @scheduledTime, @scheduledTime)
END
GO
------------------------------------------------------------------------------

CREATE PROCEDURE CreateTeamEventMap
@event_id uniqueidentifier,
@team_id uniqueidentifier
AS
BEGIN
	INSERT INTO TeamEventMap(team_id,event_id)
	VALUES (@team_id,@event_id)
END
GO
-------------------------------------------------------------------------------
CREATE PROCEDURE GetCoachEvents
@coachid uniqueidentifier
AS
BEGIN
  select * from EventTable
  where typetable_id = 'BB7E0F1B-7632-4929-A049-4E521D7AC441' and created_by_id = @coachid
END
GO
-------------------------------------------------------------------------------
CREATE PROCEDURE DeleteCoachEvent 
@event_id uniqueidentifier
AS
BEGIN
	DELETE FROM TeamEventMap WHERE event_id = @event_id
	DELETE FROM EventTable WHERE event_id = @event_id
END
GO
-------------------------------------------------------------------------------
CREATE PROCEDURE GetEvent 
@event_id uniqueidentifier
AS
BEGIN
	SELECT * FROM EventTable WHERE event_id = @event_id
END
GO
--------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetTeamEvents]
@team_id uniqueidentifier
AS
BEGIN
  select * from EventTable ET INNER JOIN TeamEventMap TEM ON ET.event_id = TEM.event_id
  where team_id = @team_id
  ORDER BY ET.timeCreated DESC
END
GO
---------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[DeleteAuthorizationCode]
@code varchar(50)
AS 
BEGIN
	DELETE FROM AuthorizationCode
	WHERE SUBSTRING(CAST(AuthorizationCode as Varchar(50)), 25, LEN(AuthorizationCode)) = @code
END
GO

--------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[GetAuthorizationCode]
AS 
BEGIN
        SELECT * FROM AuthorizationCode
	WHERE IsUsed = 0
END
GO
--------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetApprovedTeamApplicationsByTournamentID]
@tournamentID uniqueidentifier
AS
BEGIN
	Select TA.teamapp_id AS TeamApplicationID,
		 TA.team_name AS TeamName,
		 TA.category AS Category,
		 TA.coach_name AS CoachName,
		 TA.statusfield AS StatusField,
		 TA.team_message AS TeamMessage,
		 O.org_name AS OrganizationName
	FROM TeamApplication TA
		INNER JOIN Organization O ON TA.org_id = O.org_id 
	WHERE TA.tournament_id = @tournamentID
	AND TA.statusfield = 2
END
GO
-----------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CreateMatch]
@tournament_id uniqueidentifier,
@teamapp_id_one uniqueidentifier,
@teamapp_id_two uniqueidentifier,
@score_one float,
@score_two float,
@location varchar(50),
@scheduled_date DateTime,
@match_id uniqueidentifier,
@length_of_game int
AS
BEGIN
	INSERT INTO Match(match_id, team1_id, team2_id, score1, score2, tournament_id, location, scheduled_date, length_of_game)
	VALUES (@match_id, @teamapp_id_one, @teamapp_id_two, @score_one, @score_two, @tournament_id,@location, @scheduled_date, @length_of_game)
END
GO
------------------------------------------------------------------------------------

CREATE PROCEDURE GetTournamentMatches 
@tournament_id uniqueidentifier
AS
BEGIN
	SELECT * FROM Match
	WHERE tournament_id = @tournament_id
	ORDER BY scheduled_date ASC
END
GO
------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UpdateMatch]
@teamapp_id_one uniqueidentifier,
@teamapp_id_two uniqueidentifier,
@score_one float,
@score_two float,
@location varchar(50),
@scheduled_date DateTime,
@match_id uniqueidentifier,
@length_of_game int
AS
BEGIN
	UPDATE Match
	SET team1_id = @teamapp_id_one,
		team2_id = @teamapp_id_two,
		score1 = @score_one,
		score2 = @score_two,
		location = @location,
		scheduled_date = @scheduled_date,
		length_of_game = @length_of_game
	WHERE match_id = @match_id
END
GO
-------------------------------------------------------------------------------------
CREATE PROCEDURE DeleteMatch 
@match_id uniqueidentifier
AS
BEGIN
	DELETE FROM Match
	WHERE match_id = @match_id
END
GO

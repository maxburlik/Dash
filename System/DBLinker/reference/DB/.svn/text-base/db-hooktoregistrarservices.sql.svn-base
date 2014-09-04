USE phoenix
GO

----------------------------------------------------------------
--Stored Procedures added by Eddie
--This table will connect with Person table
----------------------------------------------------------------

CREATE PROCEDURE GetAllPlayerApplicationsForRegistrar
AS
BEGIN
	SELECT P.firstname as FirstName,
			P.lastname as LastName,
			P.person_id as PersonID,
			PA.birthdate as BirthDate,
			PA.registrationDate as RegistrationDate,
			PA.paid as Paid,
			PA.playerapp_id as PlayerAppID,
			PA.coach_id as CoachID
	FROM PlayerApplication PA 
			INNER JOIN Person P  ON P.person_id = PA.player_id
			INNER JOIN TypeTable TT ON P.person_type_id = TT.typetable_id
	WHERE TT.typename = 'Player' and PA.endDate is null
END
GO

----------------------------------------------------------------
CREATE PROCEDURE GetPlayerApplicationByID
@playerAppID uniqueidentifier
AS
BEGIN
	SELECT *
	FROM PlayerApplication PA
	WHERE PA.playerapp_id = @playerAppID
END
GO
----------------------------------------------------------------

CREATE PROCEDURE GetAllCoaches
AS
BEGIN
	SELECT P.person_id As PersonID, P.firstname AS FirstName, P.lastname As LastName
	FROM Person P
			INNER JOIN UserAccount UA ON P.person_id = UA.person_id
			INNER JOIN Roles R ON  UA.role_id = R.role_id
			INNER JOIN RoleAvailableFunctions RAF ON R.role_id = RAF.RoleID
	WHERE RAF.AvailableFunctionID in('26ff5349-2fca-472a-b419-dfe1c1835104','26ff5349-2fca-472a-b419-dfe1c1835104')
END
GO

----------------------------------------------------------------

CREATE PROCEDURE UpdatePlayer
@playerApplicationID uniqueidentifier,
@bcMedicalNumber varchar(10),
@birthdate datetime,
@gender char,
@medicalNotes varchar(200),
@paid bit,
@payment money,
@previousTeam varchar(50),
@school varchar(50),
@coach_id uniqueidentifier
AS
BEGIN
	UPDATE PlayerApplication
	SET bcMedicalNumber = @bcMedicalNumber,
		birthdate = @birthdate,
		gender = @gender,
		medicalNotes = @medicalNotes,
		paid=@paid,
		payment=@payment,
		previousTeam=@previousTeam,
		school=@school,
		coach_id=@coach_id
	WHERE playerapp_id = @playerApplicationID
END
GO

----------------------------------------------------------------
CREATE PROCEDURE DeactivatePlayer
@playerApplicationID uniqueidentifier
AS
BEGIN
	UPDATE PlayerApplication
	SET endDate = GETDATE()
	WHERE playerapp_id = @playerApplicationID
END
GO
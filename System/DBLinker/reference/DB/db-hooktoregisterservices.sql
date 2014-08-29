USE phoenix
GO

----------------------------------------------------------------
--Stored Procedures added by Eddie
--This table will connect with PlayerApplication Table
----------------------------------------------------------------

CREATE PROCEDURE CreateNewPlayerApplication
@playerApplicationID uniqueidentifier,
	@bcMedicalNumber varchar(10),
@registrationDate datetime,
@endDate datetime,
@birthDate datetime,
@consentApproved bit,
@gender char,
@medicalAlert varchar(200),
@paid bit,
@payment money,
@previousTeam varchar(50),
@school varchar(50),
@playerID uniqueidentifier,
@guardian1ID uniqueidentifier,
@guardian2ID uniqueidentifier
AS
BEGIN
	INSERT INTO PlayerApplication(playerapp_id, bcMedicalNumber, registrationDate, birthdate, consentApproved, gender, medicalNotes, paid, payment, previousTeam, school, player_id, contact1_id, contact2_id, coach_id)
	VALUES(@playerApplicationID ,@bcMedicalNumber,@registrationDate,@birthDate,@consentApproved,@gender,@medicalAlert,@paid,@payment,@previousTeam,@school,@playerID ,@guardian1ID,@guardian2ID, null)
END
GO
----------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[CreateNewOrganization]   ******/

Create PROCEDURE CreateNewOrganization
@organizationID uniqueidentifier,
@org_name varchar(80),
@registration_date datetime,
@phone varchar(30),
@fax varchar(30),
@url varchar(512),
@address_id uniqueidentifier


AS
BEGIN
	INSERT INTO Organization(org_id, org_name, registration_date, phone, fax,url ,address_id)
	VALUES(@organizationID ,@org_name ,@registration_date,@phone,@fax,@url,@address_id)
END
GO
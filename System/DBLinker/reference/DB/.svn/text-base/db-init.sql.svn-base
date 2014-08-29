-- Max Burlik
-- db-init.sql
-- Version 1.0 - Oct. 16, 2010
-- Function: Initializes database and tables

--initializes the database
CREATE DATABASE phoenix

GO

USE phoenix

GO
-- creates tables
-- bits represent booleans false=0, true=1
CREATE TABLE TypeTable (
	typetable_id uniqueidentifier not null
		primary key,
	parenttype_id uniqueidentifier null
		foreign key references TypeTable(typetable_id),
	typename varchar(50) not null,
	type_description varchar(200)
)


CREATE TABLE Address (
	address_id uniqueidentifier  not null
		primary key,
	streetaddress varchar(100),
	city varchar(50),
	province varchar(50),
	country varchar(50),
	postalcode varchar(10)
)

CREATE TABLE Organization (
	org_id uniqueidentifier  not null
		primary key,
	org_name varchar(80) not null,
	registration_date datetime,
	phone varchar(30),
	fax varchar(30),
	url varchar(512),
	address_id uniqueidentifier not null
		foreign key references Address(address_id)
)

CREATE TABLE Person (
	person_id uniqueidentifier  not null
		primary key,
	firstname varchar(30),
	lastname varchar(30),
	mainphone varchar(30),
	workphone varchar(30),
	email varchar(60),
	address_id uniqueidentifier  not null
		foreign key	references Address(address_id),
	org_id uniqueidentifier  -- separate from the mapping function contact, for player guardians, coaches etc.
		foreign key references Organization(org_id),
	person_type_id uniqueidentifier 
		foreign key references TypeTable(typetable_id)
)

CREATE TABLE EventTable (
	event_id uniqueidentifier  not null
		primary key,
	created_by_id uniqueidentifier  not null
		foreign key references Person(person_id),
	parent_id uniqueidentifier null
		foreign key references EventTable(event_id),
	name varchar(50),
	timeCreated datetime,
	startDate datetime,
	endDate datetime,
	event_description varchar(4000),
	location varchar(50),
	typetable_id uniqueidentifier not null 
		foreign key references TypeTable(typetable_id) 
)


CREATE TABLE PlayerApplication (
	playerapp_id uniqueidentifier not null
		primary key,
	consentApproved bit, -- boolean
	bcMedicalNumber varchar(10),
	birthdate datetime,
	registrationDate datetime,
	endDate datetime,
	gender char
		check (gender != null), 
	medicalNotes varchar(200), -- medicalAlert on UML -- not sure if this is to indicate data for allergies/heart condition type of data
	paid bit, -- boolean
	payment money 
		check (payment >= 0),
	previousTeam varchar(50),
	school varchar(50),
	comments varchar(512),
	player_id uniqueidentifier not null
		foreign key references Person(person_id),
	-- not sure how to make sure contact 1 and contact 2 are distinct
	contact1_id uniqueidentifier  not null
		foreign key references Person(person_id),
	contact2_id uniqueidentifier  
		foreign key references Person(person_id),
	coach_id uniqueidentifier
		foreign key references Person(person_id)
)

CREATE TABLE Roles (
	role_id uniqueidentifier not null
		primary key,
	role_name varchar(40) not null,
	role_description varchar(100)
)

CREATE TABLE UserAccount (
	person_id uniqueidentifier  not null
		foreign key references Person(person_id),
	username varchar(25) not null
		primary key,
	role_id uniqueidentifier -- may be null if adding a special user and dont want to create new role
		foreign key references Roles(role_id)
		
)

CREATE TABLE Team (
	team_id uniqueidentifier  not null
		primary key,
	team_name varchar(50) not null,
	category varchar(30) not null,
	coach_id uniqueidentifier null
		foreign key references Person(person_id)
)


CREATE TABLE TeamApplication (
	teamapp_id uniqueidentifier not null
		primary key,
	org_id uniqueidentifier 
		foreign key references Organization(org_id),
	tournament_id uniqueidentifier  not null
		foreign key references EventTable(event_id),
	team_name varchar(50) not null,
	category varchar(30) not null,
	coach_name varchar(100) not null,
	statusfield int not null, 	-- 0=just created; not submitted yet,
					-- 1=submitted; pending approval, 
					-- 2=approved; assigned to applied tournament,
					-- 3=denied; available note
	team_message varchar(4000),
	submission_date datetime
)

CREATE TABLE TeamEventMap (
	team_id uniqueidentifier  not null
		foreign key references Team(team_id),
	event_id uniqueidentifier  not null
		foreign key references EventTable(event_id)
)

CREATE TABLE Announcement (
	ann_id uniqueidentifier  not null
		primary key,
	ann_name varchar(100),
	ann_message varchar(1000)
)

CREATE TABLE TeamAnnouncementMap (
	team_id uniqueidentifier  not null
		foreign key references Team(team_id),
	ann_id uniqueidentifier  not null
		foreign key references Announcement(ann_id)
)

CREATE TABLE TeamPlayersMap (
	player_id uniqueidentifier 
		primary key foreign key references Person(person_id),
	coach_id uniqueidentifier 
		foreign key references Person(person_id),
	team_id uniqueidentifier
		foreign key references Team(team_id)
	
)

CREATE TABLE AuthorizationCode (
	AuthorizationCode uniqueidentifier 
		primary key ,
	IsUsed bit
	)

GO

CREATE TABLE Match (
	match_id uniqueidentifier  not null
		primary key,
	-- not sure how to make sure team 1 and team 2 are distinct
	team1_id uniqueidentifier  not null
		foreign key references TeamApplication(teamapp_id),
	team2_id uniqueidentifier  not null
		foreign key references TeamApplication(teamapp_id),  
	score1 float,
	score2 float,
	tournament_id uniqueidentifier not null
		foreign key references EventTable(event_id),
	location varchar(50),
	scheduled_date DateTime,
	length_of_game int -- in terms of minutes
)
-- Max Burlik
-- db-close.sql
-- Version 1.0 - Oct. 16, 2010
-- Function: Destroys all tables and database (for testing purposes)

USE phoenix
GO
DROP TABLE TeamAnnouncementMap
DROP TABLE Announcement
DROP TABLE TeamEventMap
DROP TABLE TeamApplication
DROP TABLE Match
DROP TABLE Team
DROP TABLE UserAccount
DROP TABLE Roles
DROP TABLE PlayerApplication
DROP TABLE OrganizationContactMap
DROP TABLE EventTable
DROP TABLE Person
DROP TABLE OrganizationAddressMap
DROP TABLE PersonAddress
DROP TABLE Organization
DROP TABLE Tournament
DROP TABLE TypeTable
GO
DROP DATABASE phoenix

USE Phoenix

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','9c1a8d66-3c71-4ec1-ae23-09d7070f9bb8','Submit Third Party Team Applications','submit third party team applications')


INSERT INTO Roles(role_id,role_name)
VALUES('794c2858-17db-462c-ab13-065b8f6719bf','Third Party')


INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('794c2858-17db-462c-ab13-065b8f6719bf','9c1a8d66-3c71-4ec1-ae23-09d7070f9bb8')

INSERT INTO aspnet_Users(ApplicationId,UserId,Username,LoweredUserName,MobileAlias,IsAnonymous,LastActivityDate)
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','fc5c7f54-8e4c-431d-b0bf-cb96789a17af','thirdparty','thirdparty',NULL,0,GETUTCDATE())

INSERT INTO aspnet_UsersInRoles(UserId,RoleId)
VALUES ('fc5c7f54-8e4c-431d-b0bf-cb96789a17af','9c1a8d66-3c71-4ec1-ae23-09d7070f9bb8')

INSERT INTO aspnet_Membership
(ApplicationId,UserId,
[Password],PasswordFormat,PasswordSalt,Email,LoweredEmail,
IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)
VALUES  ('4B49FB22-6C7B-446B-9112-344CE484DDFF','fc5c7f54-8e4c-431d-b0bf-cb96789a17af',
'6xi+KkdLMl6cEnCIIQewChCt2a0=',1,'QO27/NcUaK7WI8hqiIWVXg==','thirdparty@thirdparty.ca','thirdparty@thirdparty.ca',
1,0,GETUTCDATE(),GETUTCDATE(),GETUTCDATE(),'1754-01-01 00:00:00.000',0,'1754-01-01 00:00:00.000',0,'1754-01-01 00:00:00.000')

INSERT INTO Address(address_id,streetaddress,city,province,country,postalcode)
VALUES('88591834-5b54-4d3f-8f09-f15a94f3bc1e','52512512 Street','Surrey','BC','Canada','V3J8H1')

INSERT INTO Organization(address_id,fax,org_id,org_name,phone,url)
VALUES('88591834-5b54-4d3f-8f09-f15a94f3bc1e', '6045515251','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','UKFootball','6045433456','http://www.ukfootball.uk') 

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('aea3aaf2-aebf-4cab-bce6-39e91c4da7b7','John','Thirdguy','6045677897','6045677897','thirdparty@thirdparty.ca','88591834-5b54-4d3f-8f09-f15a94f3bc1e','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','31618B05-C3BB-4143-BEDB-7D7E1EC15CBE')

--INSERT INTO Tournament(tournament_id,tournament_name,tournament_info,registration_start_date,registration_end_date,tournament_start_date,tournament_end_date)
--VALUES('9144a275-40a6-4545-a0da-96490ebfb477','Phoenix FC Annual Tournament',null,'2010-11-18 17:00:00','2010-12-5 17:00:00','2010-12-06 17:00:00','2010-12-13 17:00:00')


----------------------------
-- tournament sample data --
----------------------------
INSERT INTO EventTable(typetable_id,event_id,created_by_id,parent_id,name,timeCreated,startDate,endDate,event_description,location)
VALUES('77ecf921-425d-46fb-90b1-48c34543e1e0','9144a275-40a6-4545-a0da-96490ebfb477','aea3aaf2-aebf-4cab-bce6-39e91c4da7b7',null,'Phoenix FC Annual Tournament','2010-11-17 18:39:24','2010-11-06 17:00:00','2010-12-16 17:00:00','The annual tournament held by Phoenix FC at Surrey Field.','Surrey Field')

INSERT INTO EventTable(typetable_id,event_id,created_by_id,parent_id,name,timeCreated,startDate,endDate,event_description,location)
VALUES('45e62ce0-81c4-406d-8c84-981a6e59b01e','dc38114a-b819-4f56-9821-27dd8ca2c992','aea3aaf2-aebf-4cab-bce6-39e91c4da7b7','9144a275-40a6-4545-a0da-96490ebfb477','Phoenix FC Annual Tournament Registration','2010-11-17 18:39:24','2010-11-06 17:00:00','2010-12-10 17:00:00',null,null)

INSERT INTO EventTable(typetable_id,event_id,created_by_id,parent_id,name,timeCreated,startDate,endDate,event_description,location)
VALUES('0546F422-B2C5-403D-BC45-1CA34489537F','0f0acde0-fa79-4c73-8ad2-a99542d94d14','aea3aaf2-aebf-4cab-bce6-39e91c4da7b7','9144a275-40a6-4545-a0da-96490ebfb477','Phoenix FC Annual Tournament Games','2010-11-17 18:39:24','2010-12-10 17:00:00','2010-12-16 17:00:00',null,null)



INSERT INTO UserAccount(person_id,username,role_id)
VALUES('aea3aaf2-aebf-4cab-bce6-39e91c4da7b7','thirdparty','794c2858-17db-462c-ab13-065b8f6719bf')

---------------------------------
-- TeamApplication sample data --
---------------------------------
INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('b1e4d90d-b81e-43df-8a95-a04e03662208','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','Flames','U18','Jack Frost',0,null,'2010-11-17 18:39:24')

INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('4f0ffee7-4d6d-4d46-ae25-c9023e2e4cbb','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','Flames','U17','Jack Nicholson',0,null,'2010-11-17 18:39:24')

INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('6595b836-2f45-41f9-940e-5aea6c6e383d','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','Raiders','U17','Ju Wong',1,null,'2010-11-17 18:39:24')

INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('dab203bc-dddd-4408-8ab4-1776b3cf1f2c','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','Snakes','U17','Jack Yang',2,"We're excited to have you play with us!", '2010-11-17 18:39:24')

INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('9fc1ec92-919a-4624-9c0c-a4da69e85888','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','Wildfishes','U17','Max B',1,null,'2010-11-17 18:39:24')

INSERT INTO TeamApplication(teamapp_id,org_id,tournament_id,team_name,category,coach_name,statusfield,team_message, submission_date)
VALUES('222561f5-4e21-460d-98ec-9d3166118dc5','cdc7f378-aaf4-49bb-b70f-aeb2b746ba25','9144a275-40a6-4545-a0da-96490ebfb477','The Kicks','U17','Dell Computers',3,"We don't like your kind.",'2010-11-17 18:39:24')
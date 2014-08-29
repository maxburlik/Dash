USE phoenix
INSERT INTO Address(address_id,streetaddress,city,country,postalcode,province)
VALUES ('A31506DA-28C5-43F7-B27E-38B4C3663E35','1111 Street','Burnaby','Canada','V3W6T7','BC')

INSERT INTO Organization(address_id,fax,org_id,org_name,phone,url)
VALUES('A31506DA-28C5-43F7-B27E-38B4C3663E35', '6047654567','6A202BE4-CC1A-410F-9CB5-FC26E9464791', 'PhoenixFC','6045433456','http://www.phoenixfc.ca') 

INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('DF794B3D-B5E0-41D5-B5C2-5DD6402397DB','Actors','Used for defining external and internal users of the system',NULL)

INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('085DDE97-15B9-4061-AC34-34F760886CF8','Player','Internal Actor','DF794B3D-B5E0-41D5-B5C2-5DD6402397DB')

INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('EDF590EE-3E21-458C-90BC-85D3781BBC40','Employee','Internal Actor','DF794B3D-B5E0-41D5-B5C2-5DD6402397DB')

INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('31618B05-C3BB-4143-BEDB-7D7E1EC15CBE','ThirdParty','External Actor','DF794B3D-B5E0-41D5-B5C2-5DD6402397DB')

INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('1af87f77-8509-4210-8a9a-0a502b771315','Event','Used to define events',null)


INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('bb7e0f1b-7632-4929-a049-4e521d7ac441','CoachEvent','Used to hold coach events: practice sessions, etc','1af87f77-8509-4210-8a9a-0a502b771315')


INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('77ecf921-425d-46fb-90b1-48c34543e1e0','TournamentEvent','Used to hold tournament events: tournament game event, etc','1af87f77-8509-4210-8a9a-0a502b771315')


INSERT INTO aspnet_Applications(ApplicationName,LoweredApplicationName,ApplicationId) 
VALUES('Phoenix','phoenix','4B49FB22-6C7B-446B-9112-344CE484DDFF')

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','1FCFF1E4-906B-4D06-85F1-5862981AECC8','Manage Roles','manage roles')

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','E53824F0-8CDF-48E6-943B-0F8B965767AD','Manage Users','manage users')


INSERT INTO aspnet_Users(ApplicationId,UserId,Username,LoweredUserName,MobileAlias,IsAnonymous,LastActivityDate)
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','3084D5C8-18AA-4E37-B49E-56F951A30F8F','admin','admin',NULL,0,GETUTCDATE())


INSERT INTO aspnet_UsersInRoles(UserId,RoleId)
VALUES ('3084D5C8-18AA-4E37-B49E-56F951A30F8F','E53824F0-8CDF-48E6-943B-0F8B965767AD')
  
  
INSERT INTO aspnet_UsersInRoles(UserId,RoleId)
VALUES ('3084D5C8-18AA-4E37-B49E-56F951A30F8F','1FCFF1E4-906B-4D06-85F1-5862981AECC8')


INSERT INTO aspnet_Membership
(ApplicationId,UserId,
[Password],PasswordFormat,PasswordSalt,Email,LoweredEmail,
IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)
VALUES  ('4B49FB22-6C7B-446B-9112-344CE484DDFF','3084D5C8-18AA-4E37-B49E-56F951A30F8F',
'6xi+KkdLMl6cEnCIIQewChCt2a0=',1,'QO27/NcUaK7WI8hqiIWVXg==','admin@phoenixfc.ca','admin@phoenixfc.ca',
1,0,GETUTCDATE(),GETUTCDATE(),GETUTCDATE(),'1754-01-01 00:00:00.000',0,'1754-01-01 00:00:00.000',0,'1754-01-01 00:00:00.000')

INSERT INTO Roles(role_id,role_name)
VALUES('9F43A302-AA0D-4081-A37A-4E0F3C4BC3F3','Administrator')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('9F43A302-AA0D-4081-A37A-4E0F3C4BC3F3','1FCFF1E4-906B-4D06-85F1-5862981AECC8')


INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('9F43A302-AA0D-4081-A37A-4E0F3C4BC3F3','E53824F0-8CDF-48E6-943B-0F8B965767AD')


INSERT INTO Address(address_id,streetaddress,city,province,country,postalcode)
VALUES('172816B8-08A9-40F5-8685-09D47D502ECC','1123 Street','Vancouver','BC','Canada','V3T5Y6')

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('0E576806-CB29-4565-B6BB-A22350C2976C','Admin',' ','6045677897','6045677897','admin@phoenixfc.ca','172816B8-08A9-40F5-8685-09D47D502ECC','6A202BE4-CC1A-410F-9CB5-FC26E9464791','EDF590EE-3E21-458C-90BC-85D3781BBC40')











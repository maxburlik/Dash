USE phoenix

-- Create Available Functions,'Manage Players Registration' and 'Manage Organizations Registration', in the page 'Manage Role'
INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','eb79701c-5776-483b-8aa2-8840a675b33c','Manage Players Registration','manage players registration')

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','554ef1a4-bc09-4033-b0cf-b159b0acd975','Manage Organizations Registration','manage organizations registration')


-- Create Available Functions,'Manage Team Events' and 'Manage Teams', in the page 'Manage Role'
INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','26ff5349-2fca-472a-b419-dfe1c1835104','Manage Team Events','manage team events')

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','3b11dd51-2cd6-4d58-b376-aa1c83a4e69b','Manage Teams','manage teams')


-- Create Available Functions,'Manage Tournament Team Applications' and 'Tournament Planning', in the page 'Manage Role'
INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','2858ec7e-05ac-42f9-b09f-23c689b4b889','Manage Tournament Team Applications','manage tournament team applications')

INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','28c848ad-09ac-4ea5-9e4e-24040052f5f1','Tournament Planning','tournament planning')


INSERT INTO aspnet_Roles(ApplicationId, RoleId, RoleName, LoweredRoleName) 
VALUES('4B49FB22-6C7B-446B-9112-344CE484DDFF','20839bb2-6122-4057-a77d-7150319f944d','Manage Tournaments','manage tournaments')



--Create Role, 'Registrar', in the page 'Manage Role'
INSERT INTO Roles(role_id,role_name)
VALUES('e1f1aff2-d34a-4686-ad32-9189065e6f3e','Registrar')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('e1f1aff2-d34a-4686-ad32-9189065e6f3e','eb79701c-5776-483b-8aa2-8840a675b33c')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('e1f1aff2-d34a-4686-ad32-9189065e6f3e','554ef1a4-bc09-4033-b0cf-b159b0acd975')


--Create Role, 'Coach', in the page 'Manage Role'
INSERT INTO Roles(role_id,role_name)
VALUES('6f46ea74-3fbc-496c-a240-604d6fff30eb','Coach')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('6f46ea74-3fbc-496c-a240-604d6fff30eb','26ff5349-2fca-472a-b419-dfe1c1835104')


INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('6f46ea74-3fbc-496c-a240-604d6fff30eb','3b11dd51-2cd6-4d58-b376-aa1c83a4e69b')


--Create Role, 'Tournament Planner', in the page 'Manage Role'
INSERT INTO Roles(role_id,role_name)
VALUES('7c4e5505-f318-44a9-a5ae-3cbb16565407','Tournament Planner')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('7c4e5505-f318-44a9-a5ae-3cbb16565407','2858ec7e-05ac-42f9-b09f-23c689b4b889')


INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('7c4e5505-f318-44a9-a5ae-3cbb16565407','28c848ad-09ac-4ea5-9e4e-24040052f5f1')

INSERT INTO RoleAvailableFunctions(RoleID,AvailableFunctionID)
VALUES('7c4e5505-f318-44a9-a5ae-3cbb16565407','20839bb2-6122-4057-a77d-7150319f944d')


-- Create type, "TournamentGame" and "TournamentRegistration" in TypeTable
INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('0546f422-b2c5-403d-bc45-1ca34489537f','TournamentGame','Used to hold tournament registration information','77ecf921-425d-46fb-90b1-48c34543e1e0')


INSERT INTO TypeTable(typetable_id,typename,type_description,parenttype_id)
VALUES('45e62ce0-81c4-406d-8c84-981a6e59b01e','TournamentRegistration','Used to hold tournament registration information','77ecf921-425d-46fb-90b1-48c34543e1e0')

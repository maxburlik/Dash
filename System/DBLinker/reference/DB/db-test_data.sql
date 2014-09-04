--Create One player Application
USE phoenix
INSERT INTO Address(address_id,streetaddress,city,country,postalcode,province)
VALUES ('74b92ced-1c38-494a-b998-9f9fa85cf0de','12345 Street','Burnaby','Canada','V3W6T7','BC')

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('754e7d82-3da4-48cc-a0b4-b1e5c2061bb3','Eddie','Wong','6041234567','6041234567','kkw17@sfu.ca','74b92ced-1c38-494a-b998-9f9fa85cf0de','6A202BE4-CC1A-410F-9CB5-FC26E9464791','085DDE97-15B9-4061-AC34-34F760886CF8')

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('a196e5c4-594e-4303-b4ca-711c3258c7d2','Mother','M','6041234567','6041234567','mother@home.ca','74b92ced-1c38-494a-b998-9f9fa85cf0de',NULL,NULL)

INSERT INTO PlayerApplication(playerapp_id ,bcMedicalNumber,birthdate,consentApproved, registrationDate, gender, player_id, medicalNotes,paid, payment, previousTeam, school, contact1_id,contact2_id, coach_id )
VALUES ('fba82868-f24d-46e8-be31-fc2b15ffe9ee', '9321345', '20040305 09:12:59',1,'20040305 09:12:59', 1, '754e7d82-3da4-48cc-a0b4-b1e5c2061bb3', 'Medical Notes goes here', 1, '100.00', NULL, 'Simon Fraser University', 'a196e5c4-594e-4303-b4ca-711c3258c7d2',null, '422b6723-6bb7-4c46-8e2e-874ef2c26253')

-- Create Three Coaches, U
INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('422b6723-6bb7-4c46-8e2e-874ef2c26253','CoachA','A','7781234567','7781234567','coachA@sfu.ca','2364f992-f89a-4eeb-9730-e72a4539eade','6A202BE4-CC1A-410F-9CB5-FC26E9464791','edf590ee-3e21-458c-90bc-85d3781bbc40')

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('ebc1009d-6af6-4596-9a3d-a9e702c7150c','CoachB','B','6040000000','6040000000','coachB@sfu.ca','8963e699-950d-4b79-8b6a-fa3e74893c8c','6A202BE4-CC1A-410F-9CB5-FC26E9464791','edf590ee-3e21-458c-90bc-85d3781bbc40')

INSERT INTO Person(person_id,firstname,lastname,mainphone,workphone,email,address_id,org_id,person_type_id)
VALUES('7fa8b672-aae4-461c-b937-af10b557c480','CoachC','C','5199876543','5191234567','coachC@sfu.ca','491e71fd-ac78-44ab-b7ee-e99ffc0bffc2','6A202BE4-CC1A-410F-9CB5-FC26E9464791','edf590ee-3e21-458c-90bc-85d3781bbc40')

INSERT INTO Address(address_id,streetaddress,city,country,postalcode,province)
VALUES ('2364f992-f89a-4eeb-9730-e72a4539eade','12345 Street','Burnaby','Canada','V3W6T7','BC')

INSERT INTO Address(address_id,streetaddress,city,country,postalcode,province)
VALUES ('8963e699-950d-4b79-8b6a-fa3e74893c8c','5432 Street','Richmond','Canada','V1W6T2','BC')

INSERT INTO Address(address_id,streetaddress,city,country,postalcode,province)
VALUES ('491e71fd-ac78-44ab-b7ee-e99ffc0bffc2','9999 Street','Vancouver','Canada','G3W6TG','BC')






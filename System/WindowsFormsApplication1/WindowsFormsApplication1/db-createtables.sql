USE TestDB

CREATE TABLE FileContents (
	Id uniqueidentifier not null
		primary key,
	Text varchar(4000),
	DateEntered datetime not null
)
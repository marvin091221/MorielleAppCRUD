create database IMDBsys32

use IMDBsys32

create table [User] (
	id int primary key not null,
	userName nvarchar(255) not null,
	[passWord] nvarchar(255) not null
)

create table [Role](
	id int primary key not null,
	roleName nvarchar(255) not null
)

insert into Role (id, roleName)
values (1, 'User'),
       (2, 'Manager');

create View vw_UserRole
as 
SELECT UserRole.id, [User].userName, Role.roleName
FROM     Role INNER JOIN
                  UserRole ON Role.id = UserRole.roleId INNER JOIN
                  [User] ON UserRole.userId = [User].id



select * from [User]
select * from [Role]
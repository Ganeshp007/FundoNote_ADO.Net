create database Fundonote     --creating Fundonote database
use Fundonote
--creating user table
create table Users( 
UserId int primary key identity,
Firstname varchar(50),
Lastname varchar(50),
Email varchar(50) unique,
Password varchar(255),
CreateDate datetime Default sysdatetime(),
MoidifyDate datetime Default getdate()   --sysdatetime and getdate will give same output 
)

insert into Users(Firstname,Lastname,Email,Password) values('Ganesh','Potdar','ganesh@gmail.com','Ganesh@1234')
select * from Users
-------------------------------------------------------------------
--creating Note Table to store Notes
create table Note(
NoteId int identity(1,1) primary key,
Title varchar(20) not null,
Description varchar(max) not null,
Bgcolor varchar(50) not null,
IsPin bit,
IsArchive bit,
IsRemainder bit,
IsTrash bit,
UserId int not null foreign key references Users(UserId),
RegisteredDate datetime default GETDATE(),
Remainder datetime,
ModifiedDate datetime null
)
select * from Note

exec sp_help 'dbo.Note'

truncate table Note
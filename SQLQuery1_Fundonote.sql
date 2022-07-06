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
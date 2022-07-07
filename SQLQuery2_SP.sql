--Created Stored Procedure for AddUser
create procedure spAddUser(
@Firstname varchar(50), 
@Lastname varchar(50),
@Email varchar(50),
@password varchar(255)
)
As
Begin try
insert into Users(Firstname,Lastname,Email,Password) values(@Firstname,@Lastname,@Email,@Password)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--executing the spAddUser stored procedure
exec spAddUser 'Suresh','kumar','suresh@gmail.com','Suresh@123'
select * from Users

--creating stored Procedure for Fetching User info from DB
create procedure spGetAllUser
As
Begin try
select * from Users
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spGetAllUser
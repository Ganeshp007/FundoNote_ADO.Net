---------------------------------For User-------------------------------------------
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

------------------------------------------------------------------------------
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

--------------------------------------------------------------------------------
--Creating StoredProcedure For UserLogin Operation
create procedure spUserLogin(
@Email varchar(50),
@Password varchar(255)
)

As 
BEGIN TRY
select * from Users where Email=@Email and Password=@Password
END TRY
BEGIN CATCH
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spUserLogin 'ganesh@gmail.com','Ganesh@1234'

---------------------------------------------------------------------------------
--Creating Stored Procedure For ForgetPassword api
create procedure spUserForgetPassword(
@Email varchar(50)
)
AS
BEGIN TRY
select * from Users where Email=@Email
END TRY
BEGIN CATCH
SELECT
      ERROR_NUMBER() AS ErrorNumber,
	  ERROR_STATE() AS ErrorState,
	  ERROR_PROCEDURE() AS ErrorProcedure,
	  ERROR_LINE() AS ErrorLine,
	  ERROR_MESSAGE() AS ErrorMessage
END CATCH

Exec spUserForgetPassword 'ganesh@gmail.com'

--------------------------------------------------------------------------------
--Creating Stored Procedure For ResetPassword api
create procedure spResetPassword(
@Email varchar(50),
@Password varchar(255)
)
AS
BEGIN TRY
update Users set Password=@Password where Email=@Email
END TRY
BEGIN CATCH
SELECT
      ERROR_NUMBER() AS ErrorNumber,
	  ERROR_STATE() AS ErrorState,
	  ERROR_PROCEDURE() AS ErrorProcedure,
	  ERROR_LINE() AS ErrorLine,
	  ERROR_MESSAGE() AS ErrorMessage
END CATCH

Exec spResetPassword 'ganesh@gmail.com','Ganesh@1234'

-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------

---------------------------For Note------------------------------------------------------
--creating stored procedure to add note to Note table
create procedure spAddNote(
@Title varchar(20), 
@Description varchar(max),
@BgColor varchar(50),
@UserId int
)
As
Begin try
insert into Note(Title,Description,Bgcolor,UserId,IsPin,IsArchive,IsRemainder,IsTrash,ModifiedDate) values(@Title,@Description,@BgColor,@UserId,0,0,0,0,GetDate())
Select * from Note where UserId = @UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

-----------------------------------------------------------------------
--creating Stroed Procedure to Update NOte
create procedure spUpdateNote(
@Title varchar(20), 
@Description varchar(max),
@BgColor varchar(50),
@UserId int,
@NoteId int,
@IsPin bit,
@IsArchive bit,
@IsRemainder bit,
@IsTrash bit
)
As
Begin try
Update Note set Title=@Title,Description=@Description,Bgcolor=@BgColor,IsPin=@IsPin,IsArchive=@IsArchive,IsRemainder=@IsRemainder,IsTrash=@IsTrash,ModifiedDate=GetDate() where UserId=@UserId and NoteId=@NoteId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

------------------------------------------------------------------------
--creating storedProcedure to Get All Notes
create procedure spGetAllNote(
@UserId int
)
As
Begin try
select * from Note where UserId=@UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

---------------------------------------------------------------------------
--creating stored procedure for DeleteNote API
create procedure spDeleteNote(@NoteId int,@UserId int)
As
Begin try
Update Note set IsTrash=1 where NoteId=@NoteId and UserId=@UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH
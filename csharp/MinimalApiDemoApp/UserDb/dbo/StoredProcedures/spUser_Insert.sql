CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Age int
as
begin
	insert into dbo.[User] (FirstName, LastName, Age)
	values (@FirstName, @LastName, @Age);
end
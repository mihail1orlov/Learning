CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Age int
as
begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName, Age = @Age
	where Id = @Id;
end
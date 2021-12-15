CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
as
begin
	select Id, FirstName, LastName, Age
	from dbo.[User]
	where Id = @Id;
end
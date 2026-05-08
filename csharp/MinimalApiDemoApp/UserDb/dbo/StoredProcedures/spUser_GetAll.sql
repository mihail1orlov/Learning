CREATE PROCEDURE [dbo].[spUser_GetAll]
as
begin
	select Id, FirstName, LastName, Age
	from dbo.[User];
end
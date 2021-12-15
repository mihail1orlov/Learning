if not exists (select 1 from dbo.[User])
begin
    insert into dbo.[User] (FirstName, LastName, Age)
    values
        ('Tim', 'Corey', 20),
        ('Sue', 'Storm', 21),
        ('John', 'Smith', 22),
        ('Mary', 'Jones', 23);
end
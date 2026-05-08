/*
create or replace procedure tst_save_product(p_name character varying, p_price double precision)
as
$$
	begin
		insert into products (name, price) values(p_name, p_price);
	end;
$$
language plpgsql;

create or replace procedure tst_update_product(p_name character varying, p_price double precision, p_id int)
as
$$
	begin
		update products set name = p_name, price = p_price where id = p_id;
	end;
$$
language plpgsql;

create or replace procedure tst_delete_product(p_id int)
as
$$
	begin
		delete from products where id = p_id;
	end;
$$
language plpgsql;


CREATE TABLE "User"
(
	Id INT NOT NULL PRIMARY KEY, 
    FirstName text, 
    LastName text, 
    Age int
)

insert into "User" (Id, FirstName, LastName, Age)
    values
        (1, 'Tim', 'Corey', 20),
        (2, 'Sue', 'Storm', 21),
        (3, 'John', 'Smith', 22),
        (4, 'Mary', 'Jones', 23);

CREATE PROCEDURE spUser_Delete (Id int)
LANGUAGE SQL
as $$
	delete
	from "User"
	where Id = Id;
$$;

CREATE PROCEDURE spUser_Get (Id int)
Language sql
as $$
	select Id, FirstName, LastName, Age
	from "User"
	where Id = Id;
$$;

--

drop procedure if exists spuser_getall;

create or replace procedure spuser_getall()
as
$$
begin
	select Id, FirstName, LastName, Age from "User";
end
$$
language plpgsql;

call spuser_getall();

--

CREATE OR REPLACE PROCEDURE sp_user_insert (p_id int, p_fn text, p_ln text, p_age int)
as $$
	insert into "User" (Id, FirstName, LastName, Age)
	values (p_id, p_fn, p_ln, p_age);
$$
language sql;

select * from "User";

CALL sp_user_insert(6, '11111', '22222', 333);
--

CREATE PROCEDURE spUser_Update (Id int, FirstName text, LastName text, Age int)
language sql
as $$
	update "User"
	set FirstName = FirstName, LastName = LastName, Age = Age
	where Id = Id;
$$;


datatype                 system_enum                   csharp_dbtype   postgres_enum
bigint                   System.Data.DbType.Int64      Int64           NpgsqlTypes.NpgsqlDbType.Bigint
bit                      System.Data.DbType.Boolean    Boolean         NpgsqlTypes.NpgsqlDbType.Bit
bool                     System.Data.DbType.Boolean    Boolean         NpgsqlTypes.NpgsqlDbType.Boolean
boolean                  System.Data.DbType.Boolean    Boolean         NpgsqlTypes.NpgsqlDbType.Boolean
Box                      System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Box
bpchar                   System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Text
_bpchar                  System.Data.DbType.String[]   String[]        NpgsqlDbType.Array | NpgsqlDbType.Text
bytea                    System.Data.DbType.Binary     Byte[]          NpgsqlTypes.NpgsqlDbType.Bytea
character                System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Char
character varying        System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Varchar
Circle                   System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Circle
date                     System.Data.DbType.DateTime   DateTime        NpgsqlTypes.NpgsqlDbType.Date
float4                   System.Data.DbType.Single     Single          NpgsqlTypes.NpgsqlDbType.Real
float8                   System.Data.DbType.Double     Double          NpgsqlTypes.NpgsqlDbType.Double
inet                     System.Data.DbType.Object     IPAddress       NpgsqlTypes.NpgsqlDbType.Inet
_int2                    System.Data.DbType.Int16[]    Int16[]         NpgsqlDbType.Array | NpgsqlDbType.SmallInt
int2                     System.Data.DbType.Int16      Int16           NpgsqlTypes.NpgsqlDbType.Smallint
int4                     System.Data.DbType.Int32      Int32           NpgsqlTypes.NpgsqlDbType.Integer
_int4                    System.Data.DbType.Int32[]    Int32[]         NpgsqlDbType.Array | NpgsqlDbType.Integer
int8                     System.Data.DbType.Int64      Int64           NpgsqlTypes.NpgsqlDbType.Bigint
_int8                    System.Data.DbType.Int64[]    Int64[]         NpgsqlDbType.Array | NpgsqlDbType.BigInt
integer                  System.Data.DbType.Int32      Int32           NpgsqlTypes.NpgsqlDbType.Integer
interval                 System.Data.DbType.Object     TimeSpan        NpgsqlTypes.NpgsqlDbType.Interval
Line                     System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Line
LSeg                     System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.LSeg
money                    System.Data.DbType.Decimal    Decimal         NpgsqlTypes.NpgsqlDbType.Money
name                     System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Name
numeric                  System.Data.DbType.Decimal    Decimal         NpgsqlTypes.NpgsqlDbType.Numeric
oid                      System.Data.DbType.UInt32     uint            NpgsqlTypes.NpgsqlDbType.Oid
Path                     System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Path
Point                    System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Point
Polygon                  System.Data.DbType.Object     Object          NpgsqlTypes.NpgsqlDbType.Polygon
public.citext            System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Text
smallint                 System.Data.DbType.Int16      Int16           NpgsqlTypes.NpgsqlDbType.Smallint
_text                    System.Data.DbType.String[]   String[]        NpgsqlDbType.Array | NpgsqlDbType.Text
text                     System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Text
time                     System.Data.DbType.Time       DateTime        NpgsqlTypes.NpgsqlDbType.Time
_timestamp               System.Data.DbType.DateTime[] DateTime[]      NpgsqlDbType.Array | NpgsqlDbType.Timestamp
timestamp                System.Data.DbType.DateTime   DateTime        NpgsqlTypes.NpgsqlDbType.Timestamp
timestamptz              System.Data.DbType.DateTime   DateTime        NpgsqlTypes.NpgsqlDbType.TimestampTZ
timestamp with time zone System.Data.DbType.DateTime   DateTime        NpgsqlTypes.NpgsqlDbType.TimestampTz
timetz                   System.Data.DbType.Time       DateTime        NpgsqlTypes.NpgsqlDbType.Time
unknown                  System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Text
uuid                     System.Data.DbType.Guid       Guid            NpgsqlTypes.NpgsqlDbType.Uuid
varchar                  System.Data.DbType.String     String          NpgsqlTypes.NpgsqlDbType.Varchar
_varchar                 System.Data.DbType.String[]   String[]        NpgsqlDbType.Array | NpgsqlDbType.Varchar
xid                      System.Data.DbType.UInt32     uint            NpgsqlTypes.NpgsqlDbType.Xid
xml                      System.Data.DbType.Xml        Xml.XmlDocument NpgsqlTypes.NpgsqlDbType.Xml
*/
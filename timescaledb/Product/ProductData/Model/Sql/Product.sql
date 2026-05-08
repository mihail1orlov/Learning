create table "Products"(
	"ProductId" UUID PRIMARY KEY,
	"CreateOn" TIMESTAMP(0) NOT NULL,
	"Title" VARCHAR(50) NOT NULL,
	"Body" VARCHAR(1000) NULL,
	"IsCompleted" BOOLEAN NOT NULL
);
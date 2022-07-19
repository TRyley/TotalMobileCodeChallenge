CREATE TABLE [dbo].[Employee] (
    [Employee_ID] INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50) NOT NULL,
    [Surname]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Employee_ID] ASC)
);


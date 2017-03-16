CREATE TABLE [dbo].[Customers] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (50)  NOT NULL,
    [LastName]   VARCHAR (50)  NOT NULL,
    [HomePhone]  VARCHAR (12)  NOT NULL,
    [CellPhone]  VARCHAR (12)  NULL,
    [AddressOne] VARCHAR (150) NULL,
    [AddressTwo] VARCHAR (150) NULL,
    [PostalCode] VARCHAR (5)   NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([ID] ASC)
);


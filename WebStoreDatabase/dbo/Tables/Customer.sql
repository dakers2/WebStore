CREATE TABLE [dbo].[Customer] (
    [CustomerId] INT IDENTITY(1,1) NOT NULL,
    [FirstName]  NVARCHAR (20) NULL,
    [LastName]   NVARCHAR (10) NULL,
    [Email]      NVARCHAR (50) NULL,
    [AddressId]  INT           NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId] ASC),
    CONSTRAINT [FK_Customer_ToTable] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([AddressId])
);








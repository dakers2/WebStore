CREATE TABLE [dbo].[Address] (
    [AddressId] INT IDENTITY(1,1)       NOT NULL,
    [Line1]     NCHAR (50) NULL,
    [Line2]     NCHAR (50) NULL,
    [City]      NCHAR (50) NULL,
    [State]     NCHAR (50) NULL,
    [Zipcode]   INT        NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY ([AddressId] ASC)
);






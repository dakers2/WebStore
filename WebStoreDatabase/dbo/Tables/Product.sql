CREATE TABLE [dbo].[Product] (
    [ProductId]   INT  IDENTITY(1,1)          NOT NULL,
    [ProductName] NVARCHAR (100) NULL,
    [Description] NVARCHAR (200) NULL,
    [Price]       MONEY          NULL,
    [Image]       NCHAR (100)    NULL,
    [Quantity]    INT            NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [Featured]    INT            NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId] ASC),
    CONSTRAINT [FK_Product_ToTable] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);








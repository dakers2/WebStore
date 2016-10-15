CREATE TABLE [dbo].[OrderHeader] (
    [OrderId]       INT   IDENTITY(1,1)        NOT NULL,
    [OrderDate]     DATETIME2 (7) DEFAULT (getdate()) NOT NULL,
    [ShipDate]      DATETIME2 (7) NOT NULL,
    [CustomerId]    INT           NOT NULL,
    [ShipToAddress] INT           NOT NULL,
    [BillToAddress] INT           NOT NULL,
    [ShipMethod]    NVARCHAR (50) NOT NULL,
    [TotalDue]      AS            (isnull(([SubTotal]+[TaxAmt])+[ShipAmt],(0))),
    [SubTotal]      MONEY         NOT NULL,
    [TaxAmt]        MONEY         NOT NULL,
    [ShipAmt]       MONEY         NOT NULL,
    CONSTRAINT [PK_OrderHeader] PRIMARY KEY ([OrderId] ASC),
    CONSTRAINT [FK_OrderHeader_AddressBill_AddressId] FOREIGN KEY ([BillToAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_OrderHeader_AddressShip_AddressId] FOREIGN KEY ([ShipToAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_OrderHeader_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])
);






CREATE TABLE [dbo].[OrderHeader] (
    [OrderId]       INT      NOT NULL,
    [OrderDate]     DATETIME2 (7) DEFAULT (getdate()) NOT NULL,
    [ReceiveDate]      DATETIME2 (7) NULL,
    [CustomerId]    INT           NOT NULL,
    [ShipToAddress] INT           NULL,
    [BillToAddress] INT           NULL,
    [ShippingMethodId] INT NULL,
    [TotalDue]      AS            (isnull(([SubTotal]+[TaxAmt])+[ShipAmt],(0))),
    [SubTotal]      MONEY         NOT NULL,
    [TaxAmt]        MONEY         NULL,
    [ShipAmt]       MONEY         NULL,
    CONSTRAINT [PK_OrderHeader] PRIMARY KEY ([OrderId] ASC),
    CONSTRAINT [FK_OrderHeader_AddressBill_AddressId] FOREIGN KEY ([BillToAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_OrderHeader_AddressShip_AddressId] FOREIGN KEY ([ShipToAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_OrderHeader_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]), 
    CONSTRAINT [FK_OrderHeader_ShippingMethodId] FOREIGN KEY ([ShippingMethodId]) REFERENCES [dbo].[Shipping]([ShippingMethodId])
);






CREATE TABLE [dbo].[OrderDetail] (
    [OrderDetailId] INT IDENTITY(1,1)       NOT NULL,
    [OrderId]       INT        NOT NULL,
    [ProductId]     INT        NOT NULL,
    [OrderOty]      INT        NOT NULL,
    [LineTotal]     MONEY NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetail_OrderHeader_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderHeader] ([OrderId]),
    CONSTRAINT [FK_OrderDetail_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);






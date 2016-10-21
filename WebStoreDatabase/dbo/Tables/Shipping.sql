CREATE TABLE [dbo].[Shipping]
(
	[ShippingMethodId] INT NOT NULL, 
    [Method] NVARCHAR(20) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [DaysToShip] INT NOT NULL, 
    CONSTRAINT [PK_Shipping] PRIMARY KEY ([ShippingMethodId]) 
)

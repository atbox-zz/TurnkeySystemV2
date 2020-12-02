CREATE TABLE [dbo].[BackA0401]
(
	[InvoiceNumber] NCHAR (10)      NOT NULL,
    [InvoiceDate]   NCHAR (8)       NULL,
    [InvoiceTime]   NCHAR (4)       NULL,
    [SellerID]      NCHAR (8)       NULL,
    [SellerName]    NCHAR (60)      NULL,
    [BuyerID]       NCHAR (8)       NULL,
    [BuyerName]     NCHAR (60)      NULL,
    [InvoiceType]   NCHAR (2)       NULL,
    [DonateMark]    NCHAR (1)       NULL,
    [SalesAmount]   NUMERIC (18)    NULL,
    [TaxType]       NCHAR (1)       NULL,
    [TaxRate]       NUMERIC (18, 2) NULL,
    [TaxAmount]     NUMERIC (18)    NULL,
    [TotalAmount]   NUMERIC (18)    NULL, 
    CONSTRAINT [PK_BackA0401] PRIMARY KEY ([InvoiceNumber]),
)

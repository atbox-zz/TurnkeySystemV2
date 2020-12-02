CREATE TABLE [dbo].[BackA0302]
(
	[RejectInvoiceNumber] NCHAR (10) NOT NULL,
    [InvoiceDate]         NCHAR (8)  NULL,
    [BuyerId]             NCHAR (8)  NULL,
    [SellerId]            NCHAR (8)  NULL,
    [RejectDate]          NCHAR (8)  NULL,
    [RejectTime]          NCHAR (4)  NULL, 
    CONSTRAINT [PK_BackA0302] PRIMARY KEY ([RejectInvoiceNumber]),
)

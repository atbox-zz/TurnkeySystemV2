CREATE TABLE [dbo].[BackA0102]
(
	    [InvoiceNumber] NCHAR (10) NOT NULL,
    [InvoiceDate]   NCHAR (8)  NULL,
    [BuyerID]       NCHAR (8)  NULL,
    [SellerID]      NCHAR (8)  NULL,
    [ReceiveDate]   NCHAR (8)  NULL,
    [ReceiveTime]   NCHAR (4)  NULL, 
    CONSTRAINT [PK_BackA0102] PRIMARY KEY ([InvoiceNumber]),
)

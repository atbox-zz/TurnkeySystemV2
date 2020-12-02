CREATE TABLE [dbo].[BackA0202]
(
	[CancelInvoiceNumber] NCHAR (16) NOT NULL,
    [InvoiceDate]         NCHAR (8)  NULL,
    [Buyerid]             NCHAR (8)  NULL,
    [Sellerid]            NCHAR (8)  NULL,
    [CancelDate]          NCHAR (8)  NULL,
    [CancelTime]          NCHAR (4)  NULL, 
    CONSTRAINT [PK_BackA0202] PRIMARY KEY ([CancelInvoiceNumber]),
)

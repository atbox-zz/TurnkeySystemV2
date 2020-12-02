CREATE TABLE [dbo].[BackA0501]
(
    [CancelInvoiceNumber] NCHAR (10) NOT NULL,
    [InvoiceDate]         NCHAR (8)  NULL,
    [Buyerid]             NCHAR (8)  NULL,
    [Sellerid]            NCHAR (8)  NULL,
    [CancelDate]          NCHAR (8)  NULL,
    [CancelTime]          NCHAR (4)  NULL,
    [CancelReason]        NCHAR (20) NULL, 
    CONSTRAINT [PK_BackA0501] PRIMARY KEY ([CancelInvoiceNumber]),
)

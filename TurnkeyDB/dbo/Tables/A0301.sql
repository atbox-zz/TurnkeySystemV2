CREATE TABLE [dbo].[A0301] (
    [RejectInvoiceNumber] NCHAR (10) NOT NULL,
    [InvoiceDate]         NCHAR (8)  NULL,
    [BuyerId]             NCHAR (8)  NULL,
    [SellerId]            NCHAR (8)  NULL,
    [RejectDate]          NCHAR (8)  NULL,
    [RejectTime]          NCHAR (4)  NULL,
    [RejectReason]        NCHAR (20) NULL,
    CONSTRAINT [PK_A0301] PRIMARY KEY CLUSTERED ([RejectInvoiceNumber] ASC)
);


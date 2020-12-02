CREATE TABLE [dbo].[BackA0401-detail]
(
    [InvoiceNumber]  NCHAR (10)      NOT NULL,
    [Description]    NCHAR (256)     NULL,
    [Quantity]       NUMERIC (18, 3) NULL,
    [Unit]           NCHAR (6)       NULL,
    [UniPrice]       DECIMAL (18)    NULL,
    [Amount]         DECIMAL (18, 3) NULL,
    [SequenceNumber] NCHAR (10)      NOT NULL, 
    CONSTRAINT [PK_BackA0401-detail] PRIMARY KEY ([InvoiceNumber], [SequenceNumber]),
)

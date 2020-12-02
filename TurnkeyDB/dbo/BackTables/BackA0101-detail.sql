CREATE TABLE [dbo].[BackA0101-detail]
(
	[InvoiceNumber]  NCHAR (10)      NOT NULL,
    [Description]    NCHAR (256)     NULL,
    [Quantity]       DECIMAL (18, 3) NULL,
    [Unit]           NCHAR (6)       NULL,
    [UnitPrice]      DECIMAL (18, 3) NULL,
    [Amount]         DECIMAL (18, 3) NULL,
    [SequenceNumber] NCHAR (10)      NOT NULL, 
    CONSTRAINT [PK_BackA0101-detail] PRIMARY KEY ([InvoiceNumber], [SequenceNumber]),
)

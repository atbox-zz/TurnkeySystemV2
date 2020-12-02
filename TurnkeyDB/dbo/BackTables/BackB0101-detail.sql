CREATE TABLE [dbo].[BackB0101-detail]
(
    [AllowanceNumber]         NCHAR (16)   NOT NULL,
    [Productitem]             NCHAR (3)    NULL,
    [OriginalInvoiceDate]     NCHAR (8)    NULL,
    [OriginalInvoiceNumber]   NCHAR (10)   NULL,
    [OriginalSequenceNumber]  DECIMAL (18) NULL,
    [OriginalDescription]     NCHAR (256)  NULL,
    [Quantity]                DECIMAL (18) NULL,
    [Unit]                    NCHAR (6)    NULL,
    [UnitPrice]               DECIMAL (18) NULL,
    [Amount]                  DECIMAL (18) NULL,
    [Tax]                     DECIMAL (18) NULL,
    [AllowanceSequenceNumber] NCHAR (3)    NULL,
    [TaxType]                 NCHAR (1)    NULL
)

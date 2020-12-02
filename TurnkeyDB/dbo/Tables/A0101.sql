CREATE TABLE [dbo].[A0101] (
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
    CONSTRAINT [PK_A0101] PRIMARY KEY CLUSTERED ([InvoiceNumber] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'07：一般稅額計算之電子發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'A0101', @level2type = N'COLUMN', @level2name = N'InvoiceType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'捐贈註記列表0：非捐贈發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'A0101', @level2type = N'COLUMN', @level2name = N'DonateMark';


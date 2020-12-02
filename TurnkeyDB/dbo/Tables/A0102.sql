CREATE TABLE [dbo].[A0102] (
    [InvoiceNumber] NCHAR (10) NOT NULL,
    [InvoiceDate]   NCHAR (8)  NULL,
    [BuyerID]       NCHAR (8)  NULL,
    [SellerID]      NCHAR (8)  NULL,
    [ReceiveDate]   NCHAR (8)  NULL,
    [ReceiveTime]   NCHAR (4)  NULL,
    CONSTRAINT [PK_A0102] PRIMARY KEY CLUSTERED ([InvoiceNumber] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'07：一般稅額計算之電子發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'A0102', @level2type = N'COLUMN', @level2name = N'ReceiveDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'捐贈註記列表0：非捐贈發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'A0102', @level2type = N'COLUMN', @level2name = N'ReceiveTime';


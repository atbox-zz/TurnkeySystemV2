CREATE TABLE [dbo].[B0102] (
    [AllowanceNumber] NCHAR (10) NOT NULL,
    [AllowanceDate]   NCHAR (8)  NULL,
    [BuyerID]         NCHAR (8)  NULL,
    [SellerID]        NCHAR (8)  NULL,
    [ReceiveDate]     NCHAR (8)  NULL,
    [ReceiveTime]     NCHAR (4)  NULL,
    [AllowanceType]   NCHAR (1)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'07：一般稅額計算之電子發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'B0102', @level2type = N'COLUMN', @level2name = N'ReceiveDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'捐贈註記列表0：非捐贈發票', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'B0102', @level2type = N'COLUMN', @level2name = N'ReceiveTime';


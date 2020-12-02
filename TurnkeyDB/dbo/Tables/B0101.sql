CREATE TABLE [dbo].[B0101] (
    [AllowanceNumber] NCHAR (16) NOT NULL,
    [AllowanceDate]   NCHAR (8)  NULL,
    [SellerID]        NCHAR (8)  NULL,
    [SellerName]      NCHAR (60) NULL,
    [BuyerID]         NCHAR (8)  NULL,
    [BuyerName]       NCHAR (60) NULL,
    [AllowanceType]   NCHAR (1)  NULL,
    [taxamount]       NCHAR (12) NULL,
    [Totalamount]     NCHAR (12) NULL,
    CONSTRAINT [PK_B0101] PRIMARY KEY CLUSTERED ([AllowanceNumber] ASC)
);


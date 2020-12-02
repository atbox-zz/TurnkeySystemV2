CREATE TABLE [dbo].[B0202] (
    [CancelAllowanceNumber] NCHAR (16) NOT NULL,
    [AllowanceDate]         NCHAR (8)  NULL,
    [BuyerId]               NCHAR (8)  NULL,
    [SellerId]              NCHAR (8)  NULL,
    [CancelDate]            NCHAR (8)  NULL,
    [CancelTime]            NCHAR (4)  NULL,
    CONSTRAINT [PK_B0202] PRIMARY KEY CLUSTERED ([CancelAllowanceNumber] ASC)
);


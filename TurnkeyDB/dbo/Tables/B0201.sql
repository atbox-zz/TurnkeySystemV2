CREATE TABLE [dbo].[B0201] (
    [CancelAllowanceNumber] NCHAR (16) NOT NULL,
    [AllowanceDate]         NCHAR (8)  NULL,
    [BuyerId]               NCHAR (8)  NULL,
    [SellerId]              NCHAR (8)  NULL,
    [CancelDate]            NCHAR (8)  NULL,
    [CancelTime]            NCHAR (4)  NULL,
    [CancelReason]          NCHAR (20) NULL,
    CONSTRAINT [PK_B0201_1] PRIMARY KEY CLUSTERED ([CancelAllowanceNumber] ASC)
);


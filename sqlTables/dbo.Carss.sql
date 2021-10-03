CREATE TABLE [dbo].[Cars] (
    [Id]          INT          NOT NULL,
    [BrandId]     INT          NULL,
    [ColorId]     INT          NULL,
    [ModelYear]   INT          NULL,
    [DailyPrice]  INT          NULL,
    [Description] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[tb_bilheteria] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [descricao]   VARCHAR (50) NULL,
    [dt_evento]   VARCHAR (50) NULL,
    [local]       VARCHAR (50) NULL,
    [qtd_pessoas] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
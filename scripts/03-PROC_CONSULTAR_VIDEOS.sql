SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CONSULTAR_VIDEOS]
AS
    SELECT [Id]
        ,[Titulo]
        ,[Descricao]
        ,[URL_Video]
    FROM [dbo].[Video]
GO;
GO

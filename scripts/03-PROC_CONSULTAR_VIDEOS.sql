
use AluraFlix;


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC CONSULTAR_VIDEOS
AS
    SELECT [Id]
        ,[Titulo]
        ,[Descricao]
        ,[URL_Video]
    FROM [VideoManager].[dbo].[Video]
GO;
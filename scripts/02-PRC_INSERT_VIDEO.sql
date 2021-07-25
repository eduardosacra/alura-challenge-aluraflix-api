use AluraFlix;


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_INSERT_VIDEO]
   @Titulo varchar(255),
   @Descricao varchar(255),
   @URL_Video varchar(255)
AS
BEGIN
    Declare @ID_INSERIDO int

   INSERT INTO Video VALUES (@Titulo, @Descricao, @URL_Video)

    SELECT Id, Titulo, Descricao, URL_Video FROM Video WHERE Id = SCOPE_IDENTITY();

END
GO

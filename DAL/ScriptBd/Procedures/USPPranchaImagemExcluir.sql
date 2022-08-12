PRINT Db_Name()+', Criação da Procedure USPPranchaImagemExcluir'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPranchaImagemExcluir – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPranchaImagemExcluir')
    DROP PROCEDURE USPPranchaImagemExcluir

GO

CREATE PROCEDURE USPPranchaImagemExcluir
		   @IDIMAGEM int
AS
    SET NOCOUNT ON

DELETE FROM TB_PRANCHA_IMAGEM WHERE IDIMAGEM = @IDIMAGEM
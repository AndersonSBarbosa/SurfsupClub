PRINT Db_Name()+', Criação da Procedure USPPranchaImagemDetalhes'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPranchaImagemDetalhes – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPranchaImagemDetalhes')
    DROP PROCEDURE USPPranchaImagemDetalhes

GO

CREATE PROCEDURE USPPranchaImagemDetalhes
		   @IDIMAGEM int
AS
    SET NOCOUNT ON

SELECT
	dbo.TB_PRANCHA_IMAGEM.IDIMAGEM, 
	dbo.TB_PRANCHA_IMAGEM.IDPRANCHA, 
	dbo.TB_PRANCHA_IMAGEM.IMAGEM, 
	dbo.TB_PRANCHA_IMAGEM.CAMINHO, 
	dbo.TB_PRANCHA_IMAGEM.IDSTATUS, 
	dbo.TB_STATUS.[STATUS], 
	dbo.TB_PRANCHA_IMAGEM.DATACADASTRO, 
	dbo.TB_PRANCHA_IMAGEM.IMG, 
	dbo.TB_PRANCHA_IMAGEM.CAPA
FROM dbo.TB_PRANCHA_IMAGEM 
	INNER JOIN
 dbo.TB_STATUS ON dbo.TB_PRANCHA_IMAGEM.IDSTATUS = dbo.TB_STATUS.IDSTATUS
WHERE
	dbo.TB_PRANCHA_IMAGEM.IDIMAGEM = @IDIMAGEM
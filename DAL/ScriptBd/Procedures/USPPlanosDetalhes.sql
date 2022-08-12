PRINT Db_Name()+', Criação da Procedure USPPlanosDetalhes'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPlanosDetalhes – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPlanosDetalhes' )
    DROP PROCEDURE USPPlanosDetalhes

GO

CREATE PROCEDURE USPPlanosDetalhes
		   
		   @IDPLANO INT
AS
    SET NOCOUNT ON

SELECT
	TB_PLANOS.IDPLANO, 
	TB_PLANOS.PLANO, 
	TB_PLANOS.VALOR, 
	TB_PLANOS.DIAS, 
	TB_PLANOS.MENSAL, 
	TB_PLANOS.DATACADASTRO, 
	TB_PLANOS.IDSTATUS, 
	TB_STATUS.[STATUS]
FROM TB_PLANOS 
INNER JOIN
 TB_STATUS ON TB_PLANOS.IDSTATUS = TB_STATUS.IDSTATUS
WHERE 
	TB_PLANOS.IDPLANO = @IDPLANO
 

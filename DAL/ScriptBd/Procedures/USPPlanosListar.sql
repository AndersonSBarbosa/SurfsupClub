PRINT Db_Name()+', Cria��o da Procedure USPPlanosListar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPlanosListar � RESPONS�VEL: Anderson � DATA: 10/10/2018 � 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPlanosListar' )
    DROP PROCEDURE USPPlanosListar

GO

CREATE PROCEDURE USPPlanosListar
		   
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
 

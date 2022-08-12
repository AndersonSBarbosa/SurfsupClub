PRINT Db_Name()+', Criação da Procedure USPCreditoListar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPCreditoListar – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPCreditoListar' )
    DROP PROCEDURE USPCreditoListar

GO

CREATE PROCEDURE USPCreditoListar
		   

		   
AS
    SET NOCOUNT ON

SELECT
		dbo.TB_CREDITOS.IDCREDITO, 
		dbo.TB_CREDITOS.CODINTERNO,
		 dbo.TB_CREDITOS.IDCLIENTE, 
		 dbo.TB_CLIENTE.NOME, 
		 dbo.TB_CLIENTE.SOBRENOME, 
		 dbo.TB_CLIENTE.IDFACEBOOK, 
		 dbo.TB_CLIENTE.EMAIL, 
		 dbo.TB_CREDITOS.QUANTIDADE, 
		 dbo.TB_CREDITOS.IDSTATUS, 
		 dbo.TB_STATUS.[STATUS], 
		 dbo.TB_CREDITOS.DATACADASTRO
FROM         dbo.TB_CLIENTE INNER JOIN
                      dbo.TB_CREDITOS ON dbo.TB_CLIENTE.IDCLIENTE = dbo.TB_CREDITOS.IDCLIENTE INNER JOIN
                      dbo.TB_STATUS ON dbo.TB_CREDITOS.IDSTATUS = dbo.TB_STATUS.IDSTATUS

GO 
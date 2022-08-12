PRINT Db_Name()+', Criação da Procedure USPCreditoDetalhes'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPCreditoDetalhes – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPCreditoDetalhes' )
    DROP PROCEDURE USPCreditoDetalhes

GO

CREATE PROCEDURE USPCreditoDetalhes
		   
		   @IDCLIENTE int
		   
AS
    SET NOCOUNT ON

SELECT
		 TB_CREDITOS.IDCREDITO, 
		 TB_CREDITOS.CODINTERNO,
		 TB_CREDITOS.IDCLIENTE, 
		 TB_CLIENTE.NOME, 
		 TB_CLIENTE.SOBRENOME, 
		 TB_CLIENTE.IDFACEBOOK, 
		 TB_CLIENTE.EMAIL, 
		 TB_CREDITOS.QUANTIDADE, 
		 TB_CREDITOS.IDSTATUS, 
		 TB_STATUS.[STATUS], 
		 TB_CREDITOS.DATACADASTRO
FROM         TB_CLIENTE 
		INNER JOIN
                      TB_CREDITOS ON TB_CLIENTE.IDCLIENTE = TB_CREDITOS.IDCLIENTE 
		INNER JOIN
                      TB_STATUS ON TB_CREDITOS.IDSTATUS = TB_STATUS.IDSTATUS
		where TB_CREDITOS.IDCLIENTE =  @IDCLIENTE

GO 
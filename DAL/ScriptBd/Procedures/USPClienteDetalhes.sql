PRINT Db_Name()+', Criação da Procedure USPClienteDetalhes'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPClienteDetalhes – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPClienteDetalhes' )
    DROP PROCEDURE USPClienteDetalhes

GO

CREATE PROCEDURE USPClienteDetalhes
		   
		   @IDCLIENTE int
		   
AS
    SET NOCOUNT ON

SELECT     
	TB_CLIENTE.IDCLIENTE, 
	TB_CLIENTE.NOME, 
	TB_CLIENTE.SOBRENOME, 
	TB_CLIENTE.IDFACEBOOK, 
	TB_CLIENTE.EMAIL, 
	TB_CLIENTE.CPF, 
	TB_CLIENTE.RG, 
	TB_CLIENTE.ALTURA, 
	TB_CLIENTE.PESO, 
	TB_CLIENTE.DATANASCIMENTO, 
	TB_CLIENTE.ENDERECO, 
	TB_CLIENTE.NUMERO, 
	TB_CLIENTE.COMPLEMENTO, 
	TB_CLIENTE.BAIRRO, 
	TB_CLIENTE.CEP, 
	TB_CLIENTE.CIDADE, 
	TB_CLIENTE.ESTADO, 
	TB_CLIENTE.DATACADASTRO, 
	TB_CLIENTE.CODINTERNO, 
	TB_CLIENTE.IDSTATUS, 
	TB_STATUS.[STATUS]
FROM TB_CLIENTE 
	INNER JOIN
TB_STATUS ON TB_CLIENTE.IDSTATUS = TB_STATUS.IDSTATUS
WHERE
	TB_CLIENTE.IDCLIENTE = @IDCLIENTE
 

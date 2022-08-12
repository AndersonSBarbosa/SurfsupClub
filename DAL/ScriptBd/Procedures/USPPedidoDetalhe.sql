PRINT Db_Name()+', Criação da Procedure USPPedidoDetalhe'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPedidoDetalhe – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPedidoDetalhe' )
    DROP PROCEDURE USPPedidoDetalhe

GO

CREATE PROCEDURE USPPedidoDetalhe
		   @IDPEDIDO INT
AS
    SET NOCOUNT ON

SELECT
	TB_PEDIDO.IDPEDIDO, 
	TB_PEDIDO.IDCLIENTE, 
	TB_CLIENTE.NOME, 
	TB_CLIENTE.SOBRENOME, 
	TB_CLIENTE.IDFACEBOOK, 
	TB_CLIENTE.EMAIL, 
	TB_PEDIDO.DATACADASTRO, 
	TB_PEDIDO.IDSTATUS, 
	TB_STATUS.STATUS, 
	TB_PEDIDO.CODINTERNO
FROM TB_CLIENTE INNER JOIN
TB_PEDIDO ON TB_CLIENTE.IDCLIENTE = TB_PEDIDO.IDCLIENTE 
INNER JOIN
TB_STATUS ON TB_PEDIDO.IDSTATUS = TB_STATUS.IDSTATUS
WHERE TB_PEDIDO.IDPEDIDO = @IDPEDIDO
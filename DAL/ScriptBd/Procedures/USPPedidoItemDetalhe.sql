PRINT Db_Name()+', Criação da Procedure USPPedidoItemDetalhe'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPedidoItemDetalhe – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPedidoItemDetalhe' )
    DROP PROCEDURE USPPedidoItemDetalhe

GO

CREATE PROCEDURE USPPedidoItemDetalhe
		  
		  @IDPEDIDO int
		   
AS
    SET NOCOUNT ON



SELECT
	dbo.TB_PEDIDOITEM.IDITEM, 
	dbo.TB_PEDIDOITEM.IDPEDIDO, 
	dbo.TB_PEDIDOITEM.IDPLANO,
	dbo.TB_PLANOS.PLANO, 
	dbo.TB_PLANOS.VALOR, 
	dbo.TB_PLANOS.DIAS, 
	dbo.TB_PLANOS.MENSAL, 
	dbo.TB_PEDIDOITEM.DATACADASTRO, 
	dbo.TB_PEDIDOITEM.IDSTATUS, 
	dbo.TB_STATUS.[STATUS]
FROM         dbo.TB_PEDIDOITEM INNER JOIN
                      dbo.TB_PLANOS ON dbo.TB_PEDIDOITEM.IDPLANO = dbo.TB_PLANOS.IDPLANO INNER JOIN
                      dbo.TB_STATUS ON dbo.TB_PEDIDOITEM.IDSTATUS = dbo.TB_STATUS.IDSTATUS
WHERE dbo.TB_PEDIDOITEM.IDPEDIDO = @IDPEDIDO
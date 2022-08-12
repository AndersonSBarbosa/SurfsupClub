PRINT Db_Name()+', Criação da Procedure USPUsuarioVincularFornecedores'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioVincularFornecedores – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioVincularFornecedores' )
    DROP PROCEDURE USPUsuarioVincularFornecedores

GO

CREATE PROCEDURE USPUsuarioVincularFornecedores
		   @IDFORNECEDOR int,
		   @IDUSUARIO int
AS
    SET NOCOUNT ON

DECLARE @X int
SET @X = (SELECT COUNT(ID) FROM [TB_FORNECEDORxUSUARIO] WHERE IDFORNECEDOR = @IDFORNECEDOR AND IDUSUARIO = @IDUSUARIO)

IF (@X = 0)
BEGIN
	INSERT INTO [TB_FORNECEDORxUSUARIO]([IDFORNECEDOR], [IDUSUARIO]) VALUES (@IDFORNECEDOR,@IDUSUARIO)
END
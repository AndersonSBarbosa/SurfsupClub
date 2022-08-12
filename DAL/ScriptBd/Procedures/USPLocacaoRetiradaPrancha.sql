PRINT Db_Name()+', Criação da Procedure USPLocacaoRetiradaPrancha'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPLocacaoRetiradaPrancha – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPLocacaoRetiradaPrancha' )
    DROP PROCEDURE USPLocacaoRetiradaPrancha

GO

CREATE PROCEDURE USPLocacaoRetiradaPrancha
		   
		   @IDLOCACAO int,
		   @IDPONTORETIRADAENTREGA int,
		   @IDUSUARIO INt
		   
AS
    SET NOCOUNT ON

-- ALTERAÇÃO

UPDATE TB_LOCACAO
				SET 
					   DATARETIRADAPRANCHALOCAL		= GETDATE()
					  ,IDSTATUS						= 3 
					  ,IDPONTORETIRADA				= @IDPONTORETIRADAENTREGA
					  ,IDUSUARIORETIRADA			= @IDUSUARIO
				WHERE IDLOCACAO = @IDLOCACAO

DECLARE 
	@IDPRANCHA int,
	@IDCLIENTE int 

SET @IDPRANCHA = (SELECT IDPRANCHA FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO)
SET @IDCLIENTE = (SELECT IDCLIENTE FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO)


INSERT INTO [TB_PRANCHA_ESTOQUE]
           (
				[IDPRANCHA]
			   ,[IDSTATUS]
			   ,[DATACADASTRO]
			   ,[IDFORNECEDOR]
			   ,[IDUSUARIO]
			   ,[IDCLIENTE]
		   )
     VALUES
           (
			   @IDPRANCHA
			   ,17 --- 17 -> Saída Emprestimo
			   ,GETDATE()
			   ,@IDPONTORETIRADAENTREGA
			   ,@IDUSUARIO
			   ,@IDCLIENTE
		   )

GO 
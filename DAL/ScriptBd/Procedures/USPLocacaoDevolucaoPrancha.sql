PRINT Db_Name()+', Criação da Procedure USPLocacaoDevolucaoPrancha'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPLocacaoDevolucaoPrancha – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPLocacaoDevolucaoPrancha' )
    DROP PROCEDURE USPLocacaoDevolucaoPrancha

GO

CREATE PROCEDURE USPLocacaoDevolucaoPrancha
		   
		   @IDLOCACAO int,
		   @IDPONTORETIRADAENTREGA int,
		   @IDUSUARIO INt
		   
AS
    SET NOCOUNT ON

DECLARE 
	@IDPRANCHA int,
	@IDCLIENTE int,
	@IDSTATUS int

SET @IDPRANCHA = (SELECT IDPRANCHA FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO)
SET @IDCLIENTE = (SELECT IDCLIENTE FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO)
SET @IDSTATUS  = (SELECT IDSTATUS FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO)


-- 3	Locado	Locacao
-- 4	Devolvido	Locacao
-- 5	Atrasado	Locacao
-- 6	Devolvido c/ Atraso	Locacao

	
If (@IDSTATUS = 3) -- 3	Locado se estiver em dia 
Begin
			-- ALTERAÇÃO
			UPDATE TB_LOCACAO
			   SET 
				   DATADEVOLUCAO				= GETDATE()
				  ,IDSTATUS						= 4 -- Devolvido - Locacao
				  ,IDPONTOENTREGA				= @IDPONTORETIRADAENTREGA
				  ,IDUSUARIOENTREGA				= @IDUSUARIO
			WHERE IDLOCACAO = @IDLOCACAO
-------------------------------------------------------------------------------------------------------------------------------------
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
					   ,16 --- 15	Devolução	Estoque
					   ,GETDATE()
					   ,@IDPONTORETIRADAENTREGA
					   ,@IDUSUARIO
					   ,@IDCLIENTE
				   )
END


If (@IDSTATUS = 5) -- 5 Atrasado
Begin
			-- ALTERAÇÃO
			UPDATE TB_LOCACAO
			SET 
				   DATADEVOLUCAO				= GETDATE()
				  ,IDSTATUS						= 6 --6 Devolvido c/ Atraso	Locacao
				  ,IDPONTOENTREGA				= @IDPONTORETIRADAENTREGA
				  ,IDUSUARIOENTREGA				= @IDUSUARIO
			WHERE IDLOCACAO = @IDLOCACAO

-------------------------------------------------------------------------------------------------------------------------------------
			
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
					   ,16 --- 16	Devolução	Estoque
					   ,GETDATE()
					   ,@IDPONTORETIRADAENTREGA
					   ,@IDUSUARIO
					   ,@IDCLIENTE
				   )
END




GO 
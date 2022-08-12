PRINT Db_Name()+', Criação da Procedure USPLocacaoCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPLocacaoCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPLocacaoCadastroEdicao' )
    DROP PROCEDURE USPLocacaoCadastroEdicao

GO

CREATE PROCEDURE USPLocacaoCadastroEdicao
		   
		   @IDLOCACAO int = NULL  OUTPUT,
		   @IDPRANCHA int ,
		   @IDCLIENTE int ,
		   @IDPLANO int ,
		   @DATARETIRADA date = NULL,
		   @DATAENTREGA date = NULL,
		   @DATADEVOLUCAO datetime = NULL,
		   @IDSTATUS int,
		   @IDPONTORETIRADA int = NULL ,
		   @IDPONTOENTREGA int = NULL,
		   @IDUSUARIO INt = null,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDLOCACAO IS NULL or @IDLOCACAO = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDLOCACAO FROM TB_LOCACAO WHERE IDCLIENTE = @IDCLIENTE AND IDPRANCHA = @IDPRANCHA AND IDPLANO = @IDPLANO AND IDLOCACAO = @IDLOCACAO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate(), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_LOCACAO WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'LO' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO


		DECLARE @DIAS int
		SET @DIAS = (SELECT DIAS FROM TB_PLANOS WHERE IDPLANO = @IDPLANO)
		SET @DATAENTREGA  = (Select DATEADD(Day, @DIAS, @DATARETIRADA))

 INSERT INTO [TB_LOCACAO]
           (
           IDPRANCHA 
           ,IDCLIENTE 
           ,IDPLANO 
           ,DATARETIRADA 
           ,DATAENTREGA
           ,DATADEVOLUCAO
           ,DATACADASTRO
           ,IDSTATUS 
		   ,CODINTERNO
		   ,IDPONTORETIRADA
		   ,IDPONTOENTREGA
           )
     VALUES
           (
            @IDPRANCHA 
           ,@IDCLIENTE 
           ,@IDPLANO 
           ,@DATARETIRADA 
           ,@DATAENTREGA
           ,@DATADEVOLUCAO
           ,GETDATE()
           ,@IDSTATUS 
		   ,@CODINTERNO
		   ,@IDPONTORETIRADA
		   ,@IDPONTOENTREGA
           )

    SET @IDLOCACAO = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDLOCACAO FROM TB_LOCACAO WHERE CODINTERNO = @CODINTERNO AND IDLOCACAO <> @IDLOCACAO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDLOCACAO FROM TB_LOCACAO WHERE IDLOCACAO = @IDLOCACAO )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END

--UPDATE TB_LOCACAO
--   SET 
--	   DATADEVOLUCAO		= @DATADEVOLUCAO
--	  ,IDSTATUS				= @IDSTATUS 
--	  ,IDPONTOENTREGA       = @IDPONTOENTREGA
      
--WHERE IDLOCACAO = @IDLOCACAO


--INSERT INTO [TB_PRANCHA_ESTOQUE]
--           (
--				[IDPRANCHA]
--			   ,[IDSTATUS]
--			   ,[DATACADASTRO]
--			   ,[IDFORNECEDOR]
--			   ,[IDUSUARIO]
--			   ,[IDCLIENTE]
--		   )
--     VALUES
--           (
--			   @IDPRANCHA
--			   ,16 --- 16	Devolução	Estoque
--			   ,GETDATE()
--			   ,@IDPONTOENTREGA
--			   ,0
--			   ,@IDCLIENTE
--		   )


 SET @RESPOSTA = 3

 END

GO 
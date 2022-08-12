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
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDLOCACAO IS NULL
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

UPDATE TB_LOCACAO
   SET 
	   IDPRANCHA     = @IDPRANCHA 
	  ,IDCLIENTE     = @IDCLIENTE 
	  ,IDPLANO       = @IDPLANO 
	  ,DATARETIRADA  = @DATARETIRADA 
	  ,DATAENTREGA   = @DATAENTREGA
	  ,DATADEVOLUCAO = @DATADEVOLUCAO
	  ,IDSTATUS      = @IDSTATUS  
      
WHERE IDLOCACAO = @IDLOCACAO

 SET @RESPOSTA = 3

 END

GO 
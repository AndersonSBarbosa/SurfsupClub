PRINT Db_Name()+', Criação da Procedure USPCreditoCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPCreditoCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPCreditoCadastroEdicao' )
    DROP PROCEDURE USPCreditoCadastroEdicao

GO

CREATE PROCEDURE USPCreditoCadastroEdicao
		   
		   @IDCREDITO INT = NUll OUTPUT,
		   @IDCLIENTE int,
           @QUANTIDADE int,
           @IDSTATUS int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDCREDITO IS NULL OR @IDCREDITO = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS (SELECT IDCREDITO FROM TB_CREDITOS WHERE IDCREDITO = @IDCREDITO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_CREDITOS WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'CL' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

 INSERT INTO [TB_CREDITOS]
           ([IDCLIENTE]
           ,[QUANTIDADE]
           ,[IDSTATUS]
           ,[DATACADASTRO]
           ,[CODINTERNO])
     VALUES
           (
		   @IDCLIENTE,
           @QUANTIDADE,
           @IDSTATUS,
           GETDATE(),
           @CODINTERNO
		   )

    SET @IDCLIENTE = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDCREDITO FROM TB_CREDITOS WHERE CODINTERNO = @CODINTERNO AND IDCREDITO <> @IDCREDITO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDCREDITO FROM TB_CREDITOS WHERE IDCREDITO = @IDCREDITO )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END


UPDATE TB_CREDITOS
   SET 
	  
       [IDCLIENTE]	= @IDCLIENTE
      ,[QUANTIDADE] = @QUANTIDADE
      ,[IDSTATUS]	= @IDSTATUS
      ,[CODINTERNO] = @CODINTERNO
      
WHERE IDCREDITO = @IDCREDITO

 SET @RESPOSTA = 3

 END

GO 
PRINT Db_Name()+', Criação da Procedure USPClienteCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPClienteCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPClienteCadastroEdicao' )
    DROP PROCEDURE USPClienteCadastroEdicao

GO

CREATE PROCEDURE USPClienteCadastroEdicao
		   
		   @IDCLIENTE INT = NUll OUTPUT,
		   @NOME varchar(50) = NULL,
		   @SOBRENOME varchar(80) = NULL,
		   @IDFACEBOOK varchar(30) = NULL,
		   @EMAIL varchar(100) = NULL,
		   @CPF varchar(20)= NULL,
		   @RG varchar(20) = NULL,
		   @ALTURA varchar(4)= NULL,
		   @PESO varchar(4)= NULL,
		   @DATANASCIMENTO date = NULL,
		   @ENDERECO varchar(50) = NULL,
		   @NUMERO varchar(6)= NULL,
		   @COMPLEMENTO varchar(40)= NULL,
		   @BAIRRO varchar(30)= NULL,
		   @CEP varchar(8)= NULL,
		   @CIDADE varchar(50)= NULL,
		   @ESTADO varchar(2) = NULL,
		   @IDSTATUS int = NULL,
		   @SENHA varchar(15) = NULL,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDCLIENTE IS NULL OR @IDCLIENTE = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDCLIENTE FROM TB_ClIENTE WHERE CPF = @CPF OR EMAIL = @EMAIL)
        BEGIN
            SET @RESPOSTA = -1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_ClIENTE WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'CL' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

 INSERT INTO [TB_ClIENTE]
           (
           [NOME]
           ,[SOBRENOME]
           ,[IDFACEBOOK]
           ,[EMAIL]
           ,[CPF]
           ,[RG]
           ,[ALTURA]
           ,[PESO]
           ,[DATANASCIMENTO]
           ,[ENDERECO] 
           ,[NUMERO]
           ,[COMPLEMENTO]
           ,[BAIRRO]
           ,[CEP]
           ,[CIDADE] 
           ,[ESTADO]
		   ,[DATACADASTRO]
		   ,[IDSTATUS]
		   ,[CODINTERNO]
		   ,[SENHA]

           )
     VALUES
           (
            @NOME 
           ,@SOBRENOME
           ,@IDFACEBOOK
           ,@EMAIL
           ,@CPF 
           ,@RG 
           ,@ALTURA
           ,@PESO 
           ,@DATANASCIMENTO
           ,@ENDERECO 
           ,@NUMERO 
           ,@COMPLEMENTO
           ,@BAIRRO 
           ,@CEP 
           ,@CIDADE 
		   ,@ESTADO 
		   ,getdate()
		   ,@IDSTATUS
           ,@CODINTERNO
           ,PWDENCRYPT(@SENHA)
           )

    SET @IDCLIENTE = SCOPE_IDENTITY( )
        SET @RESPOSTA = @IDCLIENTE

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDCLIENTE FROM TB_ClIENTE WHERE CODINTERNO = @CODINTERNO AND IDCLIENTE <> @IDCLIENTE)
        BEGIN
            SET @RESPOSTA = -1
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDCLIENTE FROM TB_ClIENTE WHERE IDCLIENTE = @IDCLIENTE )
        BEGIN
            SET @RESPOSTA = -2
            RETURN
        END


UPDATE TB_ClIENTE
   SET 
	  
	   NOME           = @NOME 
	  ,SOBRENOME      = @SOBRENOME
	  ,IDFACEBOOK     = @IDFACEBOOK
	  ,EMAIL          = @EMAIL
	  ,CPF            = @CPF 
	  ,RG             = @RG 
	  ,ALTURA         = @ALTURA
	  ,PESO           = @PESO 
	  ,DATANASCIMENTO = @DATANASCIMENTO
	  ,ENDERECO       = @ENDERECO 
	  ,NUMERO         = @NUMERO 
	  ,COMPLEMENTO    = @COMPLEMENTO
	  ,BAIRRO         = @BAIRRO 
	  ,CEP            = @CEP 
	  ,CIDADE         = @CIDADE 
	  ,ESTADO         = @ESTADO 
      ,IDSTATUS       = @IDSTATUS
      --,SENHA	      = PWDENCRYPT(@SENHA)

	  
      
WHERE IDCLIENTE = @IDCLIENTE

 SET @RESPOSTA = -3

 END

GO 
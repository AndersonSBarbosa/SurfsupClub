PRINT Db_Name()+', Criação da Procedure USPClienteCadastroTeste'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPClienteCadastroTeste – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPClienteCadastroTeste' )
    DROP PROCEDURE USPClienteCadastroTeste

GO

CREATE PROCEDURE USPClienteCadastroTeste
		   
		   @IDCLIENTE INT = NUll,
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
		   @SENHA VARBINARY (MAX) = NULL
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO

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


GO 
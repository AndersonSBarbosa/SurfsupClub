PRINT Db_Name()+', Criação da Procedure USPUsuarioCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioCadastroEdicao' )
    DROP PROCEDURE USPUsuarioCadastroEdicao

GO

CREATE PROCEDURE USPUsuarioCadastroEdicao
		   
		   @IDUSUARIO INT = NUll OUTPUT,
           @NOME varchar(30),
           @LOGIN varchar(25),
           @SENHA varchar(15),
           @EMAIL varchar(45),
           @IDNIVEL int,
           @IDSTATUS int
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDUSUARIO IS NULL OR @IDUSUARIO = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS (SELECT IDUSUARIO FROM TB_USUARIO WHERE [LOGIN] = @LOGIN OR EMAIL = @EMAIL)
        BEGIN
            SET @IDUSUARIO = 1
            RETURN
        END
		ELSE
-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        --DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        --DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_ClIENTE WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        --DECLARE @CODINTERNO VARCHAR(80) = 'CL' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

		DECLARE @SENHA2 varbinary(100)
		SET @SENHA2 = Convert(varbinary(100), pwdEncrypt(@SENHA))

	INSERT INTO [TB_USUARIO]
           (
           [NOME]
           ,[LOGIN]
           ,[SENHA]
           ,[EMAIL]
           ,[IDNIVEL]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           )
     VALUES
           (
           @NOME,
           @LOGIN,
           @SENHA2,
           @EMAIL,
           @IDNIVEL,
           GETDATE(),
           @IDSTATUS
           )

    SET @IDUSUARIO = SCOPE_IDENTITY( )
END

GO 
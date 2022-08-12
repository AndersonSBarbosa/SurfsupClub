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
           @IDSTATUS int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDUSUARIO IS NULL
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDUSUARIO FROM TB_USUARIO WHERE [LOGIN] = @LOGIN AND EMAIL = @EMAIL)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        --DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        --DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_ClIENTE WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        --DECLARE @CODINTERNO VARCHAR(80) = 'CL' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

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
           @SENHA,
           @EMAIL,
           @IDNIVEL,
           GETDATE(),
           @IDSTATUS
           )

    SET @IDUSUARIO = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDUSUARIO FROM TB_USUARIO WHERE IDUSUARIO <> @IDUSUARIO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDUSUARIO FROM TB_USUARIO WHERE IDUSUARIO = @IDUSUARIO )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END


UPDATE TB_USUARIO
   SET 
	  
	  [NOME] = @NOME,
      [LOGIN] = @LOGIN,
      [SENHA] = @SENHA,
      [EMAIL] = @EMAIL,
      [IDNIVEL] = @IDNIVEL,
      [IDSTATUS] = @IDSTATUS
      
WHERE IDUSUARIO = @IDUSUARIO

 SET @RESPOSTA = 3

 END

GO 
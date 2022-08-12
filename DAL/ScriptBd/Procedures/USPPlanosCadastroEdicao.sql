PRINT Db_Name()+', Criação da Procedure USPPlanosCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPlanosCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPlanosCadastroEdicao' )
    DROP PROCEDURE USPPlanosCadastroEdicao

GO

CREATE PROCEDURE USPPlanosCadastroEdicao

		   @IDPLANO INT = NUll OUTPUT, 
           @PLANO varchar(30),
           @VALOR DECIMAL(18,2),
           @DIAS INT,
           @MENSAL BIT,
           @IDSTATUS int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'| 


AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDPLANO IS NULL OR @IDPLANO = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDPLANO FROM TB_PLANOS WHERE DIAS = @DIAS AND VALOR = @VALOR AND MENSAL = @MENSAL)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        --DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        --DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PLANOS WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        --DECLARE @CODINTERNO VARCHAR(80) = 'FO' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

 INSERT INTO [TB_PLANOS]
           (
            [PLANO]
           ,[VALOR]
           ,[DIAS]
           ,[MENSAL]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           )
     VALUES
           (
           @PLANO,
           @VALOR,
           @DIAS,
           @MENSAL,  
           GETDATE(),
           @IDSTATUS
           )

    SET @IDPLANO = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0 -- OK

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDPLANO FROM TB_PLANOS  WHERE DIAS = @DIAS AND VALOR = @VALOR AND MENSAL = @MENSAL AND IDPLANO <> @IDPLANO)
        BEGIN
            SET @RESPOSTA = 1 -- 'JE' REGISTRO JÁ EXISTE
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDPLANO FROM TB_PLANOS WHERE IDPLANO = @IDPLANO )
        BEGIN
            SET @RESPOSTA = 2 -- 'RE' REGISTRO EXCLUÍDO
            RETURN
        END


UPDATE TB_PLANOS
   SET 
	  [PLANO]			= @PLANO,
      [VALOR]			= @VALOR,
      [DIAS]			= @DIAS,
      [MENSAL]			= @MENSAL,
      [IDSTATUS]		= @IDSTATUS

WHERE IDPLANO = @IDPLANO

 SET @RESPOSTA = 3 -- ATUALIZADO

 END

GO 
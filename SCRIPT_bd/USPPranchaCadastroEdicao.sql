PRINT Db_Name()+', Criação da Procedure USPPranchaCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPranchaCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 27/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPranchaCadastroEdicao' )
    DROP PROCEDURE USPPranchaCadastroEdicao

GO

CREATE PROCEDURE USPPranchaCadastroEdicao
		   
		   @IDPRANCHA int = NULL  OUTPUT,
           @PRANCHA varchar(30),
           @DESCRICAO varchar(90),
           @VOLUME varchar(10),
           @POLEGADAS varchar(10),
           @ESPESSURA varchar(10),
           @IDFORNECEDOR int,
           @IDSTATUS int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDPRANCHA IS NULL
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDPRANCHA FROM TB_PRANCHA WHERE IDPRANCHA = @IDPRANCHA )
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PRANCHA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'PR' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

INSERT INTO [TB_PRANCHA]
           ([PRANCHA]
           ,[DESCRICAO]
           ,[VOLUME]
           ,[POLEGADAS]
           ,[ESPESSURA]
           ,[IDFORNECEDOR]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           ,[CODINTERNO])
     VALUES
           (
           @PRANCHA,
           @DESCRICAO,
           @VOLUME,
           @POLEGADAS,
           @ESPESSURA,
           @IDFORNECEDOR,
           Getdate(),
           @IDSTATUS,
           @CODINTERNO
           )

    SET @IDPRANCHA = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDPRANCHA FROM TB_PRANCHA WHERE CODINTERNO = @CODINTERNO AND IDPRANCHA <> @IDPRANCHA)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDPRANCHA FROM TB_PRANCHA WHERE IDPRANCHA = @IDPRANCHA )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END

UPDATE [TB_PRANCHA]
   SET
      [PRANCHA] = @PRANCHA,
      [DESCRICAO] = @DESCRICAO,
      [VOLUME] = @VOLUME,
      [POLEGADAS] = @POLEGADAS,
      [ESPESSURA] = @ESPESSURA, 
      [IDFORNECEDOR] = @IDFORNECEDOR,
      [IDSTATUS] = @IDSTATUS
 WHERE IDPRANCHA = @IDPRANCHA

 SET @RESPOSTA = 3

 END

GO 
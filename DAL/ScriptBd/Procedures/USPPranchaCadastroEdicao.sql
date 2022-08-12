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
           @IDMARCA int,
           @IDMODELO int,
           @TAMANHO varchar(10),
           @LARGURA varchar(10),
           @BORDA varchar(10),
           @LITRAGEM varchar(10),
           @IDMODALIDADE int,
		   @IDTIPOITEM int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDPRANCHA IS NULL or @IDPRANCHA = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDPRANCHA FROM TB_PRANCHA WHERE IDPRANCHA = @IDPRANCHA )
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END



-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: PR12000001)
        DECLARE @ANO CHAR(2) --= Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT --= (SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PRANCHA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80)
        
        
        Declare @SIGLA varchar(2)
IF(@IDTIPOITEM = 1)
Begin
SET @SIGLA = 'PR'
SET @ANO = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
SET @IDENTNUM = (SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PRANCHA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
SET @CODINTERNO = @SIGLA + @ANO + dbo.FormatarZerosA( @IDENTNUM, 6, 2 )
END

IF(@IDTIPOITEM = 2)
Begin
SET @ANO = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
SET @IDENTNUM = (SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PRANCHA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
SET @SIGLA = 'CO'
SET @CODINTERNO = @SIGLA + @ANO + dbo.FormatarZerosB( @IDENTNUM, 6, 2 )
END

IF(@IDTIPOITEM = 3)
Begin
SET @ANO = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
SET @IDENTNUM = (SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PRANCHA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
SET @SIGLA = 'QU'
SET @CODINTERNO = @SIGLA + @ANO + dbo.FormatarZerosC( @IDENTNUM, 6, 2 )
END
        
        
        
        
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
           ,[CODINTERNO]
		   ,[IDMARCA]
           ,[IDMODELO]
           ,[TAMANHO]
           ,[LARGURA]
           ,[BORDA]
           ,[LITRAGEM]
           ,[IDMODALIDADE]
		   ,[IDTIPOITEM])
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
           @CODINTERNO,
		   @IDMARCA,
           @IDMODELO,
           @TAMANHO,
           @LARGURA,
           @BORDA,
           @LITRAGEM,
           @IDMODALIDADE,
		   @IDTIPOITEM
           )

    SET @IDPRANCHA = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

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
			   ,14 -- 14	Entrada	Estoque
			   ,GETDATE()
			   ,@IDFORNECEDOR
			   ,0
			   ,0
		   )


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
        IF NOT EXISTS (SELECT IDPRANCHA FROM TB_PRANCHA WHERE IDPRANCHA = @IDPRANCHA )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END

UPDATE [TB_PRANCHA]
   SET
      [PRANCHA]			= @PRANCHA,
      [DESCRICAO]		= @DESCRICAO,
      [VOLUME]			= @VOLUME,
      [POLEGADAS]		= @POLEGADAS,
      [ESPESSURA]		= @ESPESSURA, 
      [IDFORNECEDOR]	= @IDFORNECEDOR,
      [IDSTATUS]		= @IDSTATUS,
	  [IDMARCA]			= @IDMARCA,
      [IDMODELO]		= @IDMODELO, 
      [TAMANHO]			= @TAMANHO, 
      [LARGURA]			= @LARGURA, 
      [BORDA]			= @BORDA,
      [LITRAGEM]		= @LITRAGEM, 
      [IDMODALIDADE]	= @IDMODALIDADE,
	  [IDTIPOITEM]		= @IDTIPOITEM

 WHERE IDPRANCHA = @IDPRANCHA

 SET @RESPOSTA = 3

 END

GO 
PRINT Db_Name()+', Criação da Procedure USPFornecedorCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPFornecedorCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPFornecedorCadastroEdicao' )
    DROP PROCEDURE USPFornecedorCadastroEdicao

GO

CREATE PROCEDURE USPFornecedorCadastroEdicao

		   @IDFORNECEDOR INT = NUll OUTPUT, 
           @NOMEFANTASIA varchar(40),
           @RAZAOSOCIAL varchar(60),
           @CNPJ varchar(20),
           @ENDERECO varchar(50),
           @NUMERO varchar(6),
           @COMPLEMENTO varchar(40),
           @BAIRRO varchar(30),
           @CEP varchar(8),
           @CIDADE varchar(50),
           @ESTADO varchar(2),
           @IDSTATUS int,
           @IE varchar(50),
           @EMAIL varchar(40),
           @LATITUDE varchar(20),
           @LONGITUDE varchar(20),
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'| 


AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDFORNECEDOR IS NULL OR @IDFORNECEDOR = 0
    BEGIN
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS ( SELECT IDFORNECEDOR FROM TB_FORNECEDOR WHERE CNPJ = @CNPJ)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_FORNECEDOR WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'FO' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO

 INSERT INTO [TB_FORNECEDOR]
           (
            [NOMEFANTASIA]
           ,[RAZAOSOCIAL]
           ,[CNPJ]
           ,[ENDERECO]
           ,[NUMERO]
           ,[COMPLEMENTO]
           ,[BAIRRO]
           ,[CEP]
           ,[CIDADE]
           ,[ESTADO]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           ,[IE]
           ,[EMAIL]
           ,[LATITUDE]
           ,[LONGITUDE]
           ,[CODINTERNO]
           )
     VALUES
           (
           @NOMEFANTASIA,
           @RAZAOSOCIAL,
           @CNPJ,
           @ENDERECO, 
           @NUMERO, 
           @COMPLEMENTO, 
           @BAIRRO,
           @CEP, 
           @CIDADE,
           @ESTADO, 
           GETDATE(),
           @IDSTATUS,
           @IE,
           @EMAIL, 
           @LATITUDE, 
           @LONGITUDE,
           @CODINTERNO
           )

    SET @IDFORNECEDOR = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0 -- OK

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDFORNECEDOR FROM TB_FORNECEDOR WHERE CODINTERNO = @CODINTERNO AND IDFORNECEDOR <> @IDFORNECEDOR)
        BEGIN
            SET @RESPOSTA = 1 -- 'JE' REGISTRO JÁ EXISTE
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDFORNECEDOR FROM TB_FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR )
        BEGIN
            SET @RESPOSTA = 2 -- 'RE' REGISTRO EXCLUÍDO
            RETURN
        END


UPDATE TB_FORNECEDOR
   SET 
	  [NOMEFANTASIA] = @NOMEFANTASIA,
      [RAZAOSOCIAL] = @RAZAOSOCIAL,
      [CNPJ] = @CNPJ,
      [ENDERECO] = @ENDERECO,
      [NUMERO] = @NUMERO,
      [COMPLEMENTO] = @COMPLEMENTO,
      [BAIRRO] = @BAIRRO,
      [CEP] = @CEP,
      [CIDADE] = @CIDADE,
      [ESTADO] = @ESTADO,
      [IDSTATUS] = @IDSTATUS,
      [IE] = @IE,
      [EMAIL] = @EMAIL,
      [LATITUDE] = @LATITUDE,
      [LONGITUDE] = @LONGITUDE
      
WHERE IDFORNECEDOR = @IDFORNECEDOR

 SET @RESPOSTA = 3 -- ATUALIZADO

 END

GO 
PRINT Db_Name()+', Criação da Procedure USPPontoRetiradaCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPontoRetiradaCadastroEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPontoRetiradaCadastroEdicao' )
    DROP PROCEDURE USPPontoRetiradaCadastroEdicao

GO

CREATE PROCEDURE USPPontoRetiradaCadastroEdicao

		   @IDPONTORETIRADA INT = NUll OUTPUT, 
           @NOMEFANTASIA varchar(40),
           @RAZAOSOCIAL varchar(60),
           @CNPJ varchar(20),
           @IE varchar(50),
           @ENDERECO varchar(50),
           @NUMERO varchar(6),
           @COMPLEMENTO varchar(40),
           @BAIRRO varchar(30),
           @CEP varchar(8),
           @CIDADE varchar(50),
           @ESTADO varchar(2),
           @EMAIL varchar(50),
           @IDSTATUS int,
           @LATITUDE varchar(20),
           @LONGITUDE varchar(20),
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUSÃO
       IF @IDPONTORETIRADA IS NULL
    BEGIN
    
        --VERIFICA SE O PROCESSO JÁ EXISTE
        IF EXISTS (SELECT IDPONTORETIRADA FROM TB_PONTORETIRADA WHERE CNPJ = @CNPJ)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O CÓDIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_PONTORETIRADA WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'PR' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )
        
        --SET @GG0001OY2485BL0003 = @CODINTERNO

INSERT INTO [TB_PONTORETIRADA]
           (
			   [NOMEFANTASIA],
			   [RAZAOSOCIAL],
			   [CNPJ],
			   [IE],
			   [ENDERECO],
			   [NUMERO],
			   [COMPLEMENTO],
			   [BAIRRO],
			   [CEP],
			   [CIDADE],
			   [ESTADO],
			   [EMAIL],
			   [IDSTATUS],
			   [DATACADASTRO],
			   [LATITUDE],
			   [LONGITUDE],
			   [CODINTERNO]
           )
     VALUES
           (
			   @NOMEFANTASIA,
			   @RAZAOSOCIAL,
			   @CNPJ,
			   @IE, 
			   @ENDERECO,
			   @NUMERO,
			   @COMPLEMENTO,
			   @BAIRRO,
			   @CEP,
			   @CIDADE,
			   @ESTADO,
			   @EMAIL,
			   @IDSTATUS,
			   GETDATE(),
			   @LATITUDE,
			   @LONGITUDE,
			   @CODINTERNO
           )

    SET @IDPONTORETIRADA = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERAÇÃO
ELSE
BEGIN

--VERIFICA SE O REGISTRO JÁ EXISTE
        IF EXISTS ( SELECT IDPONTORETIRADA FROM TB_PONTORETIRADA WHERE CODINTERNO = @CODINTERNO AND IDPONTORETIRADA <> @IDPONTORETIRADA)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END


--VERIFICA SE O REGISTRO EXCLUÍDO
        IF NOT EXISTS ( SELECT IDPONTORETIRADA FROM TB_PONTORETIRADA WHERE IDPONTORETIRADA = @IDPONTORETIRADA )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END


UPDATE TB_PONTORETIRADA
   SET 
	  [NOMEFANTASIA] = @NOMEFANTASIA, 
      [RAZAOSOCIAL] = @RAZAOSOCIAL,
      [CNPJ] = @CNPJ,
      [IE] = @IE,
      [ENDERECO] = @ENDERECO,
      [NUMERO] = @NUMERO,
      [COMPLEMENTO] = @COMPLEMENTO,
      [BAIRRO] = @BAIRRO,
      [CEP] = @CEP,
      [CIDADE] = @CIDADE,
      [ESTADO] = @ESTADO,
      [EMAIL] = @EMAIL,
      [IDSTATUS] = @IDSTATUS,
      [LATITUDE] = @LATITUDE,
      [LONGITUDE] = @LONGITUDE 
WHERE IDPONTORETIRADA = @IDPONTORETIRADA

SET @RESPOSTA = 3

 END

GO 
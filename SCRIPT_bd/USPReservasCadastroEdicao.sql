PRINT Db_Name()+', Cria��o da Procedure USPReservasCadastroEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPReservasCadastroEdicao � RESPONS�VEL: Anderson � DATA: 27/10/2018 � 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPReservasCadastroEdicao' )
    DROP PROCEDURE USPReservasCadastroEdicao

GO

CREATE PROCEDURE USPReservasCadastroEdicao

           @IDRESERVA int = NULL  OUTPUT,
           @IDPRANCHA int,
           @IDCLIENTE int,
           @IDPLANO int,
           @DATARETIRADA date,
           @DATAENTREGA date,
           @IDSTATUS int,
		   @RESPOSTA int = 0 OUTPUT -- -- RETORNO   0 => 'OK'| 1 => 'JE'| 2 => 'RE'| 3 => 'ATUALIZADO'|
		   
AS
    SET NOCOUNT ON

   -- INCLUS�O
       IF @IDRESERVA IS NULL
    BEGIN
        --VERIFICA SE O PROCESSO J� EXISTE
        IF EXISTS ( SELECT IDRESERVA FROM TB_RESERVAS WHERE IDRESERVA = @IDRESERVA )
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

-- RECUPERA O C�DIGO INTERNO (EXEMPLO: CS12000001)
        DECLARE @ANO CHAR(2) = Substring( CONVERT( VARCHAR, Getdate( ), 12 ), 1, 2 )
        DECLARE @IDENTNUM INT = ( SELECT Max( CONVERT( INT, Substring( CODINTERNO, 5, 11 ) ) )FROM TB_RESERVAS WHERE Substring( CONVERT( VARCHAR, Datepart( YEAR, DATACADASTRO ) ), 3, 5 ) = @ANO ) + 1
        DECLARE @CODINTERNO VARCHAR(80) = 'RE' + @ANO + dbo.FormatarZeros( @IDENTNUM, 6, 2 )

        --SET @GG0001OY2485BL0003 = @CODINTERNO
           INSERT INTO [TB_RESERVAS]
           (
           [IDPRANCHA]
           ,[IDCLIENTE]
           ,[IDPLANO]
           ,[DATARETIRADA]
           ,[DATAENTREGA]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           ,[CODINTERNO]
           )
     VALUES
           (
           @IDPRANCHA,
           @IDCLIENTE,
           @IDPLANO,
           @DATARETIRADA,
           @DATAENTREGA,
           Getdate(),
           @IDSTATUS,
           @CODINTERNO
           )
           

    SET @IDRESERVA = SCOPE_IDENTITY( )
        SET @RESPOSTA = 0

RETURN
END

-- ALTERA��O
ELSE
BEGIN

--VERIFICA SE O REGISTRO J� EXISTE
        IF EXISTS ( SELECT IDRESERVA FROM TB_RESERVAS WHERE IDRESERVA <> @IDRESERVA AND CODINTERNO = @CODINTERNO)
        BEGIN
            SET @RESPOSTA = 1
            RETURN
        END

--VERIFICA SE O REGISTRO EXCLU�DO
        IF NOT EXISTS ( SELECT IDRESERVA FROM TB_RESERVAS WHERE IDRESERVA = @IDRESERVA )
        BEGIN
            SET @RESPOSTA = 2
            RETURN
        END

 UPDATE [TB_RESERVAS]
   SET [IDPRANCHA] = @IDPRANCHA
      ,[IDCLIENTE] = @IDCLIENTE
      ,[IDPLANO] = @IDPLANO
      ,[DATARETIRADA] = @DATARETIRADA
      ,[DATAENTREGA] = @DATAENTREGA
      ,[IDSTATUS] = @IDSTATUS
 WHERE IDRESERVA = @IDRESERVA

 SET @RESPOSTA = 3

 END

GO 
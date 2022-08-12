PRINT Db_Name()+', Criação da Procedure USPPranchaImagemCadastro'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPPranchaImagemCadastro – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPPranchaImagemCadastro' )
    DROP PROCEDURE USPPranchaImagemCadastro

GO

-- =============================================
CREATE PROCEDURE USPPranchaImagemCadastro
	-- Add the parameters for the stored procedure here

           @IDPRANCHA int,
           @IMAGEM varchar(500),
           @CAMINHO varchar(500),
           @CAPA bit,
           @IDSTATUS int,
		   @IMG varchar(500)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	INSERT INTO [TB_PRANCHA_IMAGEM]
           ([IDPRANCHA]
           ,[IMAGEM]
           ,[CAMINHO]
           ,[CAPA]
           ,[IDSTATUS]
           ,[DATACADASTRO]
		   ,[IMG])
     VALUES
           (
		   @IDPRANCHA,
           @IMAGEM,
           @CAMINHO,
           @CAPA,
           @IDSTATUS,
           GETDATE(),
		   @IMG
		   )
	
	
END
GO

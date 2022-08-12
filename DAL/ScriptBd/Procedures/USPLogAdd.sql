-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anderson Barbosa
-- Create date: 28/10/2018
-- Description:	GravarLog
-- =============================================
CREATE PROCEDURE USPLogAdd
	-- Add the parameters for the stored procedure here

	       @IDCLIENTE int,
           @IDUSUARIO int,
           @IDPRANCHA int,
           @IDFORNECEDOR int,
           @IDRESERVA int,
           @IDPEDIDO int,
           @IDATVIDADE int,
           @IP varchar(20),
           @OBS varchar,
           @IDSTATUS int,
           @CODINTERNO varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	INSERT INTO [TB_LOG]
           (
            [IDCLIENTE]
           ,[IDUSUARIO]
           ,[IDPRANCHA]
           ,[IDFORNECEDOR]
           ,[IDRESERVA]
           ,[IDPEDIDO]
           ,[IDATVIDADE]
           ,[IP]
           ,[OBS]
           ,[DATACADASTRO]
           ,[IDSTATUS]
           ,[CODINTERNO]
           )
     VALUES
           (
	       @IDCLIENTE,
           @IDUSUARIO,
           @IDPRANCHA,
           @IDFORNECEDOR,
           @IDRESERVA,
           @IDPEDIDO,
           @IDATVIDADE,
           @IP,
           @OBS,
           GETDATE(),
           @IDSTATUS,
           @CODINTERNO
           )
	
	
END
GO

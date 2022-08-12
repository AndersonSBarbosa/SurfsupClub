PRINT Db_Name()+', Cria��o da Procedure USPUsuarioDetalhe'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioDetalhe � RESPONS�VEL: Anderson � DATA: 10/10/2018 � 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioDetalhe' )
    DROP PROCEDURE USPUsuarioDetalhe

GO

CREATE PROCEDURE USPUsuarioDetalhe
		   @IDUSUARIO int
AS
    SET NOCOUNT ON

SELECT
	TB_USUARIO.IDUSUARIO, 
	TB_USUARIO.NOME, 
	TB_USUARIO.[LOGIN], 
	TB_USUARIO.SENHA, 
	TB_USUARIO.EMAIL, 
	TB_USUARIO.IDNIVEL, 
	TB_USUARIO.DATACADASTRO, 
	TB_USUARIO.IDSTATUS, 
	TB_STATUS.[STATUS]
	
FROM  TB_USUARIO 
	INNER JOIN
TB_STATUS ON TB_USUARIO.IDSTATUS = TB_STATUS.IDSTATUS
where TB_USUARIO.IDUSUARIO = @IDUSUARIO
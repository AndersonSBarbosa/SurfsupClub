PRINT Db_Name()+', Criação da Procedure USPUsuarioListar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioListar – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioListar' )
    DROP PROCEDURE USPUsuarioListar

GO

CREATE PROCEDURE USPUsuarioListar
		   
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
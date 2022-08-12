PRINT Db_Name()+', Criação da Procedure USPUsuarioBuscar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioBuscar – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioBuscar' )
    DROP PROCEDURE USPUsuarioBuscar

GO

CREATE PROCEDURE USPUsuarioBuscar
		   @BUSCAR varchar(50) = null
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
WHERE
	(TB_USUARIO.NOME  like '%'+@BUSCAR+'%') or (TB_USUARIO.NOME  like '%'+@BUSCAR)
or
	(TB_USUARIO.[LOGIN]  like '%'+@BUSCAR+'%') or (TB_USUARIO.[LOGIN]  like '%'+@BUSCAR)
 or
	(TB_USUARIO.EMAIL  like '%'+@BUSCAR+'%') or (TB_USUARIO.EMAIL  like '%'+@BUSCAR)


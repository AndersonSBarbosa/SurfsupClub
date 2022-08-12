PRINT Db_Name()+', Criação da Procedure USPUsuarioEdicao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioEdicao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioEdicao' )
    DROP PROCEDURE USPUsuarioEdicao

GO

CREATE PROCEDURE USPUsuarioEdicao
		   
		   @IDUSUARIO INT,
           @NOME varchar(30),
           @LOGIN varchar(25),
           @EMAIL varchar(45),
           @IDNIVEL int,
           @IDSTATUS int
		   
AS
    SET NOCOUNT ON

	UPDATE [TB_USUARIO]
   SET [NOME] = @NOME,
       [LOGIN] = @LOGIN,
       [IDNIVEL] = @IDNIVEL,
       [IDSTATUS] = @IDSTATUS
 WHERE IDUSUARIO = @IDUSUARIO

GO 
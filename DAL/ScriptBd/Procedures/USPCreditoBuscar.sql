PRINT Db_Name()+', Criação da Procedure USPCreditoBuscar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPCreditoBuscar – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPCreditoBuscar' )
    DROP PROCEDURE USPCreditoBuscar

GO

CREATE PROCEDURE USPCreditoBuscar
		   
		   @NOMECOMPLETO varchar(40),
		   @CODINTERNO varchar(40)
		   
AS
    SET NOCOUNT ON

SELECT
		 TB_CREDITOS.IDCREDITO, 
		 TB_CREDITOS.CODINTERNO,
		 TB_CREDITOS.IDCLIENTE, 
		 TB_CLIENTE.NOME, 
		 TB_CLIENTE.SOBRENOME, 
		 TB_CLIENTE.IDFACEBOOK, 
		 TB_CLIENTE.EMAIL, 
		 TB_CREDITOS.QUANTIDADE, 
		 TB_CREDITOS.IDSTATUS, 
		 TB_STATUS.[STATUS], 
		 TB_CREDITOS.DATACADASTRO
FROM         TB_CLIENTE 
		INNER JOIN
                      TB_CREDITOS ON TB_CLIENTE.IDCLIENTE = TB_CREDITOS.IDCLIENTE 
		INNER JOIN
                      TB_STATUS ON TB_CREDITOS.IDSTATUS = TB_STATUS.IDSTATUS
		where 

--(TB_CLIENTE.CPF  like '%'+@CPF+'%') or (TB_CLIENTE.CPF  like '%'+@CPF)
--or
	(TB_CLIENTE.NOME  like '%'+@NOMECOMPLETO+'%') or (TB_CLIENTE.NOME  like '%'+@NOMECOMPLETO)
or
	(TB_CLIENTE.SOBRENOME  like '%'+@NOMECOMPLETO+'%') or (TB_CLIENTE.SOBRENOME  like '%'+@NOMECOMPLETO)
 or
	(TB_CREDITOS.CODINTERNO  like '%'+@CODINTERNO+'%') or (TB_LOCACAO.CODINTERNO  like '%'+@CODINTERNO)

GO 
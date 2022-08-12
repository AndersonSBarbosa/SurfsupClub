PRINT Db_Name()+', Cria��o da Procedure USPUsuarioFornecedorListar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPUsuarioFornecedorListar � RESPONS�VEL: Anderson � DATA: 10/10/2018 � 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPUsuarioFornecedorListar' )
    DROP PROCEDURE USPUsuarioFornecedorListar

GO

CREATE PROCEDURE USPUsuarioFornecedorListar
		 
	@CARREGAMENTO int = null ,     -- (0 Todos - 1 Fornecedor - 2 Usuario)
	@IDFORNECEDOR int = null,
	@IDUSUARIO int = null
		   
AS
    SET NOCOUNT ON

IF (@CARREGAMENTO = null or @CARREGAMENTO = 0)
BEGIN

	SELECT
		TB_FORNECEDORxUSUARIO.ID, 
		TB_FORNECEDORxUSUARIO.IDFORNECEDOR, 
		TB_FORNECEDOR.NOMEFANTASIA, 
		TB_FORNECEDOR.RAZAOSOCIAL, 
		TB_FORNECEDOR.CNPJ, 
		TB_FORNECEDOR.ENDERECO, 
		TB_FORNECEDOR.NUMERO,
		TB_FORNECEDOR.COMPLEMENTO, 
		TB_FORNECEDOR.CEP, 
		TB_FORNECEDOR.BAIRRO, 
		TB_FORNECEDOR.CIDADE, 
		TB_FORNECEDOR.ESTADO, 
		TB_FORNECEDOR.DATACADASTRO, 
		TB_FORNECEDOR.IE, 
		TB_FORNECEDOR.EMAIL, 
		TB_FORNECEDOR.LATITUDE, 
		TB_FORNECEDOR.LONGITUDE, 
		TB_FORNECEDOR.CODINTERNO, 
		TB_FORNECEDOR.TELEFONE1, 
		TB_FORNECEDOR.TELEFONE2, 
		TB_FORNECEDOR.TELEFONE3, 
		TB_FORNECEDOR.TELEFONE4, 
		TB_FORNECEDOR.PONTOENTREGARETIRADA, 
		TB_FORNECEDOR.FABRICANTE, 
		TB_FORNECEDOR.IDSTATUS AS IDSTATUSFORNECEDOR, 
		TB_FORNECEDORxUSUARIO.IDUSUARIO, 
		TB_USUARIO.NOME, 
		TB_USUARIO.[LOGIN], 
		TB_USUARIO.SENHA, 
		TB_USUARIO.EMAIL AS EMAILUSUARIO, 
		TB_USUARIO.IDNIVEL, 
		TB_USUARIO.IDSTATUS AS IDSTATUSUSUARIO, 
		TB_USUARIO.FOTO
	FROM TB_FORNECEDOR 
		INNER JOIN
	TB_FORNECEDORxUSUARIO ON TB_FORNECEDOR.IDFORNECEDOR = TB_FORNECEDORxUSUARIO.IDFORNECEDOR 
		INNER JOIN
	TB_USUARIO ON TB_FORNECEDORxUSUARIO.IDUSUARIO = TB_USUARIO.IDUSUARIO

END


IF (@CARREGAMENTO = 1)
BEGIN

	SELECT
		TB_FORNECEDORxUSUARIO.ID, 
		TB_FORNECEDORxUSUARIO.IDFORNECEDOR, 
		TB_FORNECEDOR.NOMEFANTASIA, 
		TB_FORNECEDOR.RAZAOSOCIAL, 
		TB_FORNECEDOR.CNPJ, 
		TB_FORNECEDOR.ENDERECO, 
		TB_FORNECEDOR.NUMERO,
		TB_FORNECEDOR.COMPLEMENTO, 
		TB_FORNECEDOR.CEP, 
		TB_FORNECEDOR.BAIRRO, 
		TB_FORNECEDOR.CIDADE, 
		TB_FORNECEDOR.ESTADO, 
		TB_FORNECEDOR.DATACADASTRO, 
		TB_FORNECEDOR.IE, 
		TB_FORNECEDOR.EMAIL, 
		TB_FORNECEDOR.LATITUDE, 
		TB_FORNECEDOR.LONGITUDE, 
		TB_FORNECEDOR.CODINTERNO, 
		TB_FORNECEDOR.TELEFONE1, 
		TB_FORNECEDOR.TELEFONE2, 
		TB_FORNECEDOR.TELEFONE3, 
		TB_FORNECEDOR.TELEFONE4, 
		TB_FORNECEDOR.PONTOENTREGARETIRADA, 
		TB_FORNECEDOR.FABRICANTE, 
		TB_FORNECEDOR.IDSTATUS AS IDSTATUSFORNECEDOR, 
		TB_FORNECEDORxUSUARIO.IDUSUARIO, 
		TB_USUARIO.NOME, 
		TB_USUARIO.[LOGIN], 
		TB_USUARIO.SENHA, 
		TB_USUARIO.EMAIL AS EMAILUSUARIO, 
		TB_USUARIO.IDNIVEL, 
		TB_USUARIO.IDSTATUS AS IDSTATUSUSUARIO, 
		TB_USUARIO.FOTO
	FROM TB_FORNECEDOR 
		INNER JOIN
	TB_FORNECEDORxUSUARIO ON TB_FORNECEDOR.IDFORNECEDOR = TB_FORNECEDORxUSUARIO.IDFORNECEDOR 
		INNER JOIN
	TB_USUARIO ON TB_FORNECEDORxUSUARIO.IDUSUARIO = TB_USUARIO.IDUSUARIO
	WHERE TB_FORNECEDORxUSUARIO.IDFORNECEDOR = @IDFORNECEDOR

END


IF (@CARREGAMENTO = 2)
BEGIN

	SELECT
		TB_FORNECEDORxUSUARIO.ID, 
		TB_FORNECEDORxUSUARIO.IDFORNECEDOR, 
		TB_FORNECEDOR.NOMEFANTASIA, 
		TB_FORNECEDOR.RAZAOSOCIAL, 
		TB_FORNECEDOR.CNPJ, 
		TB_FORNECEDOR.ENDERECO, 
		TB_FORNECEDOR.NUMERO,
		TB_FORNECEDOR.COMPLEMENTO, 
		TB_FORNECEDOR.CEP, 
		TB_FORNECEDOR.BAIRRO, 
		TB_FORNECEDOR.CIDADE, 
		TB_FORNECEDOR.ESTADO, 
		TB_FORNECEDOR.DATACADASTRO, 
		TB_FORNECEDOR.IE, 
		TB_FORNECEDOR.EMAIL, 
		TB_FORNECEDOR.LATITUDE, 
		TB_FORNECEDOR.LONGITUDE, 
		TB_FORNECEDOR.CODINTERNO, 
		TB_FORNECEDOR.TELEFONE1, 
		TB_FORNECEDOR.TELEFONE2, 
		TB_FORNECEDOR.TELEFONE3, 
		TB_FORNECEDOR.TELEFONE4, 
		TB_FORNECEDOR.PONTOENTREGARETIRADA, 
		TB_FORNECEDOR.FABRICANTE, 
		TB_FORNECEDOR.IDSTATUS AS IDSTATUSFORNECEDOR, 
		TB_FORNECEDORxUSUARIO.IDUSUARIO, 
		TB_USUARIO.NOME, 
		TB_USUARIO.[LOGIN], 
		TB_USUARIO.SENHA, 
		TB_USUARIO.EMAIL AS EMAILUSUARIO, 
		TB_USUARIO.IDNIVEL, 
		TB_USUARIO.IDSTATUS AS IDSTATUSUSUARIO, 
		TB_USUARIO.FOTO
	FROM TB_FORNECEDOR 
		INNER JOIN
	TB_FORNECEDORxUSUARIO ON TB_FORNECEDOR.IDFORNECEDOR = TB_FORNECEDORxUSUARIO.IDFORNECEDOR 
		INNER JOIN
	TB_USUARIO ON TB_FORNECEDORxUSUARIO.IDUSUARIO = TB_USUARIO.IDUSUARIO
	WHERE TB_FORNECEDORxUSUARIO.IDUSUARIO = @IDUSUARIO

END
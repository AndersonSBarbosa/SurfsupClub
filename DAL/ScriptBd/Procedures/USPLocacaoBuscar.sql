PRINT Db_Name()+', Cria��o da Procedure USPLocacaoBuscar'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPLocacaoBuscar � RESPONS�VEL: Anderson � DATA: 10/10/2018 � 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPLocacaoBuscar' )
    DROP PROCEDURE USPLocacaoBuscar

GO

CREATE PROCEDURE USPLocacaoBuscar
		   @BUSCAR varchar(90)

AS
    SET NOCOUNT ON

SELECT
	TB_LOCACAO.IDLOCACAO, 
	TB_LOCACAO.IDPRANCHA, 
	TB_PRANCHA.PRANCHA, 
	TB_PRANCHA.DESCRICAO, 
	TB_PRANCHA.VOLUME, 
	TB_PRANCHA.POLEGADAS, 
	TB_PRANCHA.ESPESSURA, 
	TB_PRANCHA.CODINTERNO AS CODIGOINTERNOPRANCHA, 
	TB_PRANCHA.IDMARCA, 
	TB_PRANCHA_MARCA.MARCA, 
	TB_PRANCHA.IDMODELO, 
	TB_PRANCHA_MODELO.MODELO, 
	TB_PRANCHA.TAMANHO, 
	TB_PRANCHA.LARGURA, 
	TB_PRANCHA.BORDA, 
	TB_PRANCHA.LITRAGEM, 
	TB_PRANCHA.IDMODALIDADE, 
	TB_PRANCHA_MODALIDADE.MODALIDADE, 
	TB_LOCACAO.IDCLIENTE, 
	TB_CLIENTE.NOME, 
	TB_CLIENTE.SOBRENOME, 
	TB_CLIENTE.IDFACEBOOK, 
	TB_CLIENTE.EMAIL, 
	TB_LOCACAO.IDPLANO, 
	TB_PLANOS.PLANO, 
	TB_PLANOS.VALOR, 
	TB_PLANOS.DIAS, 
	TB_PLANOS.MENSAL, 
	TB_LOCACAO.DATARETIRADA, 
	TB_LOCACAO.DATAENTREGA, 
	TB_LOCACAO.DATADEVOLUCAO, 
	TB_LOCACAO.DATACADASTRO, 
	TB_LOCACAO.IDSTATUS, 
	TB_STATUS.[STATUS], 
	TB_LOCACAO.CODINTERNO, 
	TB_LOCACAO.IDPONTORETIRADA,
	TB_LOCACAO.IDPONTOENTREGA,
	TB_LOCACAO.DATARETIRADAPRANCHALOCAL,
	TB_LOCACAO.IDUSUARIORETIRADA,
	TB_LOCACAO.IDUSUARIOENTREGA


FROM 
	TB_CLIENTE 
INNER JOIN
	TB_LOCACAO ON TB_CLIENTE.IDCLIENTE = TB_LOCACAO.IDCLIENTE 
INNER JOIN
	TB_PLANOS ON TB_LOCACAO.IDPLANO = TB_PLANOS.IDPLANO 
INNER JOIN
	TB_PRANCHA ON TB_LOCACAO.IDPRANCHA = TB_PRANCHA.IDPRANCHA 
INNER JOIN
	TB_PRANCHA_MARCA ON TB_PRANCHA.IDMARCA = TB_PRANCHA_MARCA.IDMARCA 
INNER JOIN
	TB_PRANCHA_MODALIDADE ON TB_PRANCHA.IDMODALIDADE = TB_PRANCHA_MODALIDADE.IDMODALIDADE 
INNER JOIN
	TB_PRANCHA_MODELO ON TB_PRANCHA.IDMODELO = TB_PRANCHA_MODELO.IDMODELO 
INNER JOIN
	TB_STATUS ON TB_LOCACAO.IDSTATUS = TB_STATUS.IDSTATUS
WHERE 
	(TB_CLIENTE.CPF  like '%'+@BUSCAR+'%') or (TB_CLIENTE.CPF  like '%'+@BUSCAR)
or
	(TB_CLIENTE.NOME  like '%'+@BUSCAR+'%') or (TB_CLIENTE.NOME  like '%'+@BUSCAR)
or
	(TB_CLIENTE.SOBRENOME  like '%'+@BUSCAR+'%') or (TB_CLIENTE.SOBRENOME  like '%'+@BUSCAR)
 or
	(TB_LOCACAO.CODINTERNO  like '%'+@BUSCAR+'%') or (TB_LOCACAO.CODINTERNO  like '%'+@BUSCAR)
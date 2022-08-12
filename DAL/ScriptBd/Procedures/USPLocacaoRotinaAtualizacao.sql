PRINT Db_Name()+', Criação da Procedure USPLocacaoRotinaAtualizacao'

GO
--------------------------------------------------------------------------------------
-- OBJETO: USPLocacaoRotinaAtualizacao – RESPONSÁVEL: Anderson – DATA: 10/10/2018 – 
--------------------------------------------------------------------------------------
IF EXISTS( SELECT
               NAME
           FROM
               SYSOBJECTS
           WHERE
             XTYPE = 'P'
             AND NAME = 'USPLocacaoRotinaAtualizacao' )
    DROP PROCEDURE USPLocacaoRotinaAtualizacao

GO

CREATE PROCEDURE USPLocacaoRotinaAtualizacao
		   
AS
    SET NOCOUNT ON
    
-- 3	Locado	Locacao
-- 4	Devolvido	Locacao
-- 5	Atrasado	Locacao
-- 6	Devolvido c/ Atraso	Locacao

	update TB_LOCACAO set IDSTATUS = 5 where IDLOCACAO in (Select IDLOCACAO from TB_LOCACAO where DATEDIFF(day, GETDATE(), DATAENTREGA) < 0 and IDSTATUS = 3)


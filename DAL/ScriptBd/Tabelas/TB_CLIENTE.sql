
CREATE TABLE [dbo].[TB_CLIENTE](
	[IDCLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NULL,
	[SOBRENOME] [varchar](80) NULL,
	[IDFACEBOOK] [varchar](30) NULL,
	[EMAIL] [varchar](100) NULL,
	[CPF] [varchar](20) NULL,
	[RG] [varchar](20) NULL,
	[ALTURA] [varchar](4) NULL,
	[PESO] [varchar](4) NULL,
	[DATANASCIMENTO] [date] NULL,
	[ENDERECO] [varchar](50) NULL,
	[NUMERO] [varchar](6) NULL,
	[COMPLEMENTO] [varchar](40) NULL,
	[BAIRRO] [varchar](30) NULL,
	[CEP] [varchar](8) NULL,
	[CIDADE] [varchar](50) NULL,
	[ESTADO] [varchar](2) NULL,
	[DATACADASTRO] [datetime] DEFAULT (getdate()) NULL,
	[IDSTATUS] [int] NULL,
	[CODINTERNO] [varchar](40) NULL,
	[TELEFONE1] [varchar](25) NULL,
	[TELEFONE2] [varchar](25) NULL,
	[TELEFONE3] [varchar](25) NULL,
	[TELEFONE4] [varchar](25) NULL,
	[SEXO] [varchar](1) NULL,
	[SENHAa] [varchar](15) NULL,
	[SENHA] [varbinary](max) NULL,
 CONSTRAINT [PK_TB_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

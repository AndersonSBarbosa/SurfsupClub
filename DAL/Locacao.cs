using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

/// <summary>
/// OK
/// </summary>

namespace DAL
{
    public class Locacao
        {
                public ConexaoDB objConexaoDB;
                private SqlCommand comando;

                public Locacao()
                {
                    objConexaoDB = ConexaoDB.SaberEstadoConexao();
                }


        #region Funções Básicas
        public void create(Entidades.Locacao Obj)
                {

                    try
                    {
                        int Resposta = 0;
                        string sql = @"USPLocacaoCadastroEdicao";

                        using (RaiCore.Data conn = new RaiCore.Data())
                        {
                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;

                                conn.AddInParameter(cmd, "@IDLOCACAO", DbType.Int32, Obj.IdLocacao);
                                conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                                conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                                conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
                                conn.AddInParameter(cmd, "@DATARETIRADA", DbType.Date, Obj.DataRetirada);
                                conn.AddInParameter(cmd, "@DATAENTREGA", DbType.Date, Obj.DataEntrega);
                                conn.AddInParameter(cmd, "@DATADEVOLUCAO", DbType.DateTime, Obj.DataDevolucao);
                                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                                conn.AddInParameter(cmd, "@IDPONTORETIRADA", DbType.Int32, Obj.IdPontoRetirada);
                                conn.AddInParameter(cmd, "@IDPONTOENTREGA", DbType.Int32, Obj.IdPontoEntrega);
                                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);
                                cmd.ExecuteNonQuery();
                                Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

                public void delete(Entidades.Locacao obj)
                {
                    throw new NotImplementedException();
                }

                public Entidades.Locacao Detalhes(long Id)
                {
                    try
                    {
                        Entidades.Locacao rs = new Entidades.Locacao();

                        string sql = @"USPLocacaoDetalhe";

                        using (RaiCore.Data conn = new RaiCore.Data())
                        {
                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;

                                conn.AddInParameter(cmd, "@IDLOCACAO", DbType.Int32, Convert.ToInt32(Id));

                                using (DbDataAdapter adp = conn.CreateDataAdapter())
                                {
                                    DataTable dt = new DataTable();

                                    adp.SelectCommand = cmd;
                                    adp.Fill(dt);

                                    if (dt.Rows.Count > 0)
                                    {
                                        rs.IdLocacao = Int32.Parse(dt.Rows[0]["IDLOCACAO"].ToString());
                                        rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
                                        rs.IdPrancha = Int32.Parse(dt.Rows[0]["IDPRANCHA"].ToString());
                                        rs.Prancha.NomePrancha = dt.Rows[0]["PRANCHA"].ToString();
                                        rs.Prancha.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
                                        rs.Prancha.Volume = dt.Rows[0]["VOLUME"].ToString();
                                        rs.Prancha.Polegadas = dt.Rows[0]["POLEGADAS"].ToString();
                                        rs.Prancha.Espessura = dt.Rows[0]["ESPESSURA"].ToString();
                                        rs.Fornecedor.IdFornecedor = Int32.Parse(dt.Rows[0]["IDFORNECEDOR"].ToString());
                                        rs.Fornecedor.NomeFantasia = dt.Rows[0]["NOMEFANTASIA"].ToString();
                                        rs.Fornecedor.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL"].ToString();
                                        rs.Fornecedor.CNPJ = dt.Rows[0]["CNPJ"].ToString();
                                        rs.Prancha.CodigoInterno = dt.Rows[0]["CODINTERNOPRANCHA"].ToString();
                                        rs.IdCliente = Int32.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
                                        rs.Cliente.Nome = dt.Rows[0]["NOME"].ToString();
                                        rs.Cliente.IdFacebook = dt.Rows[0]["IDFACEBOOK"].ToString();
                                        rs.Cliente.Sobrenome = dt.Rows[0]["SOBRENOME"].ToString();
                                        rs.Cliente.Email = dt.Rows[0]["EMAIL"].ToString();
                                        rs.Cliente.CPF = dt.Rows[0]["CPF"].ToString();
                                        rs.Cliente.CodigoInterno = dt.Rows[0]["CODINTERNOCLIENTE"].ToString();
                                        rs.IdPlano = Int32.Parse(dt.Rows[0]["IDPLANO"].ToString());
                                        rs.Planos.Plano = dt.Rows[0]["PLANO"].ToString();
                                        rs.Planos.Valor = Decimal.Parse(dt.Rows[0]["VALOR"].ToString());
                                        rs.Planos.Dias = Int32.Parse(dt.Rows[0]["DIAS"].ToString());
                                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[0]["MENSAL"].ToString());

                                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATARETIRADA"].ToString()))
                                        {
                                            rs.DataRetirada = DateTime.Parse(dt.Rows[0]["DATARETIRADA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATAENTREGA"].ToString()))
                                        {
                                            rs.DataEntrega = DateTime.Parse(dt.Rows[0]["DATAENTREGA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATADEVOLUCAO"].ToString()))
                                        {
                                            rs.DataDevolucao = DateTime.Parse(dt.Rows[0]["DATADEVOLUCAO"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                        {
                                            rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                        }
                                        rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                        rs.Status.NomeStatus = dt.Rows[0]["[STATUS]"].ToString();
                                        rs.IdPontoRetirada = Int32.Parse(dt.Rows[0]["IDPONTORETIRADA"].ToString());
                                        rs.IdPontoEntrega = Int32.Parse(dt.Rows[0]["IDPONTOENTREGA"].ToString());
                                //rs.PontoRetirada.NomeFantasia = dt.Rows[0]["NOMEFANTASIA_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.CNPJ = dt.Rows[0]["CNPJ_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Endereco = dt.Rows[0]["ENDERECO_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Numero = dt.Rows[0]["NUMERO_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Complemento = dt.Rows[0]["COMPLEMENTO_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Bairro = dt.Rows[0]["BAIRRO_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.CEP = dt.Rows[0]["CEP_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Cidade = dt.Rows[0]["CIDADE_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Estado = dt.Rows[0]["ESTADO_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Latitude = dt.Rows[0]["LATITUDE_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.Longitude = dt.Rows[0]["LONGITUDE_PONTORETIRADA"].ToString();
                                //rs.PontoRetirada.CodigoInterno = dt.Rows[0]["CODINTERNO_PONTORETIRADA"].ToString();
                            }

                                    return rs;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public List<Entidades.Locacao> findAll()
                {
                    Entidades.Locacao rs = new Entidades.Locacao();
                    List<Entidades.Locacao> ListarAll = new List<Entidades.Locacao>();
                    string sql = @"USPlocacaoListar";
                    try
                    {
                        using (RaiCore.Data conn = new RaiCore.Data())
                        {
                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;

                                //conn.AddInParameter(cmd, "IDFILHO", DbType.Int32, IdFilho);
                                //conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);

                                using (DbDataAdapter adp = conn.CreateDataAdapter())
                                {
                                    DataTable dt = new DataTable();

                                    adp.SelectCommand = cmd;
                                    adp.Fill(dt);

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        rs = new Entidades.Locacao();
                                        rs.IdLocacao = Int32.Parse(dt.Rows[i]["IDLOCACAO"].ToString());
                                        rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                        rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                        rs.Prancha.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                        rs.Prancha.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                        rs.Prancha.Volume = dt.Rows[i]["VOLUME"].ToString();
                                        rs.Prancha.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                        rs.Prancha.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                        rs.Prancha.CodigoInterno = dt.Rows[i]["CODIGOINTERNOPRANCHA"].ToString();
                                        rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                        rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                        rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                        rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                        rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
                                        rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
                                        rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                                        rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
                                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADA"].ToString()))
                                        {
                                            rs.DataRetirada = DateTime.Parse(dt.Rows[i]["DATARETIRADA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATAENTREGA"].ToString()))
                                        {
                                            rs.DataEntrega = DateTime.Parse(dt.Rows[i]["DATAENTREGA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATADEVOLUCAO"].ToString()))
                                        {
                                            rs.DataDevolucao = DateTime.Parse(dt.Rows[i]["DATADEVOLUCAO"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                        {
                                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                        }
                                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                        rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                        rs.IdPontoRetirada = Int32.Parse(dt.Rows[i]["IDPONTORETIRADA"].ToString());
                                        rs.IdPontoEntrega = Int32.Parse(dt.Rows[i]["IDPONTOENTREGA"].ToString());

                                ListarAll.Add(rs);
                                    }
                                    return ListarAll;
                                }
                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public List<Entidades.Locacao> ListarLocacoesRetiradaEntrega(Int32 IdUsuario)
        {
            Entidades.Locacao rs = new Entidades.Locacao();
            List<Entidades.Locacao> ListarAll = new List<Entidades.Locacao>();
            string sql = @"USPLocacaoListarPontoRetiradaEntrega";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        //conn.AddInParameter(cmd, "IDFILHO", DbType.Int32, IdFilho);
                        conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Locacao();
                                rs.IdLocacao = Int32.Parse(dt.Rows[i]["IDLOCACAO"].ToString());
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                rs.Prancha.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                rs.Prancha.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                rs.Prancha.Volume = dt.Rows[i]["VOLUME"].ToString();
                                rs.Prancha.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                rs.Prancha.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                rs.Prancha.CodigoInterno = dt.Rows[i]["CODIGOINTERNOPRANCHA"].ToString();
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
                                rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
                                rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                                rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
                                rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADA"].ToString()))
                                {
                                    rs.DataRetirada = DateTime.Parse(dt.Rows[i]["DATARETIRADA"].ToString());
                                }
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATAENTREGA"].ToString()))
                                {
                                    rs.DataEntrega = DateTime.Parse(dt.Rows[i]["DATAENTREGA"].ToString());
                                }
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATADEVOLUCAO"].ToString()))
                                {
                                    rs.DataDevolucao = DateTime.Parse(dt.Rows[i]["DATADEVOLUCAO"].ToString());
                                }
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.IdPontoRetirada = Int32.Parse(dt.Rows[i]["IDPONTORETIRADA"].ToString());
                                rs.IdPontoEntrega = Int32.Parse(dt.Rows[i]["IDPONTOENTREGA"].ToString());

                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADAPRANCHALOCAL"].ToString()))
                                {
                                    rs.DataRetiradaPranchaLocal = DateTime.Parse(dt.Rows[i]["DATARETIRADAPRANCHALOCAL"].ToString());
                                }
                                rs.Usuario.IdUsuario = Int32.Parse(dt.Rows[i]["IDUSUARIO"].ToString());
                                ListarAll.Add(rs);
                            }
                            return ListarAll;
                        }
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

                public void update(Entidades.Locacao Obj)
                {

                    try
                    {
                        int Resposta = 0;
                        string sql = @"USPLocacaoCadastroEdicao";


                        using (RaiCore.Data conn = new RaiCore.Data())
                        {

                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;

                                conn.AddInParameter(cmd, "@IDLOCACAO", DbType.Int32, Obj.IdLocacao);
                                //conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                                //conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                                //conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
                                //conn.AddInParameter(cmd, "@DATARETIRADA", DbType.Date, Obj.DataRetirada);
                                //conn.AddInParameter(cmd, "@DATAENTREGA", DbType.Date, Obj.DataEntrega);
                                conn.AddInParameter(cmd, "@DATADEVOLUCAO", DbType.DateTime, Obj.DataDevolucao);
                                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                                conn.AddInParameter(cmd, "@IDPONTOENTREGA", DbType.Int32, Obj.IdPontoEntrega);
                                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);
                                cmd.ExecuteNonQuery();
                                                        Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }


                }

                public void updateGravarLogRetiradaPrancha(Entidades.Locacao Obj)
                {
                    try
                    {
                        string sql = @"USPLocacaoRetiradaPrancha";
                        using (RaiCore.Data conn = new RaiCore.Data())
                        {
                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;
                                conn.AddInParameter(cmd, "@IDLOCACAO", DbType.Int32, Obj.IdLocacao);
                                conn.AddInParameter(cmd, "@IDPONTORETIRADAENTREGA", DbType.Int32, Obj.IdPontoRetirada);
                                conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, Obj.IdusuarioRetirada);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public void updateGravarLogEntregaPrancha(Entidades.Locacao Obj)
                 {
                     try
                     {
                         string sql = @"USPLocacaoDevolucaoPrancha";
                         using (RaiCore.Data conn = new RaiCore.Data())
                         {
                             conn.RaiConnection("SurfsUpClubConnection");

                             using (DbCommand cmd = conn.CreateCommand())
                             {
                                 cmd.CommandType = CommandType.StoredProcedure;
                                 cmd.CommandText = sql;

                                 conn.AddInParameter(cmd, "@IDLOCACAO", DbType.Int32, Obj.IdLocacao);
                                 conn.AddInParameter(cmd, "@IDPONTORETIRADAENTREGA", DbType.Int32, Obj.IdPontoEntrega);
                                 conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, Obj.IdusuarioEntrega);
                                 cmd.ExecuteNonQuery();
                             }
                         }
                     }
                     catch (Exception ex)
                     {

                         throw ex;
                     }


                 }

                public List<Entidades.Locacao> Buscar(Entidades.Locacao Obj)
                {
                    Entidades.Locacao rs = new Entidades.Locacao();
                    List<Entidades.Locacao> ListarAll = new List<Entidades.Locacao>();
                    string sql = @"USPLocacaoBuscar";
                    try
                    {
                        using (RaiCore.Data conn = new RaiCore.Data())
                        {
                            conn.RaiConnection("SurfsUpClubConnection");

                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sql;

                                conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.Cliente.CPF);
                                conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Cliente.Nome);
                                conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                                using (DbDataAdapter adp = conn.CreateDataAdapter())
                                {
                                    DataTable dt = new DataTable();

                                    adp.SelectCommand = cmd;
                                    adp.Fill(dt);

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        rs = new Entidades.Locacao();
                                        rs.IdLocacao = Int32.Parse(dt.Rows[i]["IDLOCACAO"].ToString());
                                        rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                        rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                        rs.Prancha.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                        rs.Prancha.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                        rs.Prancha.Volume = dt.Rows[i]["VOLUME"].ToString();
                                        rs.Prancha.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                        rs.Prancha.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                        rs.Fornecedor.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                        rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                        rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                        rs.Fornecedor.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                        rs.Prancha.CodigoInterno = dt.Rows[i]["CODINTERNOPRANCHA"].ToString();
                                        rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                        rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                        rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                        rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                        rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                        rs.Cliente.CPF = dt.Rows[i]["CPF"].ToString();
                                        rs.Cliente.CodigoInterno = dt.Rows[i]["CODINTERNOCLIENTE"].ToString();
                                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
                                        rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
                                        rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                                        rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
                                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADA"].ToString()))
                                        {
                                            rs.DataRetirada = DateTime.Parse(dt.Rows[i]["DATARETIRADA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATAENTREGA"].ToString()))
                                        {
                                            rs.DataEntrega = DateTime.Parse(dt.Rows[i]["DATAENTREGA"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATADEVOLUCAO"].ToString()))
                                        {
                                            rs.DataDevolucao = DateTime.Parse(dt.Rows[i]["DATADEVOLUCAO"].ToString());
                                        }
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                        {
                                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                        }
                                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                        rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                        rs.IdPontoRetirada = Int32.Parse(dt.Rows[i]["IDPONTORETIRADA"].ToString());
                                        rs.IdPontoEntrega = Int32.Parse(dt.Rows[i]["IDPONTOENTREGA"].ToString());
                                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADAPRANCHALOCAL"].ToString()))
                                        {
                                            rs.DataRetiradaPranchaLocal = DateTime.Parse(dt.Rows[i]["DATARETIRADAPRANCHALOCAL"].ToString());
                                        }
                                        rs.Usuario.IdUsuario = Int32.Parse(dt.Rows[i]["IDUSUARIO"].ToString());
                                ListarAll.Add(rs);
                                    }
                                    return ListarAll;
                                }
                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public bool find(Entidades.Locacao Obj)
                {

                    bool TemRegistros;
                    string sql = "USPLocacaoDetalhe " + Obj.IdLocacao + " ";
                    try
                    {
                        comando = new SqlCommand(sql, objConexaoDB.GetCon());
                        objConexaoDB.GetCon().Open();
                        SqlDataReader reader = comando.ExecuteReader();
                        TemRegistros = reader.Read();
                        if (TemRegistros)
                        {
                            Obj.IdLocacao  = Convert.ToInt32(reader[0].ToString());
                            Obj.IdPrancha = Convert.ToInt32(reader[1].ToString());
                            Obj.Prancha.NomePrancha = (reader[2].ToString());
                            Obj.Prancha.Descricao = (reader[3].ToString());
                            Obj.Prancha.Volume = (reader[4].ToString());
                            Obj.Prancha.Polegadas = (reader[5].ToString());
                            Obj.Prancha.Espessura = (reader[6].ToString());
                            Obj.Prancha.CodigoInterno = (reader[7].ToString());
                            Obj.Prancha.IdMarca = Convert.ToInt32(reader[8].ToString());
                            Obj.Prancha.PranchaMarca.Marca = (reader[9].ToString());
                            Obj.Prancha.IdModelo = Convert.ToInt32(reader[10].ToString());
                            Obj.Prancha.PranchaModelo.Modelo = (reader[11].ToString());
                            Obj.Prancha.Tamanho = (reader[12].ToString());
                            Obj.Prancha.Largura = (reader[13].ToString());
                            Obj.Prancha.Borda = (reader[14].ToString());
                            Obj.Prancha.Litragem = (reader[15].ToString());
                            Obj.Prancha.IdModalidade = Convert.ToInt32(reader[16].ToString());
                            Obj.Prancha.PranchaModalidade.Modalidade = (reader[17].ToString());
                            Obj.IdCliente = Convert.ToInt32(reader[18].ToString());
                            Obj.Cliente.Nome = (reader[19].ToString());
                            Obj.Cliente.Sobrenome = (reader[20].ToString());
                            Obj.Cliente.IdFacebook = (reader[21].ToString());
                            Obj.Cliente.Email = (reader[22].ToString());
                            Obj.IdPlano = Convert.ToInt64(reader[23].ToString());
                            Obj.Planos.Plano = (reader[24].ToString());
                            Obj.Planos.Valor = Convert.ToDecimal(reader[25].ToString());
                            Obj.Planos.Dias = Convert.ToInt32(reader[26].ToString());
                            Obj.Planos.Mensal = Convert.ToBoolean(reader[27].ToString());

                            if (!String.IsNullOrEmpty(reader[28].ToString()))
                            {
                                Obj.DataRetirada = DateTime.Parse(reader[28].ToString());
                            }
                            if (!String.IsNullOrEmpty(reader[29].ToString()))
                            {
                                Obj.DataEntrega = DateTime.Parse(reader[29].ToString());
                            }
                            if (!String.IsNullOrEmpty(reader[30].ToString()))
                            {
                                Obj.DataDevolucao = DateTime.Parse(reader[30].ToString());
                            }
                            if (!String.IsNullOrEmpty(reader[31].ToString()))
                            {
                                Obj.DataCadastro = DateTime.Parse(reader[31].ToString());
                            }
                            Obj.IdStatus = Convert.ToInt32(reader[32].ToString());
                            Obj.Status.NomeStatus = (reader[33].ToString());
                            Obj.CodigoInterno  = (reader[34].ToString());
                            Obj.IdPontoRetirada = Convert.ToInt32(reader[35].ToString());
                            Obj.IdPontoEntrega = Convert.ToInt32(reader[36].ToString());
                            if (!String.IsNullOrEmpty(reader[37].ToString()))
                            {
                                Obj.DataRetiradaPranchaLocal = DateTime.Parse(reader[37].ToString());
                            }
                            Obj.IdPontoRetirada = Convert.ToInt32(reader[38].ToString());
                            Obj.IdPontoEntrega = Convert.ToInt32(reader[39].ToString());
                            Obj.Resposta = 5;
                        }
                        else
                        {
                            Obj.Resposta = 6;
                        }

                    }
                    catch (Exception)
                    {
                        throw;

                    }
                    finally
                    {
                        objConexaoDB.GetCon().Close();
                        objConexaoDB.FecharDB();
                    }

                    return TemRegistros;

                }
        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
   public class Status
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Status()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        //public void create(Entidades.Status Obj)
        //{

        //    try
        //    {
        //        int Resposta = 0;
        //        string sql = @"USPStatusCadastroEdicao";


        //        using (RaiCore.Data conn = new RaiCore.Data())
        //        {

        //            conn.RaiConnection("SurfsUpClubConnection");

        //            using (DbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = sql;

        //                conn.AddInParameter(cmd, "@IDReserva", DbType.Int32, Obj.IdReserva);
        //                conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
        //                conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
        //                conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
        //                conn.AddInParameter(cmd, "@DATARETIRADA", DbType.Date, Obj.DataRetirada);
        //                conn.AddInParameter(cmd, "@DATAENTREGA", DbType.Date, Obj.DataEntrega);
        //                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
        //                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);
        //                cmd.ExecuteNonQuery();
        //                                        Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}

        //public void delete(Entidades.Status obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public Entidades.Status Detalhes(long Id)
        //{
        //    try
        //    {
        //        Entidades.Status rs = new Entidades.Status();

        //        string sql = @"USPStatusDetalhe";

        //        using (RaiCore.Data conn = new RaiCore.Data())
        //        {
        //            conn.RaiConnection("SurfsUpClubConnection");

        //            using (DbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = sql;

        //                conn.AddInParameter(cmd, "@IDStatus", DbType.Int32, Convert.ToInt32(Id));

        //                using (DbDataAdapter adp = conn.CreateDataAdapter())
        //                {
        //                    DataTable dt = new DataTable();

        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dt);

        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        rs.IdPrancha = Int32.Parse(dt.Rows[0]["IDPRANCHA"].ToString());
        //                        rs.Prancha.NomePrancha = dt.Rows[0]["PRANCHA"].ToString();
        //                        rs.Prancha.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
        //                        rs.Prancha.Volume = dt.Rows[0]["VOLUME"].ToString();
        //                        rs.Prancha.Polegadas = dt.Rows[0]["POLEGADAS"].ToString();
        //                        rs.Prancha.Espessura = dt.Rows[0]["ESPESSURA"].ToString();
        //                        rs.Prancha.IdFornecedor = Int32.Parse(dt.Rows[0]["IDFORNECEDOR"].ToString());
        //                        rs.Fornecedor.NomeFantasia = dt.Rows[0]["NOMEFANTASIA"].ToString();
        //                        rs.Fornecedor.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL"].ToString();
        //                        rs.IdCliente = Int32.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
        //                        rs.Cliente.Nome = dt.Rows[0]["NOME"].ToString();
        //                        rs.Cliente.IdFacebook = dt.Rows[0]["IDFACEBOOK"].ToString();
        //                        rs.Cliente.Sobrenome = dt.Rows[0]["SOBRENOME"].ToString();
        //                        rs.Cliente.Email = dt.Rows[0]["EMAIL"].ToString();
        //                        rs.IdPlano = Int32.Parse(dt.Rows[0]["IDPLANO"].ToString());
        //                        rs.Planos.Plano = dt.Rows[0]["PLANO"].ToString();
        //                        rs.Planos.Valor = Decimal.Parse(dt.Rows[0]["VALOR"].ToString());
        //                        rs.Planos.Dias = Int32.Parse(dt.Rows[0]["DIAS"].ToString());
        //                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[0]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATARETIRADA"].ToString()))
        //                        {
        //                            rs.DataRetirada = DateTime.Parse(dt.Rows[0]["DATARETIRADA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATAENTREGA"].ToString()))
        //                        {
        //                            rs.DataEntrega = DateTime.Parse(dt.Rows[0]["DATAENTREGA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[0]["STATUS"].ToString();
        //                        rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
        //                    }

        //                    return rs;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Entidades.Status> findAll()
        //{
        //    Entidades.Status rs = new Entidades.Status();
        //    List<Entidades.Status> ListarAll = new List<Entidades.Status>();
        //    string sql = @"USPStatusListar";
        //    try
        //    {
        //        using (RaiCore.Data conn = new RaiCore.Data())
        //        {
        //            conn.RaiConnection("SurfsUpClubConnection");

        //            using (DbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = sql;

        //                //conn.AddInParameter(cmd, "IDFILHO", DbType.Int32, IdFilho);
        //                //conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);

        //                using (DbDataAdapter adp = conn.CreateDataAdapter())
        //                {
        //                    DataTable dt = new DataTable();

        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dt);

        //                    for (int i = 0; i < dt.Rows.Count; i++)
        //                    {
        //                        rs = new Entidades.Status();
        //                        rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
        //                        rs.Prancha.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
        //                        rs.Prancha.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
        //                        rs.Prancha.Volume = dt.Rows[i]["VOLUME"].ToString();
        //                        rs.Prancha.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
        //                        rs.Prancha.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
        //                        rs.Prancha.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
        //                        rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
        //                        rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
        //                        rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
        //                        rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
        //                        rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
        //                        rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
        //                        rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
        //                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
        //                        rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
        //                        rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
        //                        rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
        //                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADA"].ToString()))
        //                        {
        //                            rs.DataRetirada = DateTime.Parse(dt.Rows[i]["DATARETIRADA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATAENTREGA"].ToString()))
        //                        {
        //                            rs.DataEntrega = DateTime.Parse(dt.Rows[i]["DATAENTREGA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
        //                        rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
        //                        ListarAll.Add(rs);
        //                    }
        //                    return ListarAll;
        //                }
        //            }

        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void update(Entidades.Status Obj)
        //{

        //    try
        //    {
        //        int Resposta = 0;
        //        string sql = @"USPStatusCadastroEdicao";


        //        using (RaiCore.Data conn = new RaiCore.Data())
        //        {

        //            conn.RaiConnection("SurfsUpClubConnection");

        //            using (DbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = sql;

        //                conn.AddInParameter(cmd, "@IDReserva", DbType.Int32, Obj.IdReserva);
        //                conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
        //                conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
        //                conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
        //                conn.AddInParameter(cmd, "@DATARETIRADA", DbType.Date, Obj.DataRetirada);
        //                conn.AddInParameter(cmd, "@DATAENTREGA", DbType.Date, Obj.DataEntrega);
        //                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
        //                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);

        //                cmd.ExecuteNonQuery();
        //                                        Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}

        //public List<Entidades.Status> Buscar(Entidades.Status Obj)
        //{
        //    Entidades.Status rs = new Entidades.Status();
        //    List<Entidades.Status> ListarAll = new List<Entidades.Status>();
        //    string sql = @"USPStatusBuscar";
        //    try
        //    {
        //        using (RaiCore.Data conn = new RaiCore.Data())
        //        {
        //            conn.RaiConnection("SurfsUpClubConnection");

        //            using (DbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = sql;

        //                //conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.Cliente.CPF);
        //                //conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Cliente.Nome);
        //                //conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

        //                using (DbDataAdapter adp = conn.CreateDataAdapter())
        //                {
        //                    DataTable dt = new DataTable();

        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dt);

        //                    for (int i = 0; i < dt.Rows.Count; i++)
        //                    {
        //                        rs = new Entidades.Status();
        //                        rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
        //                        rs.Prancha.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
        //                        rs.Prancha.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
        //                        rs.Prancha.Volume = dt.Rows[i]["VOLUME"].ToString();
        //                        rs.Prancha.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
        //                        rs.Prancha.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
        //                        rs.Prancha.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
        //                        rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
        //                        rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
        //                        rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
        //                        rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
        //                        rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
        //                        rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
        //                        rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
        //                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
        //                        rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
        //                        rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
        //                        rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
        //                        rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATARETIRADA"].ToString()))
        //                        {
        //                            rs.DataRetirada = DateTime.Parse(dt.Rows[i]["DATARETIRADA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATAENTREGA"].ToString()))
        //                        {
        //                            rs.DataEntrega = DateTime.Parse(dt.Rows[i]["DATAENTREGA"].ToString());
        //                        }
        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
        //                        rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
        //                        ListarAll.Add(rs);
        //                    }
        //                    return ListarAll;
        //                }
        //            }

        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool find(Entidades.Status Obj)
        //{

        //    bool TemRegistros;
        //    string sql = "USPStatusDetalhe " + Obj.IdReserva + " ";
        //    try
        //    {
        //        comando = new SqlCommand(sql, objConexaoDB.GetCon());
        //        objConexaoDB.GetCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        TemRegistros = reader.Read();
        //        if (TemRegistros)
        //        {


        //            Obj.IdReserva = Convert.ToInt64(reader[0].ToString());
        //            Obj.IdPrancha = Convert.ToInt64(reader[1].ToString());
        //            Obj.Prancha.NomePrancha = (reader[2].ToString());
        //            Obj.Prancha.Descricao = (reader[3].ToString());
        //            Obj.Prancha.Volume = (reader[4].ToString());
        //            Obj.Prancha.Polegadas = (reader[5].ToString());
        //            Obj.Prancha.Espessura = (reader[6].ToString());
        //            Obj.Fornecedor.IdFornecedor = Convert.ToInt64(reader[7].ToString());
        //            Obj.Fornecedor.NomeFantasia = (reader[8].ToString());
        //            Obj.Fornecedor.RazaoSocial = (reader[9].ToString());
        //            Obj.IdCliente = Convert.ToInt64(reader[10].ToString());
        //            Obj.Cliente.Nome = (reader[11].ToString());
        //            Obj.Cliente.IdFacebook = (reader[12].ToString());
        //            Obj.Cliente.Sobrenome = (reader[13].ToString());
        //            Obj.Cliente.Email = (reader[14].ToString());
        //            Obj.IdPlano = Convert.ToInt64(reader[15].ToString());
        //            Obj.Planos.Plano = (reader[16].ToString());
        //            Obj.Planos.Valor = Convert.ToDecimal(reader[17].ToString());
        //            Obj.Planos.Dias = Convert.ToInt32(reader[18].ToString());
        //            Obj.Planos.Mensal = Convert.ToBoolean(reader[19].ToString());

        //            if (!String.IsNullOrEmpty(reader[20].ToString()))
        //            {
        //                Obj.DataRetirada = DateTime.Parse(reader[20].ToString());
        //            }
        //            if (!String.IsNullOrEmpty(reader[21].ToString()))
        //            {
        //                Obj.DataEntrega = DateTime.Parse(reader[21].ToString());
        //            }

        //            if (!String.IsNullOrEmpty(reader[22].ToString()))
        //            {
        //                Obj.DataCadastro = DateTime.Parse(reader[22].ToString());
        //            }
        //            Obj.IdStatus = Convert.ToInt32(reader[23].ToString());
        //            Obj.Status.NomeStatus = reader[24].ToString();
        //            Obj.CodigoInterno = (reader[25].ToString());

        //            Obj.Resposta = 5;
        //        }
        //        else
        //        {
        //            Obj.Resposta = 6;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        objConexaoDB.GetCon().Close();
        //        objConexaoDB.FecharDB();
        //    }

        //    return TemRegistros;

        //}
        #endregion





    }
}

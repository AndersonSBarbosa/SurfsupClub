using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;


namespace BLL
{
   public class Status
    {
        private DAL.Status objStatus;

        public Status()
        {
            objStatus = new DAL.Status();
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

        //                conn.AddInParameter(cmd, "@IDPlans", DbType.Int32, Obj.IdPlano);
        //                conn.AddInParameter(cmd, "@PLANO", DbType.Int32, Obj.Plano);
        //                conn.AddInParameter(cmd, "@VALOR", DbType.Decimal, Obj.Valor);
        //                conn.AddInParameter(cmd, "@DIAS", DbType.Int32, Obj.Dias);
        //                conn.AddInParameter(cmd, "@MENSAL", DbType.Boolean, Obj.Mensal);
        //                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
        //                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);
        //                cmd.ExecuteNonQuery();
        //                Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}

        public void delete(Entidades.Status obj)
        {
            throw new NotImplementedException();
        }

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
        //                        rs.IdPlano = Int32.Parse(dt.Rows[0]["IDPlano"].ToString());
        //                        rs.Plano = dt.Rows[0]["PLANO"].ToString();
        //                        rs.Valor = Decimal.Parse(dt.Rows[0]["VALOR"].ToString());
        //                        rs.Dias = Int32.Parse(dt.Rows[0]["DIAS"].ToString());
        //                        rs.Mensal = Boolean.Parse(dt.Rows[0]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[0]["[STATUS]"].ToString();
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
        //                        rs = new Entidades.Status();
        //                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPlano"].ToString());
        //                        rs.Plano = dt.Rows[i]["PLANO"].ToString();
        //                        rs.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
        //                        rs.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
        //                        rs.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[i]["[STATUS]"].ToString();
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

        //                conn.AddInParameter(cmd, "@IDPlans", DbType.Int32, Obj.IdPlano);
        //                conn.AddInParameter(cmd, "@PLANO", DbType.Int32, Obj.Plano);
        //                conn.AddInParameter(cmd, "@VALOR", DbType.Decimal, Obj.Valor);
        //                conn.AddInParameter(cmd, "@DIAS", DbType.Int32, Obj.Dias);
        //                conn.AddInParameter(cmd, "@MENSAL", DbType.Boolean, Obj.Mensal);
        //                conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
        //                conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);

        //                cmd.ExecuteNonQuery();
        //                Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");

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
        //                        rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPlano"].ToString());
        //                        rs.Plano = dt.Rows[i]["PLANO"].ToString();
        //                        rs.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
        //                        rs.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
        //                        rs.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());

        //                        if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
        //                        {
        //                            rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
        //                        }
        //                        rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
        //                        rs.Status.NomeStatus = dt.Rows[i]["[STATUS]"].ToString();
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
        //    string sql = "USPStatusDetalhe " + Obj.IdPlano + " ";
        //    try
        //    {
        //        comando = new SqlCommand(sql, objConexaoDB.GetCon());
        //        objConexaoDB.GetCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        TemRegistros = reader.Read();
        //        if (TemRegistros)
        //        {


        //            Obj.IdPlano = Convert.ToInt64(reader[0].ToString());
        //            Obj.Plano = reader[1].ToString();
        //            Obj.Valor = Convert.ToDecimal(reader[2].ToString());
        //            Obj.Dias = Convert.ToInt32(reader[3].ToString());
        //            Obj.Mensal = Convert.ToBoolean(reader[4].ToString());

        //            if (!String.IsNullOrEmpty(reader[5].ToString()))
        //            {
        //                Obj.DataCadastro = DateTime.Parse(reader[5].ToString());
        //            }

        //            Obj.IdStatus = Convert.ToInt32(reader[6].ToString());
        //            Obj.Status.NomeStatus = reader[7].ToString();


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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
   public class PedidoItem 
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PedidoItem()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        public void create(Entidades.PedidoItem Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPedidoItemCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDItem", DbType.Int32, Obj.IdItem);
                        conn.AddInParameter(cmd, "@IDPEDIDO", DbType.Int32, Obj.IdPedido);
                        conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
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

        public void delete(Entidades.PedidoItem obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.PedidoItem Detalhes(long Id)
        {
            try
            {
                Entidades.PedidoItem rs = new Entidades.PedidoItem();

                string sql = @"USPPedidoItemDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPedidoItem", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                rs.IdItem = Int32.Parse(dt.Rows[0]["IDItem"].ToString());
                                rs.IdPlano = Int32.Parse(dt.Rows[0]["IDPLANO"].ToString());
                                rs.Planos.Plano = dt.Rows[0]["PLANO"].ToString();
                                rs.Planos.Valor = Decimal.Parse(dt.Rows[0]["VALOR"].ToString());
                                rs.Planos.Dias = Int32.Parse(dt.Rows[0]["DIAS"].ToString());
                                rs.Planos.Mensal = Boolean.Parse(dt.Rows[0]["MENSAL"].ToString());
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["[STATUS]"].ToString();
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

        public List<Entidades.PedidoItem> findAll()
        {
            Entidades.PedidoItem rs = new Entidades.PedidoItem();
            List<Entidades.PedidoItem> ListarAll = new List<Entidades.PedidoItem>();
            string sql = @"USPPedidoItemListar";
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
                                rs = new Entidades.PedidoItem();

                                rs.IdItem = Int32.Parse(dt.Rows[i]["IDItem"].ToString());
                                rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
                                rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
                                rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                                rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
                                rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();

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

        public void update(Entidades.PedidoItem Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPedidoItemCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDItem", DbType.Int32, Obj.IdItem);
                        conn.AddInParameter(cmd, "@IDPEDIDO", DbType.Int32, Obj.IdPedido);
                        conn.AddInParameter(cmd, "@IDPLANO", DbType.Int32, Obj.IdPlano);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
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

        public List<Entidades.PedidoItem> Buscar(Entidades.PedidoItem Obj)
        {
            Entidades.PedidoItem rs = new Entidades.PedidoItem();
            List<Entidades.PedidoItem> ListarAll = new List<Entidades.PedidoItem>();
            string sql = @"USPPedidoItemBuscar";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        //conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.Cliente.CPF);
                        //conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Cliente.Nome);
                        //conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.PedidoItem();
                                rs.IdItem = Int32.Parse(dt.Rows[i]["IDItem"].ToString());
                                rs.IdPlano = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
                                rs.Planos.Plano = dt.Rows[i]["PLANO"].ToString();
                                rs.Planos.Valor = Decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                                rs.Planos.Dias = Int32.Parse(dt.Rows[i]["DIAS"].ToString());
                                rs.Planos.Mensal = Boolean.Parse(dt.Rows[i]["MENSAL"].ToString());
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
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

        public bool find(Entidades.PedidoItem Obj)
        {

            bool TemRegistros;
            string sql = "USPPedidoItemDetalhe " + Obj.IdPedido + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdItem = Convert.ToInt64(reader[0].ToString());
                    Obj.IdPedido = Convert.ToInt64(reader[1].ToString());
                    Obj.IdPlano = Convert.ToInt64(reader[2].ToString());
                    Obj.Planos.Plano = (reader[3].ToString());
                    Obj.Planos.Valor = Convert.ToDecimal(reader[4].ToString());
                    Obj.Planos.Dias = Convert.ToInt32(reader[5].ToString());
                    Obj.Planos.Mensal = Convert.ToBoolean(reader[6].ToString());
                    if (!String.IsNullOrEmpty(reader[7].ToString()))
                    {
                        Obj.DataCadastro = DateTime.Parse(reader[7].ToString());
                    }
                    Obj.IdStatus = Convert.ToInt32(reader[8].ToString());
                    Obj.Status.NomeStatus = reader[9].ToString();
                    

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

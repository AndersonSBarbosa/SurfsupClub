using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
    public class Pedido
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Pedido()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        public void create(Entidades.Pedido Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPedidoCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPedido", DbType.Int32, Obj.IdPedido);
                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
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

        public void delete(Entidades.Pedido obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.Pedido Detalhes(long Id)
        {
            try
            {
                Entidades.Pedido rs = new Entidades.Pedido();

                string sql = @"USPPedidoDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPedido", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdPedido = Int32.Parse(dt.Rows[0]["IDPedido"].ToString());
                                rs.IdCliente = Int32.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[0]["NOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[0]["IDFACEBOOK"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[0]["SOBRENOME"].ToString();
                                rs.Cliente.Email = dt.Rows[0]["EMAIL"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["[STATUS]"].ToString();
                                rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
                               
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

        public List<Entidades.Pedido> findAll()
        {
            Entidades.Pedido rs = new Entidades.Pedido();
            List<Entidades.Pedido> ListarAll = new List<Entidades.Pedido>();
            string sql = @"USPPedidoListar";
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
                                rs = new Entidades.Pedido();
                                rs.IdPedido = Int32.Parse(dt.Rows[i]["IDPedido"].ToString());
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
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

        public void update(Entidades.Pedido Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPedidoCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPedido", DbType.Int32, Obj.IdPedido);
                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
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

        public List<Entidades.Pedido> Buscar(Entidades.Pedido Obj)
        {
            Entidades.Pedido rs = new Entidades.Pedido();
            List<Entidades.Pedido> ListarAll = new List<Entidades.Pedido>();
            string sql = @"USPPedidoBuscar";
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
                                rs = new Entidades.Pedido();
                                rs.IdPedido = Int32.Parse(dt.Rows[i]["IDPedido"].ToString());
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
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

        public bool find(Entidades.Pedido Obj)
        {

            bool TemRegistros;
            string sql = "USPPedidoDetalhe " + Obj.IdPedido + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdPedido = Convert.ToInt64(reader[0].ToString());
                    Obj.IdCliente = Convert.ToInt64(reader[1].ToString());
                    Obj.Cliente.Nome = (reader[2].ToString());
                    Obj.Cliente.Sobrenome = (reader[3].ToString());
                    Obj.Cliente.IdFacebook = (reader[4].ToString());
                    Obj.Cliente.Email = (reader[5].ToString());
                    if (!String.IsNullOrEmpty(reader[6].ToString()))
                    {
                        Obj.DataCadastro = DateTime.Parse(reader[6].ToString());
                    }
                    Obj.IdStatus = Convert.ToInt32(reader[7].ToString());
                    Obj.Status.NomeStatus = reader[8].ToString();
                    Obj.CodigoInterno = (reader[9].ToString());
                   

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

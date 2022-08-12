using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
    public class Creditos 
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Creditos()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.Creditos Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPCreditoCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCREDITO", DbType.Int32, Obj.IdCredito);
                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                        conn.AddInParameter(cmd, "@QUANTIDADE", DbType.Int32, Obj.Quantidade);
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

        public void delete(Entidades.Creditos obj)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Creditos> findAll()
        {
            Entidades.Creditos rs = new Entidades.Creditos();
            List<Entidades.Creditos> ListarAll = new List<Entidades.Creditos>();
            string sql = @"USPCreditoListar";
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
                                rs = new Entidades.Creditos();
                                rs.IdCredito = Int32.Parse(dt.Rows[i]["IDCREDITO"].ToString());
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Quantidade = Int32.Parse(dt.Rows[i]["QUANTIDADE"].ToString());
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
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

        public void update(Entidades.Creditos Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPCreditoCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCREDITO", DbType.Int32, Obj.IdCredito);
                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                        conn.AddInParameter(cmd, "@QUANTIDADE", DbType.Int32, Obj.Quantidade);
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

        public List<Entidades.Creditos> Buscar(Entidades.Creditos Obj)
        {
            Entidades.Creditos rs = new Entidades.Creditos();
            List<Entidades.Creditos> ListarAll = new List<Entidades.Creditos>();
            string sql = @"USPCreditoBuscar";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        //conn.AddInParameter(cmd, "@CNPJ", DbType.String, Obj.CNPJ);
                        conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Cliente.Nome);
                        conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Creditos();
                                rs = new Entidades.Creditos();
                                rs.IdCredito = Int32.Parse(dt.Rows[i]["IDCREDITO"].ToString());
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Cliente.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Cliente.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Cliente.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Cliente.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Quantidade = Int32.Parse(dt.Rows[i]["QUANTIDADE"].ToString());
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
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

    }
}

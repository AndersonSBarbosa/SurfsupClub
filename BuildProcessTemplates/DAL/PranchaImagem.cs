using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
   public class PranchaImagem
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PranchaImagem()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        public void create(Entidades.PranchaImagem Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPranchaImagemCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDIMAGEM", DbType.Int32, Obj.IdImagem);
                        conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                        conn.AddInParameter(cmd, "@IMAGEM", DbType.String, Obj.Imagem);
                        conn.AddInParameter(cmd, "@CAMINHO", DbType.String, Obj.Caminho);
                        conn.AddInParameter(cmd, "@CAPA", DbType.Boolean, Obj.Capa);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);

                        cmd.ExecuteNonQuery();
                        Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");
                        Obj.Resposta = Resposta;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void delete(Entidades.PranchaImagem obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.PranchaImagem Detalhes(long Id)
        {
            try
            {
                Entidades.PranchaImagem rs = new Entidades.PranchaImagem();

                string sql = @"USPPranchaImagemDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPranchaImagem", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdImagem = Int32.Parse(dt.Rows[0]["IDIMAGEM"].ToString());
                                rs.IdPrancha = Int32.Parse(dt.Rows[0]["IDPRANCHA"].ToString());

                                rs.Imagem = dt.Rows[0]["IMAGEM"].ToString();
                                rs.Caminho = dt.Rows[0]["CAMINHO"].ToString();
                                rs.Capa = Boolean.Parse(dt.Rows[0]["CAPA"].ToString());
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["STATUS"].ToString();
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

        public List<Entidades.PranchaImagem> findAll()
        {
            Entidades.PranchaImagem rs = new Entidades.PranchaImagem();
            List<Entidades.PranchaImagem> ListarAll = new List<Entidades.PranchaImagem>();
            string sql = @"USPPranchaImagemListar";
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
                                rs = new Entidades.PranchaImagem();
                                rs.IdImagem = Int32.Parse(dt.Rows[i]["IDIMAGEM"].ToString());
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());

                                rs.Imagem = dt.Rows[i]["IMAGEM"].ToString();
                                rs.Caminho = dt.Rows[i]["CAMINHO"].ToString();
                                rs.Capa = Boolean.Parse(dt.Rows[i]["CAPA"].ToString());
                                
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

        public List<Entidades.PranchaImagem> ListarPranchaImagemFornecedor(long id)
        {
            Entidades.PranchaImagem rs = new Entidades.PranchaImagem();
            List<Entidades.PranchaImagem> ListarAll = new List<Entidades.PranchaImagem>();
            string sql = @"USPPranchaImagemFornecedorListar";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "IDFORNECEDOR", DbType.Int32, id);
                        //conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.PranchaImagem();
                                rs = new Entidades.PranchaImagem();
                                rs.IdImagem = Int32.Parse(dt.Rows[i]["IDIMAGEM"].ToString());
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());

                                rs.Imagem = dt.Rows[i]["IMAGEM"].ToString();
                                rs.Caminho = dt.Rows[i]["CAMINHO"].ToString();
                                rs.Capa = Boolean.Parse(dt.Rows[i]["CAPA"].ToString());

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

        public void update(Entidades.PranchaImagem Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPranchaImagemCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDIMAGEM", DbType.Int32, Obj.IdImagem);
                        conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                        conn.AddInParameter(cmd, "@IMAGEM", DbType.String, Obj.Imagem);
                        conn.AddInParameter(cmd, "@CAMINHO", DbType.String, Obj.Caminho);
                        conn.AddInParameter(cmd, "@CAPA", DbType.Boolean, Obj.Capa);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddOutParameter(cmd, "@RESPOSTA", DbType.Int32, Int32.MaxValue);

                        cmd.ExecuteNonQuery();
                        Resposta = (Int32)conn.GetParameterValue(cmd, "@RESPOSTA");
                        Obj.Resposta = Resposta;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Entidades.PranchaImagem> Buscar(Entidades.PranchaImagem Obj)
        {
            Entidades.PranchaImagem rs = new Entidades.PranchaImagem();
            List<Entidades.PranchaImagem> ListarAll = new List<Entidades.PranchaImagem>();
            string sql = @"USPPranchaImagemBuscar";
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
                        conn.AddInParameter(cmd, "@BUSCAR", DbType.String, Obj.Imagem);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.PranchaImagem();
                                rs.IdImagem = Int32.Parse(dt.Rows[i]["IDIMAGEM"].ToString());
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());

                                rs.Imagem = dt.Rows[i]["IMAGEM"].ToString();
                                rs.Caminho = dt.Rows[i]["CAMINHO"].ToString();
                                rs.Capa = Boolean.Parse(dt.Rows[i]["CAPA"].ToString());

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

        public bool find(Entidades.PranchaImagem Obj)
        {

            bool TemRegistros;
            string sql = "USPPranchaImagemDetalhes " + Obj.IdImagem + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdImagem = Convert.ToInt64(reader[0].ToString());
                    Obj.IdPrancha = Convert.ToInt32(reader[1].ToString());
                    Obj.Imagem = (reader[2].ToString());
                    Obj.Caminho = (reader[3].ToString());
                    Obj.Capa = Convert.ToBoolean(reader[4].ToString());
                    Obj.IdStatus = Convert.ToInt32(reader[5].ToString());
                    Obj.Status.NomeStatus = reader[6].ToString();
                    if (!String.IsNullOrEmpty(reader[7].ToString()))
                    {
                        Obj.DataCadastro = DateTime.Parse(reader[7].ToString());
                    }
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

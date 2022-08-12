using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;


namespace DAL
{
    public class Usuario 
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Usuario()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas


        public void create(Entidades.Usuario Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPUsuarioCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDUsuario", DbType.Int32, Obj.IdUsuario);
                        conn.AddInParameter(cmd, "@NOME", DbType.String, Obj.Nome);
                        conn.AddInParameter(cmd, "@LOGIN", DbType.String, Obj.Login);
                        conn.AddInParameter(cmd, "@SENHA", DbType.String, Obj.Senha);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@IDNIVEL", DbType.Int32, Obj.IdNivel);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void delete(Entidades.Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.Usuario Detalhes(long Id)
        {
            try
            {
                Entidades.Usuario rs = new Entidades.Usuario();

                string sql = @"USPUsuarioDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDUsuario", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdUsuario = Int32.Parse(dt.Rows[0]["IDUsuario"].ToString());
                                rs.Nome = dt.Rows[0]["NOME"].ToString();
                                rs.Login = dt.Rows[0]["IDFACEBOOK"].ToString();
                                rs.Senha = dt.Rows[0]["SOBRENOME"].ToString();
                                rs.Email = dt.Rows[0]["EMAIL"].ToString();
                                rs.IdNivel = Int32.Parse(dt.Rows[0]["IDPLANO"].ToString());
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

        public Entidades.Usuario Logar(Entidades.Usuario Obj)
        {
            try
            {
                Entidades.Usuario rs = new Entidades.Usuario();

                string sql = @"USPUsuarioLogin";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@LOGIN", DbType.String, Obj.Login);
                        conn.AddInParameter(cmd, "@SENHA", DbType.String, Obj.Senha);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdUsuario = Int32.Parse(dt.Rows[0]["IDUsuario"].ToString());
                                rs.Nome = dt.Rows[0]["NOME"].ToString();
                                rs.Login = dt.Rows[0]["LOGIN"].ToString();
                                rs.Senha = dt.Rows[0]["SENHA"].ToString();
                                rs.Email = dt.Rows[0]["EMAIL"].ToString();
                                rs.IdNivel = Int32.Parse(dt.Rows[0]["IDNIVEL"].ToString());
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


        public List<Entidades.Usuario> findAll()
        {
            Entidades.Usuario rs = new Entidades.Usuario();
            List<Entidades.Usuario> ListarAll = new List<Entidades.Usuario>();
            string sql = @"USPUsuarioListar";
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
                                rs = new Entidades.Usuario();
                                rs.IdUsuario = Int32.Parse(dt.Rows[i]["IDUsuario"].ToString());
                                rs.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Login = dt.Rows[i]["LOGIN"].ToString();
                                rs.Senha = dt.Rows[i]["SENHA"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.IdNivel = Int32.Parse(dt.Rows[i]["IDNIVEL"].ToString());
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

        public void update(Entidades.Usuario Obj)
        {

            try
            {
                string sql = @"USPUsuarioEdicao";

                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDUsuario", DbType.Int32, Obj.IdUsuario);
                        conn.AddInParameter(cmd, "@NOME", DbType.String, Obj.Nome);
                        conn.AddInParameter(cmd, "@LOGIN", DbType.String, Obj.Login);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@IDNIVEL", DbType.String, Obj.IdNivel);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Entidades.Usuario> Buscar(Entidades.Usuario Obj)
        {
            Entidades.Usuario rs = new Entidades.Usuario();
            List<Entidades.Usuario> ListarAll = new List<Entidades.Usuario>();
            string sql = @"USPUsuarioBuscar";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@BUSCA", DbType.String, Obj.Nome);
                        //conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Cliente.Nome);
                        //conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Usuario();
                                rs.IdUsuario = Int32.Parse(dt.Rows[i]["IDUsuario"].ToString());
                                rs.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Login = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.Senha = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.IdNivel = Int32.Parse(dt.Rows[i]["IDPLANO"].ToString());
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

        public bool find(Entidades.Usuario Obj)
        {

            bool TemRegistros;
            string sql = "USPUsuarioDetalhe " + Obj.IdUsuario + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdUsuario = Convert.ToInt64(reader[0].ToString());
                    Obj.Nome = (reader[1].ToString());
                    Obj.Login = reader[2].ToString();
                    Obj.Senha = (reader[3].ToString());
                    Obj.Email = (reader[4].ToString());
                    Obj.IdNivel = Convert.ToInt32(reader[5].ToString());
                    if (!String.IsNullOrEmpty(reader[6].ToString()))
                    {
                        Obj.DataCadastro = DateTime.Parse(reader[6].ToString());
                    }

                    Obj.IdStatus = Convert.ToInt32(reader[7].ToString());
                    Obj.Status.NomeStatus = reader[8].ToString();
                   

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

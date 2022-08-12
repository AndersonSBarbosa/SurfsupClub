using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;


namespace DAL
{
    public class Cliente
    {

        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Cliente()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public bool BuscarCPF(Entidades.Cliente Obj)
        {
            bool TemRegistros;
            string sql = "select CPF FROM TB_CLIENTE WHERE CPF = '" + Obj.CPF + "' ";
            try
            {
                comando = new SqlCommand(sql,objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {
                    Obj.CPF = reader[0].ToString();
                    Obj.Resposta = -2;
                }
                else
                {
                    Obj.Resposta = 0;
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

        public bool BuscarEMAIL(Entidades.Cliente Obj)
        {
            bool TemRegistros;
            string sql = "select EMAIL FROM TB_CLIENTE WHERE EMAIL = '" + Obj.Email + "' ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {
                    Obj.Email = reader[0].ToString();
                    Obj.Resposta = -2;
                }
                else
                {
                    Obj.Resposta = 0;
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

        public bool BuscarCPFIdCliente(Entidades.Cliente Obj)
        {
            bool TemRegistros;
            string sql = "select CPF FROM TB_CLIENTE WHERE CPF = '" + Obj.CPF + "' AND IDCLIENTE = " + Obj.IdCliente + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {
                    Obj.CPF = reader[0].ToString();
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

        public void create(Entidades.Cliente Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPClienteCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                        conn.AddInParameter(cmd, "@IDFACEBOOK", DbType.String, Obj.IdFacebook);
                        conn.AddInParameter(cmd, "@NOME", DbType.String, Obj.Nome);
                        conn.AddInParameter(cmd, "@SOBRENOME ", DbType.String, Obj.Sobrenome);
                        conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.CPF);
                        conn.AddInParameter(cmd, "@ENDERECO", DbType.String, Obj.Endereco);
                        conn.AddInParameter(cmd, "@NUMERO", DbType.String, Obj.Numero);
                        conn.AddInParameter(cmd, "@COMPLEMENTO", DbType.String, Obj.Complemento);
                        conn.AddInParameter(cmd, "@BAIRRO", DbType.String, Obj.Bairro);
                        conn.AddInParameter(cmd, "@CEP", DbType.String, Obj.CEP);
                        conn.AddInParameter(cmd, "@CIDADE", DbType.String, Obj.Cidade);
                        conn.AddInParameter(cmd, "@ESTADO", DbType.String, Obj.Estado);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@RG", DbType.String, Obj.RG);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@ALTURA", DbType.String, Obj.Altura);
                        conn.AddInParameter(cmd, "@PESO", DbType.String, Obj.Peso);
                        conn.AddInParameter(cmd, "@DATANASCIMENTO", DbType.Date, Obj.DataNascimento);
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

        public void delete(Entidades.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.Cliente obj)
        {

            bool TemRegistros;
            string sql = "USPClienteDetalhes " + obj.IdCliente + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {

                    obj.IdCliente = Convert.ToInt64(reader[0].ToString());
                    obj.Nome = reader[1].ToString();
                    obj.Sobrenome = reader[2].ToString();
                    obj.IdFacebook = reader[3].ToString();
                    obj.Email = reader[4].ToString();
                    obj.CPF = reader[5].ToString();
                    obj.RG = reader[6].ToString();
                    obj.Altura = reader[7].ToString();
                    obj.Peso = reader[8].ToString();
                    obj.DataNascimento = Convert.ToDateTime(reader[9].ToString());
                    obj.Endereco = reader[10].ToString();
                    obj.Numero = reader[11].ToString();
                    obj.Complemento = reader[12].ToString();
                    obj.Bairro = reader[13].ToString();
                    obj.CEP = reader[14].ToString();
                    obj.Cidade = reader[15].ToString();
                    obj.Estado = reader[16].ToString();
                    obj.DataCadastro = Convert.ToDateTime(reader[17].ToString());
                    obj.CodigoInterno = reader[18].ToString();
                    obj.IdStatus = Convert.ToInt32(reader[19].ToString());
                    obj.Status.NomeStatus = reader[20].ToString();

                    obj.Resposta = 5;

                }
                else
                {
                    obj.Resposta = 6;
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

        public Entidades.Cliente ClienteDetalhes(long IdCliente)
        {
            try
            {
                Entidades.Cliente rs = new Entidades.Cliente();

                string sql = @"USPClienteDetalhes";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Convert.ToInt32(IdCliente));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                rs.IdCliente = Int32.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
                                rs.Nome = dt.Rows[0]["NOME"].ToString();
                                rs.Sobrenome = dt.Rows[0]["SOBRENOME"].ToString();
                                rs.IdFacebook = dt.Rows[0]["IDFACEBOOK"].ToString();
                                rs.CPF = dt.Rows[0]["CPF"].ToString();
                                rs.RG = dt.Rows[0]["RG"].ToString();
                                rs.Altura = dt.Rows[0]["ALTURA"].ToString();
                                rs.Peso = dt.Rows[0]["PESO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATANASCIMENTO"].ToString()))
                                {
                                    rs.DataNascimento = DateTime.Parse(dt.Rows[0]["DATANASCIMENTO"].ToString());
                                }
                                rs.Endereco = dt.Rows[0]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[0]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[0]["COMPLEMENTO"].ToString();
                                rs.Bairro = dt.Rows[0]["BAIRRO"].ToString();
                                rs.CEP = dt.Rows[0]["CEP"].ToString();
                                rs.Cidade = dt.Rows[0]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[0]["ESTADO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
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

        public List<Entidades.Cliente> findAll()
        {
            Entidades.Cliente rs = new Entidades.Cliente();
            List<Entidades.Cliente> ListarAll = new List<Entidades.Cliente>();
            string sql = @"USPClienteListar";
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
                                rs = new Entidades.Cliente();
                                rs.IdCliente = Int32.Parse(dt.Rows[i]["IDCLIENTE"].ToString());
                                rs.Nome = dt.Rows[i]["NOME"].ToString();
                                rs.Sobrenome = dt.Rows[i]["SOBRENOME"].ToString();
                                rs.IdFacebook = dt.Rows[i]["IDFACEBOOK"].ToString();
                                rs.CPF = dt.Rows[i]["CPF"].ToString();
                                rs.RG = dt.Rows[i]["RG"].ToString();
                                rs.Altura = dt.Rows[i]["ALTURA"].ToString();
                                rs.Peso = dt.Rows[i]["PESO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATANASCIMENTO"].ToString()))
                                {
                                    rs.DataNascimento = DateTime.Parse(dt.Rows[i]["DATANASCIMENTO"].ToString());
                                }
                                rs.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[i]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                                rs.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                                rs.CEP = dt.Rows[i]["CEP"].ToString();
                                rs.Cidade = dt.Rows[i]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[i]["ESTADO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
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

        public void update(Entidades.Cliente Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPClienteCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                        conn.AddInParameter(cmd, "@IDFACEBOOK", DbType.String, Obj.IdFacebook);
                        conn.AddInParameter(cmd, "@NOME", DbType.String, Obj.Nome);
                        conn.AddInParameter(cmd, "@SOBRENOME ", DbType.String, Obj.Sobrenome);
                        conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.CPF);
                        conn.AddInParameter(cmd, "@ENDERECO", DbType.String, Obj.Endereco);
                        conn.AddInParameter(cmd, "@NUMERO", DbType.String, Obj.Numero);
                        conn.AddInParameter(cmd, "@COMPLEMENTO", DbType.String, Obj.Complemento);
                        conn.AddInParameter(cmd, "@BAIRRO", DbType.String, Obj.Bairro);
                        conn.AddInParameter(cmd, "@CEP", DbType.String, Obj.CEP);
                        conn.AddInParameter(cmd, "@CIDADE", DbType.String, Obj.Cidade);
                        conn.AddInParameter(cmd, "@ESTADO", DbType.String, Obj.Estado);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@RG", DbType.String, Obj.RG);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@ALTURA", DbType.String, Obj.Altura);
                        conn.AddInParameter(cmd, "@PESO", DbType.String, Obj.Peso);
                        conn.AddInParameter(cmd, "@DATANASCIMENTO", DbType.Date, Obj.DataNascimento);
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

        public List<Entidades.Cliente> Buscar(Entidades.Cliente Obj)
        {
            Entidades.Cliente rs = new Entidades.Cliente();
            List<Entidades.Cliente> ListarAll = new List<Entidades.Cliente>();
            string sql = @"USPClienteBusca";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@CPF", DbType.String, Obj.CPF);
                        conn.AddInParameter(cmd, "@NOMECOMPLETO", DbType.String, Obj.Nome);
                        conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Cliente();
                                rs.IdCliente = Int32.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
                                rs.Nome = dt.Rows[0]["NOME"].ToString();
                                rs.Sobrenome = dt.Rows[0]["SOBRENOME"].ToString();
                                rs.IdFacebook = dt.Rows[0]["IDFACEBOOK"].ToString();
                                rs.CPF = dt.Rows[0]["CPF"].ToString();
                                rs.RG = dt.Rows[0]["RG"].ToString();
                                rs.Altura = dt.Rows[0]["ALTURA"].ToString();
                                rs.Peso = dt.Rows[0]["PESO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATANASCIMENTO"].ToString()))
                                {
                                    rs.DataNascimento = DateTime.Parse(dt.Rows[0]["DATANASCIMENTO"].ToString());
                                }
                                rs.Endereco = dt.Rows[0]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[0]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[0]["COMPLEMENTO"].ToString();
                                rs.Bairro = dt.Rows[0]["BAIRRO"].ToString();
                                rs.CEP = dt.Rows[0]["CEP"].ToString();
                                rs.Cidade = dt.Rows[0]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[0]["ESTADO"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["STATUS"].ToString();
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

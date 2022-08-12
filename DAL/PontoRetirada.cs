using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
    public class PontoRetirada 
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PontoRetirada()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        public void create(Entidades.PontoRetirada Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPontoRetiradaCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPontoRetirada", DbType.Int32, Obj.IdPontoRetidada);
                        conn.AddInParameter(cmd, "@NOMEFANTASIA", DbType.String, Obj.NomeFantasia);
                        conn.AddInParameter(cmd, "@RAZAOSOCIAL ", DbType.String, Obj.RazaoSocial);
                        conn.AddInParameter(cmd, "@CNPJ", DbType.String, Obj.CNPJ);
                        conn.AddInParameter(cmd, "@ENDERECO", DbType.String, Obj.Endereco);
                        conn.AddInParameter(cmd, "@NUMERO", DbType.String, Obj.Numero);
                        conn.AddInParameter(cmd, "@COMPLEMENTO", DbType.String, Obj.Complemento);
                        conn.AddInParameter(cmd, "@BAIRRO", DbType.String, Obj.Bairro);
                        conn.AddInParameter(cmd, "@CEP", DbType.String, Obj.CEP);
                        conn.AddInParameter(cmd, "@CIDADE", DbType.String, Obj.Cidade);
                        conn.AddInParameter(cmd, "@ESTADO", DbType.String, Obj.Estado);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@IE", DbType.String, Obj.IE);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@LATITUDE", DbType.String, Obj.Latitude);
                        conn.AddInParameter(cmd, "@LONGITUDE", DbType.String, Obj.Longitude);
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

        public void delete(Entidades.PontoRetirada obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.PontoRetirada Detalhes(long Id)
        {
            try
            {
                Entidades.PontoRetirada rs = new Entidades.PontoRetirada();

                string sql = @"USPPontoRetiradaDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPontoRetirada", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                rs.IdPontoRetidada = Int32.Parse(dt.Rows[0]["IDPONTORETIRADA"].ToString());
                                rs.NomeFantasia = dt.Rows[0]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[0]["CNPJ"].ToString();
                                rs.IE = dt.Rows[0]["IE"].ToString();
                                rs.Endereco = dt.Rows[0]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[0]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[0]["COMPLEMENTO"].ToString();
                                rs.CEP = dt.Rows[0]["CEP"].ToString();
                                rs.Cidade = dt.Rows[0]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[0]["ESTADO"].ToString();
                                rs.Latitude = dt.Rows[0]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[0]["LONGITUDE"].ToString();
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

        public List<Entidades.PontoRetirada> findAll()
        {
            Entidades.PontoRetirada rs = new Entidades.PontoRetirada();
            List<Entidades.PontoRetirada> ListarAll = new List<Entidades.PontoRetirada>();
            string sql = @"USPPontoRetiradaListar";
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
                                rs = new Entidades.PontoRetirada();
                                rs.IdPontoRetidada = Int32.Parse(dt.Rows[i]["IDPONTORETIRADA"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[i]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                                rs.CEP = dt.Rows[i]["CEP"].ToString();
                                rs.Cidade = dt.Rows[i]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[i]["ESTADO"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
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

        public void update(Entidades.PontoRetirada Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPontoRetiradaCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPontoRetirada", DbType.Int32, Obj.IdPontoRetidada);
                        conn.AddInParameter(cmd, "@NOMEFANTASIA", DbType.String, Obj.NomeFantasia);
                        conn.AddInParameter(cmd, "@RAZAOSOCIAL ", DbType.String, Obj.RazaoSocial);
                        conn.AddInParameter(cmd, "@CNPJ", DbType.String, Obj.CNPJ);
                        conn.AddInParameter(cmd, "@ENDERECO", DbType.String, Obj.Endereco);
                        conn.AddInParameter(cmd, "@NUMERO", DbType.String, Obj.Numero);
                        conn.AddInParameter(cmd, "@COMPLEMENTO", DbType.String, Obj.Complemento);
                        conn.AddInParameter(cmd, "@BAIRRO", DbType.String, Obj.Bairro);
                        conn.AddInParameter(cmd, "@CEP", DbType.String, Obj.CEP);
                        conn.AddInParameter(cmd, "@CIDADE", DbType.String, Obj.Cidade);
                        conn.AddInParameter(cmd, "@ESTADO", DbType.String, Obj.Estado);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@IE", DbType.String, Obj.IE);
                        conn.AddInParameter(cmd, "@EMAIL", DbType.String, Obj.Email);
                        conn.AddInParameter(cmd, "@LATITUDE", DbType.String, Obj.Latitude);
                        conn.AddInParameter(cmd, "@LONGITUDE", DbType.String, Obj.Longitude);
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

        public List<Entidades.PontoRetirada> Buscar(Entidades.PontoRetirada Obj)
        {
            Entidades.PontoRetirada rs = new Entidades.PontoRetirada();
            List<Entidades.PontoRetirada> ListarAll = new List<Entidades.PontoRetirada>();
            string sql = @"USPPontoRetiradaBuscar";
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
                                rs = new Entidades.PontoRetirada();
                                rs.IdPontoRetidada = Int32.Parse(dt.Rows[i]["IDPONTORETIRADA"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[i]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                                rs.CEP = dt.Rows[i]["CEP"].ToString();
                                rs.Cidade = dt.Rows[i]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[i]["ESTADO"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
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

        public bool find(Entidades.PontoRetirada Obj)
        {

            bool TemRegistros;
            string sql = "USPPontoRetiradaDetalhe " + Obj.IdPontoRetidada + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdPontoRetidada = Convert.ToInt64(reader[0].ToString());
                    Obj.NomeFantasia = reader[1].ToString();
                    Obj.RazaoSocial = reader[2].ToString();
                    Obj.CNPJ = reader[3].ToString();
                    Obj.IE = reader[4].ToString();
                    Obj.Endereco = reader[5].ToString();
                    Obj.Numero = reader[6].ToString();
                    Obj.Complemento = reader[7].ToString();
                    Obj.Bairro = reader[8].ToString();
                    Obj.CEP = reader[9].ToString();
                    Obj.Cidade = reader[10].ToString();
                    Obj.Estado = reader[11].ToString();
                    Obj.Email = reader[12].ToString();
                    Obj.IdStatus = Convert.ToInt32(reader[13].ToString());
                    Obj.Status.NomeStatus = reader[14].ToString();
                    Obj.DataCadastro = Convert.ToDateTime(reader[15].ToString());
                    Obj.Latitude = reader[16].ToString();
                    Obj.Longitude = reader[17].ToString();
                    Obj.CodigoInterno = reader[18].ToString();

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

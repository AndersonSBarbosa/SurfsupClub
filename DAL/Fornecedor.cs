using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace DAL
{
   public class Fornecedor

    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Fornecedor()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public bool BuscarCNPJ(Entidades.Fornecedor Obj)
        {
            bool TemRegistros;
            string sql = "select CNPJ FROM TB_FORNECEDOR WHERE CNPJ = '" + Obj.CNPJ + "' ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {
                    //Obj.IdFornecedor = Convert.ToInt64(reader[0].ToString());
                    Obj.CNPJ = reader[0].ToString();
                    //Obj.NomeFantasia = reader[2].ToString();
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

        public bool BuscarCNPJIdFornecedor(Entidades.Fornecedor Obj)
        {
            bool TemRegistros;
            string sql = "select CNPJ FROM TB_FORNECEDOR WHERE CNPJ = '" + Obj.CNPJ + "' AND IDFORNECEDOR = " + Obj.IdFornecedor + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {
                    //Obj.IdFornecedor = Convert.ToInt64(reader[0].ToString());
                    Obj.CNPJ = reader[0].ToString();
                    //Obj.NomeFantasia = reader[2].ToString();
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

        public void create(Entidades.Fornecedor Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPFornecedorCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                            conn.AddInParameter(cmd,"@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
                            conn.AddInParameter(cmd,"@NOMEFANTASIA", DbType.String, Obj.NomeFantasia);
                            conn.AddInParameter(cmd,"@RAZAOSOCIAL ", DbType.String, Obj.RazaoSocial);
                            conn.AddInParameter(cmd,"@CNPJ", DbType.String, Obj.CNPJ);
                            conn.AddInParameter(cmd,"@ENDERECO", DbType.String, Obj.Endereco);
                            conn.AddInParameter(cmd,"@NUMERO", DbType.String, Obj.Numero);
                            conn.AddInParameter(cmd,"@COMPLEMENTO", DbType.String, Obj.Complemento);
                            conn.AddInParameter(cmd,"@BAIRRO", DbType.String, Obj.Bairro);
                            conn.AddInParameter(cmd,"@CEP", DbType.String, Obj.CEP);
                            conn.AddInParameter(cmd,"@CIDADE", DbType.String, Obj.Cidade);
                            conn.AddInParameter(cmd,"@ESTADO", DbType.String, Obj.Estado);
                            conn.AddInParameter(cmd,"@IDSTATUS", DbType.Int32, Obj.IdStatus);
                            conn.AddInParameter(cmd,"@IE", DbType.String, Obj.IE);
                            conn.AddInParameter(cmd,"@EMAIL", DbType.String, Obj.Email);
                            conn.AddInParameter(cmd,"@LATITUDE", DbType.String, Obj.Latitude);
                            conn.AddInParameter(cmd,"@LONGITUDE", DbType.String, Obj.Longitude);
                            conn.AddInParameter(cmd, "@TELEFONE1", DbType.String, Obj.Telefone1);
                            conn.AddInParameter(cmd, "@TELEFONE2", DbType.String, Obj.Telefone2);
                            conn.AddInParameter(cmd, "@TELEFONE3", DbType.String, Obj.Telefone3);
                            conn.AddInParameter(cmd, "@TELEFONE4", DbType.String, Obj.Telefone4);
                            conn.AddInParameter(cmd, "@PONTOENTREGARETIRADA", DbType.Boolean, Obj.PontoEntregaRetirada);
                            conn.AddInParameter(cmd, "@FABRICANTE", DbType.Boolean, Obj.Fabricante);
                            conn.AddOutParameter(cmd,"@RESPOSTA", DbType.Int32, Int32.MaxValue);
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

        public void delete(Entidades.Fornecedor obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.Fornecedor obj)
        {

            bool TemRegistros;
            string sql = "USPFornecedorDetalhes " + obj.IdFornecedor + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {

                    obj.IdFornecedor = Convert.ToInt64(reader[0].ToString());
                    obj.NomeFantasia = reader[1].ToString();
                    obj.RazaoSocial = reader[2].ToString();
                    obj.CNPJ = reader[3].ToString();
                    obj.Endereco = reader[4].ToString();
                    obj.Numero = reader[5].ToString();
                    obj.Complemento = reader[6].ToString();
                    obj.Bairro = reader[7].ToString();
                    obj.CEP = reader[8].ToString();
                    obj.Cidade = reader[9].ToString();
                    obj.Estado = reader[10].ToString();
                    obj.DataCadastro = Convert.ToDateTime(reader[11].ToString());
                    obj.IdStatus = Convert.ToInt32(reader[12].ToString());
                    obj.Status.NomeStatus = reader[13].ToString();
                    obj.IE = reader[14].ToString();
                    obj.Email = reader[15].ToString();
                    obj.Latitude = reader[16].ToString();
                    obj.Longitude = reader[17].ToString();
                    obj.CodigoInterno = reader[18].ToString();
                    obj.Telefone1 = reader[19].ToString();
                    obj.Telefone2 = reader[20].ToString();
                    obj.Telefone3 = reader[21].ToString();
                    obj.Telefone4 = reader[22].ToString();
                    obj.PontoEntregaRetirada = Convert.ToBoolean(reader[23].ToString());
                    obj.Fabricante = Convert.ToBoolean(reader[24].ToString());

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

        public Entidades.Fornecedor Detalhes(long Id)
        {
            try
            {
                Entidades.Fornecedor rs = new Entidades.Fornecedor();

                string sql = @"USPFornecedorDetalhes";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdFornecedor = Int32.Parse(dt.Rows[0]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[0]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[0]["CNPJ"].ToString();
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
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["STATUS"].ToString();
                                rs.IE = dt.Rows[0]["IE"].ToString();
                                rs.Email = dt.Rows[0]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[0]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[0]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[0]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[0]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[0]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[0]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[0]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[0]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[0]["FABRICANTE"].ToString());


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

        public List<Entidades.Fornecedor> findAll()
        {
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            List<Entidades.Fornecedor> ListarAll = new List<Entidades.Fornecedor>();
            string sql = @"USPFornecedorListar";
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
                                rs = new Entidades.Fornecedor();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
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
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[i]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[i]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[i]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[i]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[i]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[i]["FABRICANTE"].ToString());
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

        public List<Entidades.Fornecedor> ListarFornecedorVinculadoUsuario( Int32 Carregamento, Int32 IdFornecedor, Int32 IdUsuario )
        {
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            List<Entidades.Fornecedor> ListarAll = new List<Entidades.Fornecedor>();
            string sql = @"USPUsuarioFornecedorListar";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@CARREGAMENTO", DbType.Int32, Carregamento);
                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, IdFornecedor);
                        conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);


                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Fornecedor();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                                rs.Numero = dt.Rows[i]["NUMERO"].ToString();
                                rs.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                                rs.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                                rs.CEP = dt.Rows[i]["CEP"].ToString();
                                rs.Cidade = dt.Rows[i]["CIDADE"].ToString();
                                rs.Estado = dt.Rows[i]["ESTADO"].ToString();
                                //if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                //{
                                //    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                //}
                                //rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                //rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[i]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[i]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[i]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[i]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[i]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[i]["FABRICANTE"].ToString());
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
        
        public void update(Entidades.Fornecedor Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPFornecedorCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
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
                        conn.AddInParameter(cmd, "@TELEFONE1", DbType.String, Obj.Telefone1);
                        conn.AddInParameter(cmd, "@TELEFONE2", DbType.String, Obj.Telefone2);
                        conn.AddInParameter(cmd, "@TELEFONE3", DbType.String, Obj.Telefone3);
                        conn.AddInParameter(cmd, "@TELEFONE4", DbType.String, Obj.Telefone4);
                        conn.AddInParameter(cmd, "@PONTOENTREGARETIRADA", DbType.Boolean, Obj.PontoEntregaRetirada);
                        conn.AddInParameter(cmd, "@FABRICANTE", DbType.Boolean, Obj.Fabricante);
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

        public void VincularFornecedoresUsuario(Entidades.Fornecedor Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPUsuarioVincularFornecedores";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, Obj.Usuario.IdUsuario);
                        cmd.ExecuteNonQuery();
                        

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public List<Entidades.Fornecedor> BuscarRazaoSocialCNPJCodInterno(Entidades.Fornecedor Obj)
        {
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            List<Entidades.Fornecedor> ListarAll = new List<Entidades.Fornecedor>();
            string sql = @"USPFornecedorBuscarRazaoSocialCNPJCodInterno";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@CNPJ", DbType.String, Obj.CNPJ);
                        conn.AddInParameter(cmd, "@RAZAOSOCIALNOMEFANTASIA", DbType.String, Obj.RazaoSocial);
                        conn.AddInParameter(cmd, "@CODINTERNO", DbType.String, Obj.CodigoInterno);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Fornecedor();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
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
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[i]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[i]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[i]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[i]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[i]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[i]["FABRICANTE"].ToString());
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


        public List<Entidades.Fornecedor> ListarAllFornecedorAtivo()
        {
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            List<Entidades.Fornecedor> ListarAll = new List<Entidades.Fornecedor>();
            string sql = "SELECT * FROM TB_FORNECEDOR where IDSTATUS = 1 and FABRICANTE = 1 ";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
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
                                rs = new Entidades.Fornecedor();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
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
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[i]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[i]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[i]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[i]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[i]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[i]["FABRICANTE"].ToString());
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

        public List<Entidades.Fornecedor> ListarFornecedorSelecionado(Int32 idFornecedor)
        {
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            List<Entidades.Fornecedor> ListarAll = new List<Entidades.Fornecedor>();
            string sql = "SELECT * FROM TB_FORNECEDOR where IDSTATUS = 1 and FABRICANTE = 1 and IDFORNECEDOR = "+ idFornecedor + " ";
            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
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
                                rs = new Entidades.Fornecedor();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.CNPJ = dt.Rows[i]["CNPJ"].ToString();
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
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.IE = dt.Rows[i]["IE"].ToString();
                                rs.Email = dt.Rows[i]["EMAIL"].ToString();
                                rs.Latitude = dt.Rows[i]["LATITUDE"].ToString();
                                rs.Longitude = dt.Rows[i]["LONGITUDE"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNO"].ToString();
                                rs.Telefone1 = dt.Rows[i]["TELEFONE1"].ToString();
                                rs.Telefone2 = dt.Rows[i]["TELEFONE2"].ToString();
                                rs.Telefone3 = dt.Rows[i]["TELEFONE3"].ToString();
                                rs.Telefone4 = dt.Rows[i]["TELEFONE4"].ToString();
                                rs.PontoEntregaRetirada = Boolean.Parse(dt.Rows[i]["PONTOENTREGARETIRADA"].ToString());
                                rs.Fabricante = Boolean.Parse(dt.Rows[i]["FABRICANTE"].ToString());
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

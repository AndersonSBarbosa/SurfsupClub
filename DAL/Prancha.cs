using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
   public class Prancha
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Prancha()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        #region Funções Básicas
        public void create(Entidades.Prancha Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPranchaCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                        conn.AddInParameter(cmd, "@PRANCHA", DbType.String, Obj.NomePrancha);
                        conn.AddInParameter(cmd, "@DESCRICAO", DbType.String, Obj.Descricao);
                        conn.AddInParameter(cmd, "@VOLUME", DbType.String, Obj.Volume);
                        conn.AddInParameter(cmd, "@POLEGADAS", DbType.String, Obj.Polegadas);
                        conn.AddInParameter(cmd, "@ESPESSURA", DbType.String, Obj.Espessura);
                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@IDMARCA", DbType.Int32, Obj.IdMarca);
                        conn.AddInParameter(cmd, "@IDMODELO", DbType.Int32, Obj.IdModelo);
                        conn.AddInParameter(cmd, "@TAMANHO", DbType.String, Obj.Tamanho);
                        conn.AddInParameter(cmd, "@LARGURA", DbType.String, Obj.Largura);
                        conn.AddInParameter(cmd, "@BORDA", DbType.String, Obj.Borda);
                        conn.AddInParameter(cmd, "@LITRAGEM", DbType.String, Obj.Litragem);
                        conn.AddInParameter(cmd, "@IDMODALIDADE", DbType.Int32, Obj.IdModalidade);
                        conn.AddInParameter(cmd, "@IDTIPOITEM", DbType.Int32, Obj.IdTipoItem);
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

        public void delete(Entidades.Prancha obj)
        {
            throw new NotImplementedException();
        }

        public Entidades.Prancha Detalhes(long Id)
        {
            try
            {
                Entidades.Prancha rs = new Entidades.Prancha();

                string sql = @"USPPranchaDetalhe";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPrancha", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {

                                rs.IdPrancha = Int32.Parse(dt.Rows[0]["IDPRANCHA"].ToString());
                                rs.NomePrancha = dt.Rows[0]["PRANCHA"].ToString();
                                rs.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
                                rs.Volume = dt.Rows[0]["VOLUME"].ToString();
                                rs.Polegadas = dt.Rows[0]["POLEGADAS"].ToString();
                                rs.Espessura = dt.Rows[0]["ESPESSURA"].ToString();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[0]["IDFORNECEDOR"].ToString());
                                rs.Fornecedor.NomeFantasia = dt.Rows[0]["NOMEFANTASIA"].ToString();
                                rs.Fornecedor.RazaoSocial = dt.Rows[0]["RAZAOSOCIAL"].ToString();
                                rs.Fornecedor.CNPJ = dt.Rows[0]["CNPJ"].ToString();
                                rs.Fornecedor.CodigoInterno = dt.Rows[0]["CODIGOINTERNOFORNECEDOR"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[0]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[0]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[0]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[0]["[STATUS]"].ToString();
                                rs.CodigoInterno = dt.Rows[0]["CODINTERNOPRANCHA"].ToString();
                                rs.IdMarca = Int32.Parse(dt.Rows[0]["IDMARCA"].ToString());
                                rs.PranchaMarca.Marca = dt.Rows[0]["MARCA"].ToString();
                                rs.IdModelo = Int32.Parse(dt.Rows[0]["IDMODELO"].ToString());
                                rs.PranchaModelo.Modelo = dt.Rows[0]["MODELO"].ToString();
                                rs.Tamanho = dt.Rows[0]["TAMANHO"].ToString();
                                rs.Largura = dt.Rows[0]["LARGURA"].ToString();
                                rs.Borda = dt.Rows[0]["BORDA"].ToString();
                                rs.Litragem = dt.Rows[0]["LITRAGEM"].ToString();
                                rs.IdModalidade = Int32.Parse(dt.Rows[0]["IDMODALIDADE"].ToString());
                                rs.PranchaModalidade.Modalidade = dt.Rows[0]["MODALIDADE"].ToString();
                                rs.PranchaImagem.QuantidadeImagem = Int32.Parse(dt.Rows[0]["QUANTIDADEIMAGENS"].ToString());
                                rs.PranchaImagem.Imagem = dt.Rows[0]["CAPA"].ToString();

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

        public List<Entidades.Prancha> findAll()
        {
            Entidades.Prancha rs = new Entidades.Prancha();
            List<Entidades.Prancha> ListarAll = new List<Entidades.Prancha>();
            string sql = @"USPPranchaListar";
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
                                rs = new Entidades.Prancha();
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                rs.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                rs.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                rs.Volume = dt.Rows[i]["VOLUME"].ToString();
                                rs.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                rs.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.Fornecedor.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.Fornecedor.CodigoInterno = dt.Rows[i]["CODINTERNOFORNECEDOR"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNOPRANCHA"].ToString();
                                rs.IdMarca = Int32.Parse(dt.Rows[i]["IDMARCA"].ToString());
                                rs.PranchaMarca.Marca = dt.Rows[i]["MARCA"].ToString();
                                rs.IdModelo = Int32.Parse(dt.Rows[i]["IDMODELO"].ToString());
                                rs.PranchaModelo.Modelo = dt.Rows[i]["MODELO"].ToString();
                                rs.Tamanho = dt.Rows[i]["TAMANHO"].ToString();
                                rs.Largura = dt.Rows[i]["LARGURA"].ToString();
                                rs.Borda = dt.Rows[i]["BORDA"].ToString();
                                rs.Litragem = dt.Rows[i]["LITRAGEM"].ToString();
                                rs.IdModalidade = Int32.Parse(dt.Rows[i]["IDMODALIDADE"].ToString());
                                rs.PranchaModalidade.Modalidade = dt.Rows[i]["MODALIDADE"].ToString();
                                rs.PranchaImagem.QuantidadeImagem = Int32.Parse(dt.Rows[i]["QUANTIDADEIMAGENS"].ToString());
                                rs.PranchaImagem.Imagem = dt.Rows[i]["CAPA"].ToString();

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

        public List<Entidades.Prancha> findAllPranchasAtivas()
        {
            Entidades.Prancha rs = new Entidades.Prancha();
            List<Entidades.Prancha> ListarAll = new List<Entidades.Prancha>();
            string sql = @"USPPranchaListarPranchasAtivasSite";
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
                                rs = new Entidades.Prancha();
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                rs.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                rs.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                rs.Volume = dt.Rows[i]["VOLUME"].ToString();
                                rs.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                rs.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.Fornecedor.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.Fornecedor.CodigoInterno = dt.Rows[i]["CODINTERNOFORNECEDOR"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNOPRANCHA"].ToString();
                                rs.IdMarca = Int32.Parse(dt.Rows[i]["IDMARCA"].ToString());
                                rs.PranchaMarca.Marca = dt.Rows[i]["MARCA"].ToString();
                                rs.IdModelo = Int32.Parse(dt.Rows[i]["IDMODELO"].ToString());
                                rs.PranchaModelo.Modelo = dt.Rows[i]["MODELO"].ToString();
                                rs.Tamanho = dt.Rows[i]["TAMANHO"].ToString();
                                rs.Largura = dt.Rows[i]["LARGURA"].ToString();
                                rs.Borda = dt.Rows[i]["BORDA"].ToString();
                                rs.Litragem = dt.Rows[i]["LITRAGEM"].ToString();
                                rs.IdModalidade = Int32.Parse(dt.Rows[i]["IDMODALIDADE"].ToString());
                                rs.PranchaModalidade.Modalidade = dt.Rows[i]["MODALIDADE"].ToString();
                                rs.PranchaImagem.QuantidadeImagem = Int32.Parse(dt.Rows[i]["QUANTIDADEIMAGENS"].ToString());
                                rs.PranchaImagem.Imagem = dt.Rows[i]["CAPA"].ToString();

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

        public List<Entidades.Prancha> ListarPranchaFornecedor(long id)
        {
            Entidades.Prancha rs = new Entidades.Prancha();
            List<Entidades.Prancha> ListarAll = new List<Entidades.Prancha>();
            string sql = @"USPPranchaFornecedorListar";
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
                                rs = new Entidades.Prancha();
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                rs.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                rs.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                rs.Volume = dt.Rows[i]["VOLUME"].ToString();
                                rs.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                rs.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.Fornecedor.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.Fornecedor.CodigoInterno = dt.Rows[i]["CODINTERNOFORNECEDOR"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNOPRANCHA"].ToString();
                                rs.IdMarca = Int32.Parse(dt.Rows[i]["IDMARCA"].ToString());
                                rs.PranchaMarca.Marca = dt.Rows[i]["MARCA"].ToString();
                                rs.IdModelo = Int32.Parse(dt.Rows[i]["IDMODELO"].ToString());
                                rs.PranchaModelo.Modelo = dt.Rows[i]["MODELO"].ToString();
                                rs.Tamanho = dt.Rows[i]["TAMANHO"].ToString();
                                rs.Largura = dt.Rows[i]["LARGURA"].ToString();
                                rs.Borda = dt.Rows[i]["BORDA"].ToString();
                                rs.Litragem = dt.Rows[i]["LITRAGEM"].ToString();
                                rs.IdModalidade = Int32.Parse(dt.Rows[i]["IDMODALIDADE"].ToString());
                                rs.PranchaModalidade.Modalidade = dt.Rows[i]["MODALIDADE"].ToString();
                                rs.PranchaImagem.QuantidadeImagem = Int32.Parse(dt.Rows[i]["QUANTIDADEIMAGENS"].ToString());
                                rs.PranchaImagem.Imagem = dt.Rows[i]["CAPA"].ToString();

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

        public void update(Entidades.Prancha Obj)
        {

            try
            {
                int Resposta = 0;
                string sql = @"USPPranchaCadastroEdicao";


                using (RaiCore.Data conn = new RaiCore.Data())
                {

                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdPrancha);
                        conn.AddInParameter(cmd, "@PRANCHA", DbType.String, Obj.NomePrancha);
                        conn.AddInParameter(cmd, "@DESCRICAO", DbType.String, Obj.Descricao);
                        conn.AddInParameter(cmd, "@VOLUME", DbType.String, Obj.Volume);
                        conn.AddInParameter(cmd, "@POLEGADAS", DbType.String, Obj.Polegadas);
                        conn.AddInParameter(cmd, "@ESPESSURA", DbType.String, Obj.Espessura);
                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@IDMARCA", DbType.Int32, Obj.IdMarca);
                        conn.AddInParameter(cmd, "@IDMODELO", DbType.Int32, Obj.IdModelo);
                        conn.AddInParameter(cmd, "@TAMANHO", DbType.String, Obj.Tamanho);
                        conn.AddInParameter(cmd, "@LARGURA", DbType.String, Obj.Largura);
                        conn.AddInParameter(cmd, "@BORDA", DbType.String, Obj.Borda);
                        conn.AddInParameter(cmd, "@LITRAGEM", DbType.String, Obj.Litragem);
                        conn.AddInParameter(cmd, "@IDMODALIDADE", DbType.Int32, Obj.IdModalidade);
                        conn.AddInParameter(cmd, "@IDTIPOITEM", DbType.Int32, Obj.IdTipoItem);
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

        public List<Entidades.Prancha> Buscar(Entidades.Prancha Obj)
        {
            Entidades.Prancha rs = new Entidades.Prancha();
            List<Entidades.Prancha> ListarAll = new List<Entidades.Prancha>();
            string sql = @"USPPranchaBuscar";
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
                        conn.AddInParameter(cmd, "@BUSCAR", DbType.String, Obj.NomePrancha);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.Prancha();
                                rs.IdPrancha = Int32.Parse(dt.Rows[i]["IDPRANCHA"].ToString());
                                rs.NomePrancha = dt.Rows[i]["PRANCHA"].ToString();
                                rs.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                                rs.Volume = dt.Rows[i]["VOLUME"].ToString();
                                rs.Polegadas = dt.Rows[i]["POLEGADAS"].ToString();
                                rs.Espessura = dt.Rows[i]["ESPESSURA"].ToString();
                                rs.IdFornecedor = Int32.Parse(dt.Rows[i]["IDFORNECEDOR"].ToString());
                                rs.Fornecedor.NomeFantasia = dt.Rows[i]["NOMEFANTASIA"].ToString();
                                rs.Fornecedor.RazaoSocial = dt.Rows[i]["RAZAOSOCIAL"].ToString();
                                rs.Fornecedor.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                                rs.Fornecedor.CodigoInterno = dt.Rows[i]["CODINTERNOFORNECEDOR"].ToString();
                                if (!String.IsNullOrEmpty(dt.Rows[i]["DATACADASTRO"].ToString()))
                                {
                                    rs.DataCadastro = DateTime.Parse(dt.Rows[i]["DATACADASTRO"].ToString());
                                }
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());
                                rs.Status.NomeStatus = dt.Rows[i]["STATUS"].ToString();
                                rs.CodigoInterno = dt.Rows[i]["CODINTERNOPRANCHA"].ToString();
                                rs.IdMarca = Int32.Parse(dt.Rows[i]["IDMARCA"].ToString());
                                rs.PranchaMarca.Marca = dt.Rows[i]["MARCA"].ToString();
                                rs.IdModelo = Int32.Parse(dt.Rows[i]["IDMODELO"].ToString());
                                rs.PranchaModelo.Modelo = dt.Rows[i]["MODELO"].ToString();
                                rs.Tamanho = dt.Rows[i]["TAMANHO"].ToString();
                                rs.Largura = dt.Rows[i]["LARGURA"].ToString();
                                rs.Borda = dt.Rows[i]["BORDA"].ToString();
                                rs.Litragem = dt.Rows[i]["LITRAGEM"].ToString();
                                rs.IdModalidade = Int32.Parse(dt.Rows[i]["IDMODALIDADE"].ToString());
                                rs.PranchaModalidade.Modalidade = dt.Rows[i]["MODALIDADE"].ToString();
                                rs.PranchaImagem.QuantidadeImagem = Int32.Parse(dt.Rows[i]["QUANTIDADEIMAGENS"].ToString());
                                rs.PranchaImagem.Imagem = dt.Rows[i]["CAPA"].ToString();
                                rs.IdTipoItem = Int32.Parse(dt.Rows[i]["IDTIPOITEM"].ToString());

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

        public bool find(Entidades.Prancha Obj)
        {

            bool TemRegistros;
            string sql = "USPPranchaDetalhes " + Obj.IdPrancha + " ";
            try
            {
                comando = new SqlCommand(sql, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                TemRegistros = reader.Read();
                if (TemRegistros)
                {


                    Obj.IdPrancha = Convert.ToInt64(reader[0].ToString());
                    Obj.NomePrancha = (reader[1].ToString());
                    Obj.Descricao = (reader[2].ToString());
                    Obj.Volume = (reader[3].ToString());
                    Obj.Polegadas = (reader[4].ToString());
                    Obj.Espessura = (reader[5].ToString());
                    Obj.IdFornecedor = Convert.ToInt64(reader[6].ToString());
                    Obj.Fornecedor.NomeFantasia = (reader[7].ToString());
                    Obj.Fornecedor.RazaoSocial = (reader[8].ToString());
                    Obj.Fornecedor.CNPJ = (reader[9].ToString());
                    Obj.Fornecedor.CodigoInterno = (reader[10].ToString());
                    if (!String.IsNullOrEmpty(reader[11].ToString()))
                    {
                        Obj.DataCadastro = DateTime.Parse(reader[11].ToString());
                    }
                    Obj.IdStatus = Convert.ToInt32(reader[12].ToString());
                    Obj.Status.NomeStatus = reader[13].ToString();
                    Obj.CodigoInterno = (reader[14].ToString());
                    Obj.IdMarca = Convert.ToInt32(reader[15].ToString());
                    Obj.PranchaMarca.Marca = (reader[16].ToString());
                    Obj.IdModelo = Convert.ToInt32(reader[17].ToString());
                    Obj.PranchaModelo.Modelo = (reader[18].ToString());
                    Obj.Tamanho = (reader[19].ToString());
                    Obj.Largura = (reader[20].ToString());
                    Obj.Borda = (reader[21].ToString());
                    Obj.Litragem = (reader[22].ToString());
                    Obj.IdModalidade = Convert.ToInt32(reader[23].ToString());
                    Obj.PranchaModalidade.Modalidade = (reader[24].ToString());
                    Obj.PranchaImagem.QuantidadeImagem = Convert.ToInt32(reader[25].ToString());
                    Obj.PranchaImagem.Imagem = (reader[26].ToString());
                    Obj.IdTipoItem = Convert.ToInt32(reader[27].ToString());

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

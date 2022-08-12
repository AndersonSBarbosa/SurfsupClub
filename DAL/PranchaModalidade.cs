using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class PranchaModalidade
    {

        #region Função Basica

        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PranchaModalidade()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.PranchaModalidade obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Entidades.PranchaModalidade obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.PranchaModalidade obj)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaModalidade> findAll()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaModalidade> ListarAllPranchaModalidadeAtivo()
        {
            Entidades.PranchaModalidade rs = new Entidades.PranchaModalidade();
            List<Entidades.PranchaModalidade> ListarAll = new List<Entidades.PranchaModalidade>();

            string Sql = "select * from TB_PRANCHA_MODALIDADE where IDSTATUS = 1";

            try
            {
                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Sql;

                        //conn.AddInParameter(cmd, "IDFILHO", DbType.Int32, IdFilho);
                        //conn.AddInParameter(cmd, "@IDUSUARIO", DbType.Int32, IdUsuario);

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                rs = new Entidades.PranchaModalidade();
                                rs.IdModalidade = Int32.Parse(dt.Rows[i]["IDMODALIDADE"].ToString());
                                rs.Modalidade = dt.Rows[i]["MODALIDADE"].ToString();
                                rs.IdStatus = Int32.Parse(dt.Rows[i]["IDSTATUS"].ToString());

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

        public void update(Entidades.PranchaModalidade obj)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

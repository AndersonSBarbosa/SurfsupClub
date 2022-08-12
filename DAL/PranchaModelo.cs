using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class PranchaModelo
    {

        #region Função Basica

        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PranchaModelo()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.PranchaModelo obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Entidades.PranchaModelo obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.PranchaModelo obj)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaModelo> findAll()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaModelo> ListarAllPranchaModeloAtivo()
        {
            Entidades.PranchaModelo rs = new Entidades.PranchaModelo();
            List<Entidades.PranchaModelo> ListarAll = new List<Entidades.PranchaModelo>();

            string Sql = "select * from TB_PRANCHA_MODELO where IDSTATUS = 1";

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
                                rs = new Entidades.PranchaModelo();
                                rs.IdModelo = Int32.Parse(dt.Rows[i]["IDMODELO"].ToString());
                                rs.Modelo = dt.Rows[i]["MODELO"].ToString();
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

        public void update(Entidades.PranchaModelo obj)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

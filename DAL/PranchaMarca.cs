using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class PranchaMarca
    {

        #region Função Basica

        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PranchaMarca()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.PranchaMarca obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Entidades.PranchaMarca obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.PranchaMarca obj)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaMarca> findAll()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.PranchaMarca> ListarAllPranchaMarcaAtivo()
        {
            Entidades.PranchaMarca rs = new Entidades.PranchaMarca();
            List<Entidades.PranchaMarca> ListarAll = new List<Entidades.PranchaMarca>();

            string Sql = "select * from TB_PRANCHA_MARCA where IDSTATUS = 1";

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
                                rs = new Entidades.PranchaMarca();
                                rs.IdMarca = Int32.Parse(dt.Rows[i]["IDMARCA"].ToString());
                                rs.Marca = dt.Rows[i]["MARCA"].ToString();
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

        public void update(Entidades.PranchaMarca obj)
        {
            throw new NotImplementedException();
        }

        #endregion

    }

}

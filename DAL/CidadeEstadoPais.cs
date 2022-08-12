using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class CidadeEstadoPais
    {

        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public CidadeEstadoPais()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.CidadeEstadoPais obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Entidades.CidadeEstadoPais obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Entidades.CidadeEstadoPais obj)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.CidadeEstadoPais> findAll()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.CidadeEstadoPais> ListarAllEstados()
        {
            Entidades.CidadeEstadoPais rs = new Entidades.CidadeEstadoPais();
            List<Entidades.CidadeEstadoPais> ListarAllEstados = new List<Entidades.CidadeEstadoPais>();

            string Sql = "select * from estado";

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
                                rs = new Entidades.CidadeEstadoPais();
                                rs.IdEstado = Int32.Parse(dt.Rows[i]["est_cod"].ToString());
                                rs.UF = dt.Rows[i]["est_sgl"].ToString();
                                rs.Estado = dt.Rows[i]["est_nome"].ToString();
                                rs.IdPais = Int32.Parse(dt.Rows[i]["pais_cod"].ToString());

                                ListarAllEstados.Add(rs);
                            }
                            return ListarAllEstados;
                        }
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void update(Entidades.CidadeEstadoPais obj)
        {
            throw new NotImplementedException();
        }

    }


}

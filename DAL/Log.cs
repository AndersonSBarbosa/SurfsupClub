using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;



namespace DAL
{
    public class Log 
    {
        public ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public Log()
        {
            objConexaoDB = ConexaoDB.SaberEstadoConexao();
        }

        public void create(Entidades.Log Obj)
        {

            try
            {
                string sql = @"USPLogAdd";


                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        conn.AddInParameter(cmd, "@IDCLIENTE", DbType.Int32, Obj.IdCliente);
                        conn.AddInParameter(cmd, "@IDFORNECEDOR", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDPRANCHA", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDRESERVA", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDPEDIDO", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IDATIVIDADE", DbType.Int32, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@IP", DbType.String, Obj.IdFornecedor);
                        conn.AddInParameter(cmd, "@OBS", DbType.String, Obj.OBS);
                        conn.AddInParameter(cmd, "@IDSTATUS", DbType.Int32, Obj.IdStatus);
                        conn.AddInParameter(cmd, "@CODINTERNO", DbType.Int32, Obj.OBS);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Entidades.Log Detalhes()
        {
            try
            {
                Entidades.Log rs = new Entidades.Log();

                string sql = @"USPRelatorioHOME";

                using (RaiCore.Data conn = new RaiCore.Data())
                {
                    conn.RaiConnection("SurfsUpClubConnection");

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;

                        //conn.AddInParameter(cmd, "@IDUsuario", DbType.Int32, Convert.ToInt32(Id));

                        using (DbDataAdapter adp = conn.CreateDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                rs.QuantidadePranchas = Int32.Parse(dt.Rows[0]["PRANCHAS"].ToString());
                                rs.QuantidadeLocacoes = Int32.Parse(dt.Rows[0]["LOCACOES"].ToString());
                                rs.QuantidadeLocacoesDevolvidas = Int32.Parse(dt.Rows[0]["DEVOLVIDAS"].ToString());
                                rs.QuantidadeLocacoesAtrasadas = Int32.Parse(dt.Rows[0]["LOCACOESATRASADAS"].ToString());
                                rs.QuantidadeDevolvidasAtrasadas = Int32.Parse(dt.Rows[0]["LOCACOESDEVOLVIDASATRASADAS"].ToString());
                                rs.QuantidadePranchasDisponiveis = Int32.Parse(dt.Rows[0]["PranchaDIsponiveis"].ToString());
                                rs.QuantidadeCliente = Int32.Parse(dt.Rows[0]["CLIENTES"].ToString());
                                rs.QuantidadeFornecedores = Int32.Parse(dt.Rows[0]["FORNECEDORES"].ToString());
                                rs.QuantidadePontoRetiradas = Int32.Parse(dt.Rows[0]["PONTOSRETIRADAS"].ToString());
                                rs.QuantidadePedidos = Int32.Parse(dt.Rows[0]["PEDIDOS"].ToString());

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

    }
}

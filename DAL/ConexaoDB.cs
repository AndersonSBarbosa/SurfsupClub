using System.Data.SqlClient;

namespace DAL
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;



        private ConexaoDB()
        {

            //< add name = "SurfsUpClubConnection" connectionString = "Initial Catalog=surfsupclub;Data Source=mssql04-farm68.kinghost.net;UID=surfsupclub;Pwd=x3LVCMuDrAtG2wd" providerName = "System.Data.SqlClient" /> 
            //con = new SqlConnection("Data Source=DESKTOP-RGNTS3F; Initial Catalog=SurfsUpClub; Integrated Security=True");
            con = new SqlConnection("Initial Catalog=surfsupclub;Data Source=mssql04-farm68.kinghost.net;UID=surfsupclub;Pwd=x3LVCMuDrAtG2wd");
            //con = new SqlConnection("Initial Catalog=surfsupclub;Data Source=mssql.surfsupclub.com;UID=surfsupclub;Pwd=x3LVCMuDrAtG2wd providerName=System.Data.SqlClient");

        }

        public static ConexaoDB SaberEstadoConexao()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;
        }


        public SqlConnection GetCon()
        {
            return con;
        }

        public void FecharDB()
        {
            objConexaoDB = null;
        }

    }
}

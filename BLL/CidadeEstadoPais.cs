using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class CidadeEstadoPais
    {
        private DAL.CidadeEstadoPais objCidadeEstadoPais;

        public CidadeEstadoPais()
        {
            objCidadeEstadoPais = new DAL.CidadeEstadoPais();
        }

        public List<Entidades.CidadeEstadoPais> ListarAllEstados()
        {
            return objCidadeEstadoPais.ListarAllEstados();
        }

    }
}

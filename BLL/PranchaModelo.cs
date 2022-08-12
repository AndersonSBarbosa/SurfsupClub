using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PranchaModelo
    {

        private DAL.PranchaModelo objPranchaModelo;

        public PranchaModelo()
        {
            objPranchaModelo = new DAL.PranchaModelo();
        }

        public List<Entidades.PranchaModelo> ListarAllPranchaModeloAtivo()
        {
            return objPranchaModelo.ListarAllPranchaModeloAtivo();
        }

    }
}

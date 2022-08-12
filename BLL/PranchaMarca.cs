using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PranchaMarca
    {

        private DAL.PranchaMarca objPranchaMarca;

        public PranchaMarca()
        {
            objPranchaMarca = new DAL.PranchaMarca();
        }

        public List<Entidades.PranchaMarca> ListarAllPranchaMarcaAtivo()
        {
            return objPranchaMarca.ListarAllPranchaMarcaAtivo();
        }

    }
}

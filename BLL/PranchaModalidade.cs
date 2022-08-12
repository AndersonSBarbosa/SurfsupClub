using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PranchaModalidade
    {

        private DAL.PranchaModalidade objPranchaModalidade;

        public PranchaModalidade()
        {
            objPranchaModalidade = new DAL.PranchaModalidade();
        }

        public List<Entidades.PranchaModalidade> ListarAllPranchaModalidadeAtivo()
        {
            return objPranchaModalidade.ListarAllPranchaModalidadeAtivo();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoItem
    {
        public Int32 IdItem { get; set; }
        public String NomeItem { get; set; }
        public List<TipoItem> ListaItens()
        {
            return new List<TipoItem>

            {
                new TipoItem { IdItem = 1, NomeItem = "Prancha"},

                new TipoItem { IdItem = 2, NomeItem = "Cordas"},

               new TipoItem { IdItem = 3, NomeItem = "Quilhas"}
            };

        }
    }

}

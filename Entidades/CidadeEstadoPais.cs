using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class CidadeEstadoPais
    {
        public long IdCidade { get; set; }
        public long IdEstado { get; set; }
        public long IdPais { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String UF { get; set; }
        public String Pais { get; set; }
    }
}

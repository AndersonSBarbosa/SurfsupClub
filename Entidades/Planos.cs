using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Planos
    {

        public Planos()
        {
            this.Status = new Status();
        }

        public long IdPlano { get; set; }
        public String Plano { get; set; }
        public Decimal Valor { get; set; }
        public Int32 Dias { get; set; }
        public Boolean Mensal { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Int32 Resposta { get; set; }
    }
}

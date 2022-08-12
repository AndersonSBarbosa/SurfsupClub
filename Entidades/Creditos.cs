using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Creditos
    {
        public Creditos()
        {
            this.Status = new Status();
            this.Cliente = new Cliente();
        }
        public long IdCredito { get; set; }
        public long IdCliente { get; set; }
        public Int32 Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Cliente Cliente { get; set; }
        public Int32 Resposta { get; set; }
        public String CodigoInterno { get; set; }
    }
}

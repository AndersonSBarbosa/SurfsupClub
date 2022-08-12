using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            this.Status = new Status();
            this.Cliente = new Cliente();
        }
        public long IdPedido { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Cliente Cliente { get; set; }
        public Int32 Resposta { get; set; }
        public String CodigoInterno { get; set; }
    }
}

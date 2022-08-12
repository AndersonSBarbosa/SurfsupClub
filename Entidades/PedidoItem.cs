using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoItem
    {
        public PedidoItem()
        {
            this.Status = new Status();
            this.Planos = new Planos();
            this.Pedido = new Pedido();
        }
        public long IdItem { get; set; }
        public long IdPedido { get; set; }
        public long IdPlano { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Planos Planos { get; set; }
        public Pedido Pedido { get; set; }
        public Int32 Resposta { get; set; }
    }
}

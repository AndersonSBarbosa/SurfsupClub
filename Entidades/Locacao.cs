using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Locacao
    {

        public Locacao()
        {
            this.Status = new Status();
            this.Cliente = new Cliente();
            this.Prancha = new Prancha();
            this.Planos = new Planos();
            this.Fornecedor = new Fornecedor();
        }

        public long IdLocacao { get; set; }
        public long IdPrancha { get; set; }
        public long IdCliente { get; set; }
        public long IdPlano { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Cliente Cliente { get; set; }
        public Prancha Prancha { get; set; }
        public Planos Planos { get; set; }
        public Int32 IdPontoRetirada { get; set; }
        public Int32 IdPontoEntrega { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Int32 Resposta { get; set; }
        public String CodigoInterno { get; set; }
        public Usuario Usuario { get; set; }
        public Int32 IdusuarioRetirada { get; set; }
        public Int32 IdusuarioEntrega { get; set; }
        public DateTime DataRetiradaPranchaLocal { get; set; }

    }
}

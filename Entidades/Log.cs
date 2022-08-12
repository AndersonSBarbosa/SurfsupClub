using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Log
    {
        public Log()
        {
            this.Status = new Status();
        }
        public long IDLog { get; set; }
        public Int32 IdCliente{ get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdPrancha { get; set; }
        public Int32 IdFornecedor { get; set; }
        public Int32 IdReserva { get; set; }
        public Int32 IdPedido { get; set; }
        public Int32 IdAtividade { get; set; }
        public String IP { get; set; }
        public String OBS { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Int32 Resposta { get; set; }
        public Int32 QuantidadePranchas { get; set; }
        public Int32 QuantidadeLocacoes { get; set; }
        public Int32 QuantidadeLocacoesAtrasadas { get; set; }
        public Int32 QuantidadeDevolvidasAtrasadas { get; set; }
        public Int32 QuantidadeLocacoesDevolvidas { get; set; }
        public Int32 QuantidadePranchasDisponiveis { get; set; }
        public Int32 QuantidadeCliente { get; set; }
        public Int32 QuantidadeFornecedores { get; set; }
        public Int32 QuantidadePontoRetiradas { get; set; }
        public Int32 QuantidadePedidos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class PranchaImagem
    {
        public PranchaImagem()
        {
            this.Status = new Status();
        }

        public long IdImagem { get; set; }
        public Int32 IdPrancha { get; set; }
        public String Imagem { get; set; }
        public String Img { get; set; }
        public String Caminho { get; set; }
        public Boolean Capa { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Int32 QuantidadeImagem { get; set; }
        public Int32 Resposta { get; set; }
    }
}

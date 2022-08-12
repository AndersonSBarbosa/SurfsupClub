using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
     public class Prancha
    {
        public Prancha()
        {
            this.Status = new Status();
            this.Fornecedor = new Fornecedor();
            this.PranchaMarca = new PranchaMarca();
            this.PranchaModelo = new PranchaModelo();
            this.PranchaModalidade = new PranchaModalidade();
            this.PranchaImagem = new PranchaImagem();
        }

        public long IdPrancha { get; set; }
        public String NomePrancha { get; set; }
        public String Descricao { get; set; }
        public String Volume { get; set; }
        public String Polegadas { get; set; }
        public String Espessura { get; set; }
        public String Tamanho { get; set; }
        public String Largura { get; set; }
        public String Borda { get; set; }
        public String Litragem { get; set; }
        [Display(Name = "Fornecedor")]
        public long IdFornecedor { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Fornecedor Fornecedor { get; set; }
        [Display(Name = "Modalidade")]
        public Int32 IdModalidade { get; set; }
        public PranchaModalidade PranchaModalidade { get; set; }
        [Display(Name = "Modelo")]
        public Int32 IdModelo { get; set; }
        public PranchaModelo PranchaModelo { get; set; }
        [Display(Name = "Marca")]
        public Int32 IdMarca { get; set; }
        public PranchaMarca PranchaMarca { get; set; }
        public PranchaImagem PranchaImagem { get; set; }
        public Int32 Resposta { get; set; }
        public String CodigoInterno { get; set; }
        [Display(Name = "Tipo Item")]
        public Int32 IdTipoItem { get; set; }
    }
}

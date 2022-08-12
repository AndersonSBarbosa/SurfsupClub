using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fornecedor
    {
        public Fornecedor()
        {
            this.Status = new Status();
            this.Usuario = new Usuario();

        }

        [Display(Name = "Código Fornecedor")]
        public long IdFornecedor { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public String NomeFantasia { get; set; }


        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public String RazaoSocial { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public String Email { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public String CNPJ { get; set; }
        public String IE { get; set; }
        public String Endereco { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String CEP { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Int32 Resposta { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String CodigoInterno { get; set; }
        public String Telefone1 { get; set; }
        public String Telefone2 { get; set; }
        public String Telefone3 { get; set; }
        public String Telefone4 { get; set; }
        public Boolean PontoEntregaRetirada { get; set; }
        public Usuario Usuario { get; set; }
        public Boolean Fabricante { get; set; }

    }
}

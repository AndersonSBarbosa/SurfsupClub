using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {

        public Cliente()
        {
            this.Status = new Status();
        }

        [Display(Name = "Código Cliente")]
        public long IdCliente { get; set; }
        [Required(ErrorMessage = "Você precisa entrar com o Nome")]
        [StringLength(30, ErrorMessage = "Insira um nome de 1 a 30 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Você precisa entrar com o Sobrenome")]
        public String Sobrenome { get; set; }
        public String IdFacebook { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Você precisa entrar com o E-mail")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public String CPF { get; set; }
        public String RG { get; set; }
        public String Altura { get; set; }
        public String Peso { get; set; }

        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "Você precisa entrar com a Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereço")]
        public String Endereco { get; set; }
        [Display(Name = "Número")]
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }

        public String CEP { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status  { get; set; }
        public Int32 Resposta { get; set; }
        public String Sexo { get; set; }
        [Display(Name = "Codigo")]
        public String CodigoInterno { get; set; }

        public String DDD1 { get; set; }
        public String DDD2 { get; set; }
        public String DDD3 { get; set; }
        public String DDD4 { get; set; }

        public String Telefone1 { get; set; }
        public String Telefone2 { get; set; }
        public String Telefone3 { get; set; }
        public String Telefone4 { get; set; }
        public String Senha { get; set; }
        public String Assunto { get; set; }
        public String Mensagem { get; set; }

    }

    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PontoRetirada
    {
        public PontoRetirada()
        {
            this.Status = new Status();
        }
        public long IdPontoRetidada { get; set; }
        public String NomeFantasia { get; set; }
        public String RazaoSocial { get; set; }
        public String Email { get; set; }
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
        public Int32 IdTipo { get; set; }

    }
}

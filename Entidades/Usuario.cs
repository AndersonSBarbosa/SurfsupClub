using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            this.Status = new Status();
        }
        public long IdUsuario { get; set; }
        public String Nome { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }

        [Display(Name = "Nivel")]
        public Int32 IdNivel { get; set; }
        public DateTime DataCadastro { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
        public Int32 Resposta { get; set; }
        public String Lista { get; set; }
    }
}

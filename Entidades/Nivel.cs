using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nivel
    {
        public Int32 IdNivel { get; set; }
        public String NomeNivel { get; set; }
        public List<Nivel> ListaNiveis()
        {

            return new List<Nivel>

            {
                new Nivel { IdNivel = 1, NomeNivel = "Administração"},

                new Nivel { IdNivel = 2, NomeNivel = "Gerente"},

               new Nivel { IdNivel = 3, NomeNivel = "Ponto Retirada"}
            };

        }
    }

}

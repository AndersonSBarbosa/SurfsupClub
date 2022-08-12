using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sexo
    {

        public String IdSexo { get; set; }
        public String NomeSexo { get; set; }
        public List<Sexo> ListarSexo()
        {
            return new List<Sexo>

            {
                new Sexo { IdSexo = "M", NomeSexo = "Masculino"},

                new Sexo { IdSexo = "F", NomeSexo = "Feminino"},

            };

        }

    }
}

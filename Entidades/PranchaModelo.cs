using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PranchaModelo
    {
        public PranchaModelo()
        {
            this.Status = new Status();
        }
        public long IdModelo { get; set; }
        public String Modelo { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
    }
}

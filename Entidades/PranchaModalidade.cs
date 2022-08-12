using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PranchaModalidade
    {
        public PranchaModalidade()
        {
            this.Status = new Status();
        }
        public long IdModalidade { get; set; }
        public String Modalidade { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
    }
}

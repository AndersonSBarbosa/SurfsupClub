using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PranchaMarca
    {
        public PranchaMarca()
        {
            this.Status = new Status();
        }
        public long IdMarca { get; set; }
        public String Marca { get; set; }
        public Int32 IdStatus { get; set; }
        public Status Status { get; set; }
    }
}

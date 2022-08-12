using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MailModel
    {
        public String From { get; set; }
        public String To { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
    }
}

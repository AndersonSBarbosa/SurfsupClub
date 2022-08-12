using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class Log
    {
        private DAL.Log objLog;

        public Log()
        {
            objLog = new DAL.Log();
        }


        public Entidades.Log Detalhes()
        {
            try
            {
                DAL.Log rs = new DAL.Log();
                return rs.Detalhes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void create(Entidades.Log Obj)
        {
            objLog.create(Obj);
            return;
        }

        //public List<Entidades.Log> Buscar(Entidades.Log Obj)
        //{
        //    //return objLog.Buscar(Obj);
        //}

    }
}

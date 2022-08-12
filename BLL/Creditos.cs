using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Creditos
    {
        private DAL.Creditos objCreditos;

        public Creditos()
        {
            objCreditos = new DAL.Creditos();
        }


        public List<Entidades.Creditos> findAll()
        {
            return objCreditos.findAll();
        }

        public void create(Entidades.Creditos Obj)
        {
            Obj.IdCredito = 0;
            objCreditos.create(Obj);
            return;
        }

        //public bool find(Entidades.Creditos Obj)
        //{
        //    return objCreditos.find(Obj);
        //}
        //public Entidades.Creditos CreditosDetalhes(long IdCredito)
        //{
        //    try
        //    {
        //        DAL.Fornecedor rs = new DAL.Fornecedor();
        //        return rs.CreditosDetalhes(IdCredito);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void update(Entidades.Creditos Obj)
        {
            Obj.Resposta = 3;
            objCreditos.update(Obj);
            return;
        }

        public List<Entidades.Creditos> Buscar(Entidades.Creditos Obj)
        {
            return objCreditos.Buscar(Obj);
        }



    }
}

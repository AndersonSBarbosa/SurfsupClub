using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Planos
    {
        private DAL.Planos objPlanos;

        public Planos()
        {
            objPlanos = new DAL.Planos();
        }


        #region Funções Básicas
        public List<Entidades.Planos> findAll()
        {
            return objPlanos.findAll();
        }

        public void create(Entidades.Planos Obj)
        {
            Obj.Resposta = 0;
            Obj.IdPlano = 0;
            objPlanos.create(Obj);
            return;
        }

        public Entidades.Planos Detalhes(long Id)
        {
            try
            {
                DAL.Planos rs = new DAL.Planos();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Planos Obj)
        {
            Obj.Resposta = 3;
            objPlanos.update(Obj);
            return;
        }

        public List<Entidades.Planos> Buscar(Entidades.Planos Obj)
        {
            return objPlanos.Buscar(Obj);
        }

        public bool find(Entidades.Planos Obj)
        {
            return objPlanos.find(Obj);
        }

        #endregion




    }
}

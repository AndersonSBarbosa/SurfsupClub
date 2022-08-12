using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Prancha
    {
        private DAL.Prancha objPrancha;

        public Prancha()
        {
            objPrancha = new DAL.Prancha();
        }


        #region Funções Básicas
        public List<Entidades.Prancha> findAll()
        {
            return objPrancha.findAll();
        }

        public List<Entidades.Prancha> findAllPranchasAtivas()
        {
            return objPrancha.findAllPranchasAtivas();
        }


        public List<Entidades.Prancha> ListarPranchaFornecedor(long id)
        {
            return objPrancha.ListarPranchaFornecedor(id);
        }

        public void create(Entidades.Prancha Obj)
        {
            Obj.Resposta = 0;
            Obj.IdPrancha = 0;
            objPrancha.create(Obj);
            return;
        }

        public Entidades.Prancha Detalhes(long Id)
        {
            try
            {
                DAL.Prancha rs = new DAL.Prancha();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Prancha Obj)
        {
            Obj.Resposta = 3;
            objPrancha.update(Obj);
            return;
        }

        public List<Entidades.Prancha> Buscar(Entidades.Prancha Obj)
        {
            return objPrancha.Buscar(Obj);
        }

        public bool find(Entidades.Prancha Obj)
        {
            return objPrancha.find(Obj);
        }

        #endregion


    }

}

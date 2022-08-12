using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PontoRetirada
    {
        private DAL.PontoRetirada objPontoRetirada;

        public PontoRetirada()
        {
            objPontoRetirada = new DAL.PontoRetirada();
        }


        #region Funções Básicas
        public List<Entidades.PontoRetirada> findAll()
        {
            return objPontoRetirada.findAll();
        }

        public void create(Entidades.PontoRetirada Obj)
        {
            Obj.Resposta = 0;
            Obj.IdPontoRetidada = 0;
            objPontoRetirada.create(Obj);
            return;
        }

        public Entidades.PontoRetirada Detalhes(long Id)
        {
            try
            {
                DAL.PontoRetirada rs = new DAL.PontoRetirada();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.PontoRetirada Obj)
        {
            Obj.Resposta = 3;
            objPontoRetirada.update(Obj);
            return;
        }

        public List<Entidades.PontoRetirada> Buscar(Entidades.PontoRetirada Obj)
        {
            return objPontoRetirada.Buscar(Obj);
        }

        public bool find(Entidades.PontoRetirada Obj)
        {
            return objPontoRetirada.find(Obj);
        }

        #endregion


    }
}

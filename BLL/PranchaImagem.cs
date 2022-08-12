using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PranchaImagem
    {
        private DAL.PranchaImagem objPranchaImagem;

        public PranchaImagem()
        {
            objPranchaImagem = new DAL.PranchaImagem();
        }

        public void delete(Entidades.PranchaImagem obj)
        {
            objPranchaImagem.delete(obj);
            return;
        }

        #region Funções Básicas
        public List<Entidades.PranchaImagem> findAll()
        {
            return objPranchaImagem.findAll();
        }

        public List<Entidades.PranchaImagem> ListarPranchaImagem(long id)
        {
            return objPranchaImagem.ListarPranchaImagem(id);
        }

        public void create(Entidades.PranchaImagem Obj)
        {
            //Obj.IdPrancha = Convert.ToInt32(id);
            Obj.Resposta = 0;
            Obj.IdImagem = 0;
            objPranchaImagem.create(Obj);
            return;
        }

        public Entidades.PranchaImagem Detalhes(long Id)
        {
            try
            {
                DAL.PranchaImagem rs = new DAL.PranchaImagem();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.PranchaImagem Obj)
        {
            Obj.Resposta = 3;
            objPranchaImagem.update(Obj);
            return;
        }

        public List<Entidades.PranchaImagem> Buscar(Entidades.PranchaImagem Obj)
        {
            return objPranchaImagem.Buscar(Obj);
        }

        public bool find(Entidades.PranchaImagem Obj)
        {
            return objPranchaImagem.find(Obj);
        }

        #endregion


    }

}

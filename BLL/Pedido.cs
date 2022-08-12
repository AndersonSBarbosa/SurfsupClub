using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Pedido
    {

        private DAL.Pedido objPedido;

        public Pedido()
        {
            objPedido = new DAL.Pedido();
        }


        #region Funções Básicas
        public List<Entidades.Pedido> findAll()
        {
            return objPedido.findAll();
        }

        public void create(Entidades.Pedido Obj)
        {
            Obj.Resposta = 0;
            Obj.IdPedido = 0;
            objPedido.create(Obj);
            return;
        }

        public Entidades.Pedido Detalhes(long Id)
        {
            try
            {
                DAL.Pedido rs = new DAL.Pedido();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Pedido Obj)
        {
            Obj.Resposta = 3;
            objPedido.update(Obj);
            return;
        }

        public List<Entidades.Pedido> Buscar(Entidades.Pedido Obj)
        {
            return objPedido.Buscar(Obj);
        }

        public bool find(Entidades.Pedido Obj)
        {
            return objPedido.find(Obj);
        }

        #endregion

    }
}

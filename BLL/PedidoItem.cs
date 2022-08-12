using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Data.Common;

namespace BLL
{
    public class PedidoItem
    {
        private DAL.PedidoItem objPedidoItem;

        public PedidoItem()
        {
            objPedidoItem = new DAL.PedidoItem();
        }


        #region Funções Básicas
        public List<Entidades.PedidoItem> findAll()
        {
            return objPedidoItem.findAll();
        }

        public void create(Entidades.PedidoItem Obj)
        {
            Obj.Resposta = 0;
            Obj.IdItem = 0;
            Obj.IdPedido = 0;
            objPedidoItem.create(Obj);
            return;
        }

        public Entidades.PedidoItem Detalhes(long Id)
        {
            try
            {
                DAL.PedidoItem rs = new DAL.PedidoItem();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.PedidoItem Obj)
        {
            Obj.Resposta = 3;
            objPedidoItem.update(Obj);
            return;
        }

        public List<Entidades.PedidoItem> Buscar(Entidades.PedidoItem Obj)
        {
            return objPedidoItem.Buscar(Obj);
        }

        public bool find(Entidades.PedidoItem Obj)
        {
            return objPedidoItem.find(Obj);
        }

        #endregion



    }
}

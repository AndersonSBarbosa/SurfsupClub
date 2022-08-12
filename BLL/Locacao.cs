using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Locacao
    {
        private DAL.Locacao objLocacao;

        public Locacao()
        {
            objLocacao = new DAL.Locacao();
        }

        #region Funções Básicas
        public List<Entidades.Locacao> findAll()
        {
            return objLocacao.findAll();
        }

        public List<Entidades.Locacao> ListarLocacoesRetiradaEntrega(Int32 IdUsuario)
        {
            return objLocacao.ListarLocacoesRetiradaEntrega(IdUsuario);
        }

        public void create(Entidades.Locacao Obj)
        {
            Obj.Resposta = 0;
            Obj.IdLocacao = 0;
            objLocacao.create(Obj);
            return;
        }

        public Entidades.Locacao Detalhes(long Id)
        {
            try
            {
                DAL.Locacao rs = new DAL.Locacao();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Locacao Obj)
        {
            Obj.Resposta = 3;
            objLocacao.update(Obj);
            return;
        }

        public void updateGravarLogEntregaPrancha(Entidades.Locacao Obj)
        {
            Obj.Resposta = 3;
            objLocacao.updateGravarLogEntregaPrancha(Obj);
            return;
        }

        public void updateGravarLogRetiradaPrancha(Entidades.Locacao Obj)
        {
            Obj.Resposta = 3;
            objLocacao.updateGravarLogRetiradaPrancha(Obj);
            return;
        }

        public List<Entidades.Locacao> Buscar(Entidades.Locacao Obj)
        {
            return objLocacao.Buscar(Obj);
        }

        public bool find(Entidades.Locacao Obj)
        {
            return objLocacao.find(Obj);
        }

        #endregion

    }
}

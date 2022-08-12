using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Usuario
    {
        private DAL.Usuario objUsuario;

        public Usuario()
        {
            objUsuario = new DAL.Usuario();
        }

        #region Funções Básicas
        public List<Entidades.Usuario> findAll()
        {
            return objUsuario.findAll();
        }

        public void create(Entidades.Usuario Obj)
        {
            Obj.Resposta = 0;
            Obj.IdUsuario = 0;
            objUsuario.create(Obj);
            return;
        }

        public Entidades.Usuario Detalhes(long Id)
        {
            try
            {
                DAL.Usuario rs = new DAL.Usuario();
                return rs.Detalhes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Usuario Obj)
        {
            Obj.Resposta = 3;
            objUsuario.update(Obj);
            return;
        }

        public List<Entidades.Usuario> Buscar(Entidades.Usuario Obj)
        {
            return objUsuario.Buscar(Obj);
        }

        public bool find(Entidades.Usuario Obj)
        {
            return objUsuario.find(Obj);
        }

        #endregion

        public Entidades.Usuario Logar(Entidades.Usuario Obj)
        {
            try
            {
                DAL.Usuario rs = new DAL.Usuario();
                return rs.Logar(Obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

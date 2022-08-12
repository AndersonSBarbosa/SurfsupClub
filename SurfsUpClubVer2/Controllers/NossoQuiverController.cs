using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using System;


namespace SurfsUpClubVer2.Controllers
{
    public class NossoQuiverController : Controller
    {
        BLL.Prancha ObjPranchaBLL;
        BLL.Fornecedor ObjFornecedorBLL;
        BLL.PranchaImagem ObjPranchaImagemBLL;

        public NossoQuiverController()
        {
            ObjPranchaBLL = new BLL.Prancha();
            ObjFornecedorBLL = new BLL.Fornecedor();
            ObjPranchaImagemBLL = new BLL.PranchaImagem();
        }

        #region Funções Basicas
        // GET: NossoQuiver
        public ActionResult Index()
        {
            List<Entidades.Prancha> Listar = ObjPranchaBLL.findAllPranchasAtivas();
            return View(Listar);
        }


        // POST: Prancha/updade
        [HttpGet]
        public ActionResult Prancha(long id)
        {
                List<Entidades.PranchaImagem> Listar = ObjPranchaImagemBLL.ListarPranchaImagem(id);
                ViewBag.ImagensPrancha = Listar;

                //mensagemInicioRegistrar();
                Prancha Obj = new Prancha();
                Obj.IdPrancha = id;
                ObjPranchaBLL.find(Obj);
                return View(Obj);
        }

        [HttpPost]
        public ActionResult Atualizar(Prancha Obj)
        {
                Obj.IdStatus = 1;
                ObjPranchaBLL.update(Obj);
                return View(Obj);
        }

        #endregion
    }
}
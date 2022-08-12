using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace SurfsUpClubVer2.Controllers
{
    public class PlanosController : Controller
    {
        BLL.Planos ObjPlanosBLL;

        public PlanosController()
        {
            ObjPlanosBLL = new BLL.Planos();
        }

        // GET: Planos
        public ActionResult Index()
        {
            List<Entidades.Planos> Listar = ObjPlanosBLL.findAll();
            return View(Listar);
        }
    }
}
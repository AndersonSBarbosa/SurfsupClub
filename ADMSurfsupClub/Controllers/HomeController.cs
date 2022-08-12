using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using ADMSurfsupClub.Models;
using System.Linq;

namespace ADMSurfsupClub.Controllers
{
    public class HomeController : Controller
    {
        BLL.Usuario ObjUsuarioBLL;
        BLL.Log ObjLogBLL;
        public HomeController()
        {
            ObjUsuarioBLL = new BLL.Usuario();
            ObjLogBLL = new BLL.Log();
        }

        public ActionResult Sair()
        {
            Session["usuarioLogadoID"] = null;
            Session["nomeUsuarioLogado"] = null;
            Session["nivelUsuarioLogado"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                Log Obj = new Log();
                Obj = ObjLogBLL.Detalhes();


                ViewBag.QuantidadePranchas = Obj.QuantidadePranchas;
                ViewBag.QuantidadeLocacoes = Obj.QuantidadeLocacoes;
                ViewBag.QuantidadeLocacoesDevolvidas = Obj.QuantidadeLocacoesDevolvidas;
                ViewBag.QuantidadeLocacoesAtrasadas = Obj.QuantidadeLocacoesAtrasadas;
                ViewBag.QuantidadeDevolvidasAtrasadas = Obj.QuantidadeDevolvidasAtrasadas;
                ViewBag.QuantidadePranchasDisponiveis = Obj.QuantidadePranchasDisponiveis;
                ViewBag.QuantidadeCliente = Obj.QuantidadeCliente;
                ViewBag.QuantidadeFornecedores = Obj.QuantidadeFornecedores;
                ViewBag.QuantidadePontoRetiradas = Obj.QuantidadePontoRetiradas;
                ViewBag.QuantidadePedidos = Obj.QuantidadePedidos;

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                //Entidades.Usuario user = new Entidades.Usuario();
                Usuario Obj = new Usuario();
                Obj.Login = u.Login;
                Obj.Senha = u.Senha;
                Obj = ObjUsuarioBLL.Logar(Obj);
                    if (Obj.IdUsuario != 0 )
                    {
                        Session["usuarioLogadoID"] = Obj.IdUsuario.ToString();
                        Session["nomeUsuarioLogado"] = Obj.Nome.ToString();
                        Session["nivelUsuarioLogado"] = Obj.IdNivel.ToString();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
            }
            return View(u);
        }


    }
}
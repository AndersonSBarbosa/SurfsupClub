using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;

/// <summary>
/// OK
/// </summary>

namespace ADMSurfsupClub.Controllers
{
    //[Authorize]
    public class PlanosController : Controller
    {
        BLL.Planos ObjPlanosBLL;

        public PlanosController()
        {
            ObjPlanosBLL = new BLL.Planos();
        }

        #region Funções Basicas

        // GET: Planos
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Planos> Listar = ObjPlanosBLL.findAll();
                return View(Listar);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Planos/Create
        [HttpGet]
        public ActionResult Cadastro()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Planos/Create
        [HttpPost]
        public ActionResult Cadastro(Planos Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjPlanosBLL.create(Obj);
                MensagemErroRegistrar(Obj);
                ModelState.Clear();
                return View("Cadastro");
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        //mensagem de erro
        public void MensagemErroRegistrar(Planos Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.IdPlano + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.IdPlano + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.IdPlano + "] foi Atualizado no sistema";
                    break;
                //////////////////////////
                #endregion

                case 4://campo nome vazio
                    ViewBag.MensagemErro = "Campo Obrigatório";
                    break;
                case 5://Registro Encontrado
                    ViewBag.MensagemExito = "Registro Encontrado no sistema";
                    break;
                case 6://Registro Não Encontrado
                    ViewBag.MensagemExito = "Registro não Encontrado no sistema";
                    break;

                case 250://erro de Quantidade de Caracteres
                    ViewBag.MensagemErro = "O nome não pode ter mais de XX caracteres";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Fornecedor e clique em salvar";
        }


        // POST: Planos/updade
        [HttpGet]
        public ActionResult Atualizar(long id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Planos Obj = new Planos();
                Obj.IdPlano = id;
                ObjPlanosBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Atualizar(Planos Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjPlanosBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Planos/Buscar
        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Planos> lista = ObjPlanosBLL.findAll();
                return View(lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        [HttpPost]
        public ActionResult Busca(string txtBuscar)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                if (txtBuscar == "")
                {
                    txtBuscar = "-1";
                }

                Planos Obj = new Planos();
                Obj.Plano = txtBuscar;

                List<Planos> Lista = ObjPlanosBLL.Buscar(Obj);
                return View(Lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }



        }

        #endregion
    }
}
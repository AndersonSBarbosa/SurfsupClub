using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using System;

namespace ADMSurfsupClub.Controllers
{
    public class LocacaoController : Controller
    {
       // //[Authorize]
        BLL.Locacao ObjLocacaoBLL;

        public LocacaoController()
        {
            ObjLocacaoBLL = new BLL.Locacao();
        }

        #region Funções Basicas

        // GET: Locação
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                if(Session["nivelUsuarioLogado"].ToString() == "1")
                {
                    List<Entidades.Locacao> Listar = ObjLocacaoBLL.findAll();
                    return View(Listar);
                }
                else if(Session["nivelUsuarioLogado"].ToString() == "2")
                {

                    List<Entidades.Locacao> Listar = ObjLocacaoBLL.ListarLocacoesRetiradaEntrega(Convert.ToInt32(Session["usuarioLogadoID"].ToString()));
                    return View(Listar);
                }
                else if (Session["nivelUsuarioLogado"].ToString() == "3")
                {
                    List<Entidades.Locacao> Listar = ObjLocacaoBLL.findAll();
                    return View(Listar);
                }

                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Locação/Create
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

        // POST: Locação/Create
        [HttpPost]
        public ActionResult Cadastro(Locacao Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjLocacaoBLL.create(Obj);
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
        public void MensagemErroRegistrar(Locacao Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.IdLocacao + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.IdLocacao + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.IdLocacao + "] foi Atualizado no sistema";
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
            ViewBag.MensagemInicio = "";
        }


        // POST: Locação/updade
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
                Locacao Obj = new Locacao();
                Obj.IdLocacao = id;
                ObjLocacaoBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Atualizar(Locacao Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjLocacaoBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Entrega/updade
        [HttpGet]
        public ActionResult Entrega(long id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Locacao Obj = new Locacao();
                Obj.IdLocacao = id;
                ObjLocacaoBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Entrega(Locacao Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;
                mensagemInicioRegistrar();
                Obj.IdusuarioEntrega = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
                Obj.IdPontoEntrega = 0;
                Obj.IdStatus = 1;
                ObjLocacaoBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Retirada/updade
        [HttpGet]
        public ActionResult Retirada(long id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Locacao Obj = new Locacao();
                Obj.IdLocacao = id;
                ObjLocacaoBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Retirada(Locacao Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;



                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                Obj.IdPontoRetirada = 0;
                Obj.IdusuarioRetirada = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
                ObjLocacaoBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Locação/Buscar
        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Locacao> lista = ObjLocacaoBLL.findAll();
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

                Locacao Obj = new Locacao();
                Obj.Cliente.Nome = txtBuscar;
                Obj.Cliente.CPF = txtBuscar;
                Obj.CodigoInterno = txtBuscar;

                List<Locacao> Lista = ObjLocacaoBLL.Buscar(Obj);
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
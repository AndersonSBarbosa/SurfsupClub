using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;

namespace ADMSurfsupClub.Controllers
{
    //[Authorize]
    public class PedidosController : Controller
    {
        BLL.Pedido ObjPedidoBLL;

        public PedidosController()
        {
            ObjPedidoBLL = new BLL.Pedido();
        }

        #region Funções Basicas

        // GET: Pedidos
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Pedido> Listar = ObjPedidoBLL.findAll();
                return View(Listar);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Pedidos/Create
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

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Cadastro(Pedido Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjPedidoBLL.create(Obj);
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
        public void MensagemErroRegistrar(Pedido Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.IdPedido + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.IdPedido + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.IdPedido + "] foi Atualizado no sistema";
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


        // POST: Pedidos/updade
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
                Pedido Obj = new Pedido();
                Obj.IdPedido = id;
                ObjPedidoBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Atualizar(Pedido Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjPedidoBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Pedidos/Buscar
        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Pedido> lista = ObjPedidoBLL.findAll();
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

                    Pedido Obj = new Pedido();
                    Obj.Cliente.Nome = txtBuscar;
                    Obj.Cliente.CPF = txtBuscar;
                    Obj.CodigoInterno = txtBuscar;

                    List<Pedido> Lista = ObjPedidoBLL.Buscar(Obj);
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
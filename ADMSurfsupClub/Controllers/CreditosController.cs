using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/// <summary>
///  OK
/// </summary>

namespace ADMSurfsupClub.Controllers
{
    //[Authorize]
    public class CreditosController : Controller
    {
        BLL.Creditos ObjCreditosBLL;

        public CreditosController()
        {
            ObjCreditosBLL = new BLL.Creditos();
        }

        // GET: Creditos
        public ActionResult Index()
        {

            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Creditos> Listar = ObjCreditosBLL.findAll();
                return View(Listar);
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }

        // GET: Creditos/Create
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

        // POST: Creditos/Create
        [HttpPost]
        public ActionResult Cadastro(Creditos Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjCreditosBLL.create(Obj);
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
        public void MensagemErroRegistrar(Creditos Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.IdCredito + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.IdCredito + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.IdCredito + "] foi Atualizado no sistema";
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

        // POST: Creditos/updade
        //[HttpGet]
        //public ActionResult Atualizar(long id)
        //{

        //    BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
        //    List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
        //    SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
        //    ViewBag.ListarAllEstados = ListarEstados;

        //    mensagemInicioRegistrar();
        //    Creditos Obj = new Creditos();
        //    Obj.IdCredito = id;
        //    ObjCreditosBLL.find(Obj);
        //    return View(Obj);
        //}
        //[HttpPost]
        //public ActionResult Atualizar(Creditos Obj)
        //{

        //    BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
        //    List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
        //    SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
        //    ViewBag.ListarAllEstados = ListarEstados;

        //    mensagemInicioRegistrar();
        //    Obj.IdStatus = 1;
        //    ObjCreditosBLL.update(Obj);
        //    MensagemErroRegistrar(Obj);
        //    return View();
        //}

        // POST: Creditos/Buscar

        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Creditos> lista = ObjCreditosBLL.findAll();
                return View(lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        [HttpPost]
        public ActionResult Busca(string txtNome, string txtCNPJCPF, string txtCodInterno)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                    if (txtNome == "")
                    {
                        txtNome = "-1";
                    }

                    if (txtCNPJCPF == "")
                    {
                        txtCNPJCPF = "-1";
                    }

                    if (txtCodInterno == "")
                    {
                        txtCodInterno = "-1";
                    }

                    Creditos Obj = new Creditos();
                    Obj.Cliente.Nome = txtNome;
                    Obj.Cliente.CPF = txtCNPJCPF;
                    Obj.CodigoInterno = txtCodInterno;

                    List<Creditos> Lista = ObjCreditosBLL.Buscar(Obj);
                    return View(Lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }

           

        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
/// <summary>
/// OK
/// </summary>
namespace ADMSurfsupClub.Controllers
{
    public class FornecedorController : Controller
    {
        ////[Authorize]
        BLL.Fornecedor ObjFornecedorBLL;
        BLL.Prancha ObjPranchaBLL;
        // GET: Fornecedor

        public FornecedorController()
        {
            ObjFornecedorBLL = new BLL.Fornecedor();
            ObjPranchaBLL = new BLL.Prancha();
        }

        public ActionResult Index()
        {

            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Fornecedor> ListaFornecedores = ObjFornecedorBLL.findAll();
                return View(ListaFornecedores);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Fornecedor/Create
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

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Cadastro(Fornecedor Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                ObjFornecedorBLL.create(Obj);
                MensagemErroRegistrar(Obj);
                ModelState.Clear();
                return View("Index");
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }

        //mensagem de erro
        public void MensagemErroRegistrar(Fornecedor obj)
        {

            switch (obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + obj.RazaoSocial + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + obj.CNPJ + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + obj.RazaoSocial + "] foi Atualizado no sistema";
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


        [HttpGet]
        public ActionResult Atualizar(long id)
        {
            Session["IDFORNECEDORSelecionado"] = null;
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Fornecedor objFornecedor = new Fornecedor();
                objFornecedor.IdFornecedor = id;
                ObjFornecedorBLL.find(objFornecedor);

                //return View(objFornecedor);
                List<Entidades.Prancha> Listar = ObjPranchaBLL.ListarPranchaFornecedor(id);
                ViewBag.Pranchas = Listar;

                //ViewBag.DadosFornecedor = objFornecedor;
                Session["IDFORNECEDORSelecionado"] = id;
                return View(objFornecedor);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Atualizar(Fornecedor obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Prancha> Listar = ObjPranchaBLL.ListarPranchaFornecedor(obj.IdFornecedor);

                ViewBag.Pranchas = Listar;

                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                obj.IdStatus = 1;
                ObjFornecedorBLL.update(obj);
                MensagemErroRegistrar(obj);
                return View(obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Fornecedor> lista = ObjFornecedorBLL.findAll();
                return View(lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }

        [HttpPost]
        public ActionResult Busca(string txtNomeFantasiaRazaoSocial, string txtCNPJ, string txtCodInterno)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                   if (txtNomeFantasiaRazaoSocial == "")
                    {
                        txtNomeFantasiaRazaoSocial = "-1";
                    }

                    if (txtCNPJ == "")
                    {
                        txtCNPJ = "-1";
                    }

                    if (txtCodInterno == "")
                    {
                        txtCodInterno = "-1";
                    }

                    Fornecedor objFornecedor = new Fornecedor();
                    objFornecedor.RazaoSocial = txtNomeFantasiaRazaoSocial;
                    objFornecedor.CNPJ = txtCNPJ;
                    objFornecedor.CodigoInterno = txtCodInterno;

                    List<Fornecedor> FornecedorLista = ObjFornecedorBLL.BuscarRazaoSocialCNPJCodInterno(objFornecedor);
                    return View(FornecedorLista);
            }
            else
            {
                return RedirectToAction("../Home");
            }
            

        }

    }


    }
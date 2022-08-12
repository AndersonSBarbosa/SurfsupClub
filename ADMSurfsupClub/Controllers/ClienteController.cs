using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// OK
/// </summary>

namespace ADMSurfsupClub.Controllers
{
    public class ClienteController : Controller
    {
        BLL.Cliente ObjClienteBLL;

        public ClienteController()
        {
            ObjClienteBLL = new BLL.Cliente();
        }

        // GET: Cliente
        public ActionResult Index()
        {

            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Cliente> ListaCliente = ObjClienteBLL.findAll();
                return View(ListaCliente);
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
        public ActionResult Cadastro(Cliente Obj)
        {


            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
            
                Obj.IdStatus = 1;
                ObjClienteBLL.create(Obj);
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
        public void MensagemErroRegistrar(Cliente obj)
        {

            switch (obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + obj.Nome +" "+obj.Sobrenome + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + obj.CPF + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + obj.Nome + " " + obj.Sobrenome + "] foi Atualizado no sistema";
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

            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                Cliente objFornecedor = new Cliente();
                objFornecedor.IdCliente = id;
                ObjClienteBLL.find(objFornecedor);
                return View(objFornecedor);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult Atualizar(Cliente obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
                List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
                SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
                ViewBag.ListarAllEstados = ListarEstados;

                mensagemInicioRegistrar();
                obj.IdStatus = 1;
                ObjClienteBLL.update(obj);
                MensagemErroRegistrar(obj);
                return View();
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
                List<Cliente> lista = ObjClienteBLL.findAll();
                return View(lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }

        [HttpPost]
        public ActionResult Busca(string txtNomeCompleto, string txtCPF, string txtCodInterno)
        {


            if (Session["usuarioLogadoID"] != null)
            {
                if (txtNomeCompleto == "")
                {
                    txtNomeCompleto = "-1";
                }

                if (txtCPF == "")
                {
                    txtCPF = "-1";
                }

                if (txtCodInterno == "")
                {
                    txtCodInterno = "-1";
                }

                Cliente objFornecedor = new Cliente();
                objFornecedor.Nome = txtNomeCompleto;
                objFornecedor.CPF = txtCPF;
                objFornecedor.CodigoInterno = txtCodInterno;

                List<Cliente> FornecedorLista = ObjClienteBLL.Buscar(objFornecedor);
                return View(FornecedorLista);
            }
            else
            {
                return RedirectToAction("../Home");
            }



        }

    }
}
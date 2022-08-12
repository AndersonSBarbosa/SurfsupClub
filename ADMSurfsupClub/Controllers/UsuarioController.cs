using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using System.Net.Mail;
using System.Text;
/// <summary>
/// OK
/// </summary>
namespace ADMSurfsupClub.Controllers
{
    //[Authorize]
    public class UsuarioController : Controller
    {
        BLL.Usuario ObjUsuarioBLL;
        BLL.Fornecedor ObjFornecedorBLL;


        public UsuarioController()
        {
            ObjUsuarioBLL = new BLL.Usuario();
            ObjFornecedorBLL = new BLL.Fornecedor();
        }

        #region Funções Basicas

        // GET: Usuario
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Usuario> Listar = ObjUsuarioBLL.findAll();
                return View(Listar);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Usuario/Create
        [HttpGet]
        public ActionResult Cadastro()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.ListarNivel = new SelectList
                    (
                        new Nivel().ListaNiveis(),
                        "IdNivel",
                        "NomeNivel"
                    );

                mensagemInicioRegistrar();
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Cadastro(Usuario Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.ListarNivel = new SelectList
                    (
                        new Nivel().ListaNiveis(),
                        "IdNivel",
                        "NomeNivel"
                    );

                mensagemInicioRegistrar();
                    Obj.IdStatus = 1;
                    //Obj.Senha = PaginaBase.CreatePassword(8);
                    Obj.Senha = "@teste@";
                ObjUsuarioBLL.create(Obj);
                    MensagemErroRegistrar(Obj);

                StringBuilder sb = new StringBuilder();
                string CorpoEmail;
                sb.Append(@"<html><head><meta http-equiv='Content-Type'content='text/html; charset=UTF-8' /><title>----------</title></head> <body>Nome: "+Obj.Nome+"<br>Login: "+Obj.Login+"<br>Senha:"+Obj.Senha+" <br>E-mail:"+Obj.Email+"< br></body></html> ");
                CorpoEmail = sb.ToString();
                //PaginaBase.EnviaEmailPadrao("Novo Usuario Cadastrado", CorpoEmail, Obj.Email);

                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        //mensagem de erro
        public void MensagemErroRegistrar(Usuario Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.IdUsuario + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.IdUsuario + "] já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.IdUsuario + "] foi Atualizado no sistema";
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
                case 7:
                    ViewBag.MensagemErro = "selecione pelo menos um Fornecedor";
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

        // POST: Usuario/updade
        [HttpGet]
        public ActionResult Atualizar(long id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Fornecedor> ListaFornecedores = ObjFornecedorBLL.ListarFornecedorVinculadoUsuario(2,0, Convert.ToInt32(id));
                ViewBag.FornecedoresVinculados = ListaFornecedores;

                mensagemInicioRegistrar();
                Usuario Obj = new Usuario();
                Obj.IdUsuario = id;
                ObjUsuarioBLL.find(Obj);

                ViewBag.ListarNivel = new SelectList
                 (
                     new Nivel().ListaNiveis(),
                     "IdNivel",
                     "NomeNivel",
                     Obj.IdNivel
                 );

                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }


        }
        [HttpPost]
        public ActionResult Atualizar(Usuario Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.ListarNivel = new SelectList
               (
                   new Nivel().ListaNiveis(),
                   "IdNivel",
                   "NomeNivel",
                   Obj.IdNivel
               );
                    mensagemInicioRegistrar();
                    Obj.IdStatus = 1;
                    ObjUsuarioBLL.update(Obj);
                    MensagemErroRegistrar(Obj);
                    return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }



        // POST: Usuario/VincularFranquias
        [HttpGet]
        public ActionResult VincularFranquias(long id)
        {
            Session["IdUsuarioSelecionado"] = null;
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Fornecedor> ListaFornecedores = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                ViewBag.ListarFornecedores = ListaFornecedores;
                ViewBag.FornecedoresVinculados = ListaFornecedores;

                mensagemInicioRegistrar();
                Usuario Obj = new Usuario();
                Obj.IdUsuario = id;
                Session["IdUsuarioSelecionado"] = Obj.IdUsuario;
                ObjUsuarioBLL.find(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult VincularFranquias(string camposMarcados)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                Usuario Obj = new Usuario();
                if (String.IsNullOrEmpty(camposMarcados))
                {
                    Obj.Resposta = 7;
                    MensagemErroRegistrar(Obj);
                }
                else
                {

                    string[] ids = camposMarcados.Split(',');
                    //ShowArrayInfo(camposMarcados);
                    Fornecedor objFornecedor = new Fornecedor();
                    foreach (string id in ids)
                    {
                        objFornecedor.Usuario.IdUsuario = Convert.ToInt32(Session["IdUsuarioSelecionado"].ToString());
                        objFornecedor.IdFornecedor = Convert.ToInt32(id);
                        ObjFornecedorBLL.VincularFornecedoresUsuario(objFornecedor);
                    }
                }

                List<Entidades.Fornecedor> ListaFornecedores = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                ViewBag.FornecedoresVinculados = ListaFornecedores;
                //return View();

                return RedirectToAction("Atualizar/" + Session["IdUsuarioSelecionado"].ToString());

            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        


        // POST: Usuario/Buscar
        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Usuario> lista = ObjUsuarioBLL.findAll();
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

                Usuario Obj = new Usuario();
                Obj.Nome = txtBuscar;

                List<Usuario> Lista = ObjUsuarioBLL.Buscar(Obj);
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
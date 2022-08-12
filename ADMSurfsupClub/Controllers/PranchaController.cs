using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Net;

namespace ADMSurfsupClub.Controllers
{
    //[Authorize]
    public class PranchaController : Controller
    {
        BLL.Prancha ObjPranchaBLL;
        BLL.Fornecedor ObjFornecedorBLL;
        BLL.PranchaImagem ObjPranchaImagemBLL;

        public PranchaController()
        {
            ObjPranchaBLL = new BLL.Prancha();
            ObjFornecedorBLL = new BLL.Fornecedor();
            ObjPranchaImagemBLL = new BLL.PranchaImagem();
        }


        #region Funções Basicas

        // GET: Prancha
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Entidades.Prancha> Listar = ObjPranchaBLL.findAll();
                return View(Listar);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // GET: Prancha/Create
        [HttpGet]
        public ActionResult Cadastro()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                ViewBag.ListarAllFornecedor = ListarFornecedor;

                BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                ViewBag.ListaItens = new SelectList
                (
                    new TipoItem().ListaItens(),
                    "IdItem",
                    "NomeItem"
                );

                mensagemInicioRegistrar();
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }


        }

        // POST: Prancha/Create
        [HttpPost]
        public ActionResult Cadastro(Prancha Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                    BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                    List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                    SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                    ViewBag.ListarAllFornecedor = ListarFornecedor;

                    BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                    List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                    SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                    ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                    BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                    List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                    SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                    ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                    BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                    List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                    SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                    ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                    ViewBag.ListaItens = new SelectList
                    (
                        new TipoItem().ListaItens(),
                        "IdItem",
                        "NomeItem"
                    );

                mensagemInicioRegistrar();
                    Obj.IdStatus = 1;
                    ObjPranchaBLL.create(Obj);
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
        public void MensagemErroRegistrar(Prancha Obj)
        {

            switch (Obj.Resposta)
            {
                #region Retorno Basico de Procedure
                //Retorno Basico de Procedure
                case 0://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + Obj.NomePrancha + "] foi inserido no sistema";
                    break;
                case 1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + Obj.CodigoInterno + "]/[" + Obj.NomePrancha + "]  já está no sistema";
                    break;

                case 2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case 3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + Obj.NomePrancha + "] foi Atualizado no sistema";
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
            ViewBag.MensagemInicio = "Insira os dados da Prancha e clique em salvar";
        }

        // POST: Prancha/updade
        [HttpGet]
        public ActionResult Atualizar(long id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                    BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                    List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                    SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                    ViewBag.ListarAllFornecedor = ListarFornecedor;

                    BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                    List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                    SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                    ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                    BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                    List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                    SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                    ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                    BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                    List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                    SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                    ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                    ViewBag.ListaItens = new SelectList
                    (
                        new TipoItem().ListaItens(),
                        "IdItem",
                        "NomeItem"
                    );

                //return View(objFornecedor);
                List<Entidades.PranchaImagem> Listar = ObjPranchaImagemBLL.ListarPranchaImagem(id);
                ViewBag.ImagensPrancha = Listar;

                mensagemInicioRegistrar();
                    Prancha Obj = new Prancha();
                    Obj.IdPrancha = id;
                    ObjPranchaBLL.find(Obj);
                    return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }
            
        }
        [HttpPost]
        public ActionResult Atualizar(Prancha Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarAllFornecedorAtivo();
                SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                ViewBag.ListarAllFornecedor = ListarFornecedor;

                BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                ViewBag.ListaItens = new SelectList
                (
                    new TipoItem().ListaItens(),
                    "IdItem",
                    "NomeItem"
                );

                mensagemInicioRegistrar();
                Obj.IdStatus = 1;
                
                ObjPranchaBLL.update(Obj);
                MensagemErroRegistrar(Obj);
                return View(Obj);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        // POST: Prancha/Buscar
        [HttpGet]
        public ActionResult Busca()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                List<Prancha> lista = ObjPranchaBLL.findAll();
                return View(lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }

        [HttpPost]
        public ActionResult Busca(string txtBusca)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                if (txtBusca == "")
                {
                    txtBusca = "-1";
                }

                Prancha Obj = new Prancha();
                Obj.NomePrancha = txtBusca;

                List<Prancha> Lista = ObjPranchaBLL.Buscar(Obj);
                return View(Lista);
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            PranchaImagem obj = new PranchaImagem();
            obj.IdImagem = Convert.ToInt32(id);
            ObjPranchaImagemBLL.find(obj);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(Entidades.PranchaImagem obj)
        {
            var imagem = Path.Combine(Server.MapPath("~/Content/ImagensPrancha"), obj.Imagem);
            if (System.IO.File.Exists(imagem))
            {
                System.IO.File.Delete(imagem);
                ObjPranchaImagemBLL.delete(obj);
            }

            return RedirectToAction("Atualizar/" + obj.IdPrancha);
        }

        #endregion

        [HttpGet]
        public ActionResult CadastrarPranchaFornecedor()
        {
            if (Session["usuarioLogadoID"] != null)
            {  
                int Idfornecedor = Convert.ToInt32(Session["IDFORNECEDORSelecionado"].ToString());
                BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarFornecedorSelecionado(Idfornecedor);
                SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                ViewBag.ListarAllFornecedor = ListarFornecedor;

                BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                ViewBag.ListaItens = new SelectList
                (
                    new TipoItem().ListaItens(),
                    "IdItem",
                    "NomeItem"
                );

                mensagemInicioRegistrar();
                return View();
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }
        [HttpPost]
        public ActionResult CadastrarPranchaFornecedor(Fornecedor Obj, Prancha ObjPran)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                int Idfornecedor = Convert.ToInt32(Session["IDFORNECEDORSelecionado"].ToString());
                BLL.Fornecedor ObjFornecedorBLL = new BLL.Fornecedor();
                List<Fornecedor> DataFornecedor = ObjFornecedorBLL.ListarFornecedorSelecionado(Idfornecedor);
                SelectList ListarFornecedor = new SelectList(DataFornecedor, "IDFORNECEDOR", "NOMEFANTASIA");
                ViewBag.ListarAllFornecedor = ListarFornecedor;

                BLL.PranchaMarca ObjPranchaMarcaBLL = new BLL.PranchaMarca();
                List<PranchaMarca> DataPranchaMarca = ObjPranchaMarcaBLL.ListarAllPranchaMarcaAtivo();
                SelectList ListarPranchaMarca = new SelectList(DataPranchaMarca, "IDMARCA", "MARCA");
                ViewBag.ListarAllPranchaMarcaAtivo = ListarPranchaMarca;

                BLL.PranchaModalidade ObjPranchaModalidadeBLL = new BLL.PranchaModalidade();
                List<PranchaModalidade> DataPranchaModalidade = ObjPranchaModalidadeBLL.ListarAllPranchaModalidadeAtivo();
                SelectList ListarPranchaModalidade = new SelectList(DataPranchaModalidade, "IDMODALIDADE", "MODALIDADE");
                ViewBag.ListarAllPranchaModalidadeAtivo = ListarPranchaModalidade;

                BLL.PranchaModelo ObjPranchaModeloBLL = new BLL.PranchaModelo();
                List<PranchaModelo> DataPranchaModelo = ObjPranchaModeloBLL.ListarAllPranchaModeloAtivo();
                SelectList ListarPranchaModelo = new SelectList(DataPranchaModelo, "IDMODELO", "MODELO");
                ViewBag.ListarAllPranchaModeloAtivo = ListarPranchaModelo;

                ViewBag.ListaItens = new SelectList
                (
                    new TipoItem().ListaItens(),
                    "IdItem",
                    "NomeItem"
                );

                mensagemInicioRegistrar();
                ObjPran.IdStatus = 1;
                ObjPranchaBLL.create(ObjPran);
                MensagemErroRegistrar(ObjPran);
                //return View();
                return RedirectToAction("../Fornecedor/Atualizar/"+ Idfornecedor);
            }
            else
            {
                return RedirectToAction("../Home");
            }

        }


        //////////////Carregar Imagem///////////////////////////////////////////
        // GET: /FileUpload/
        [HttpGet]
        public ActionResult UploadFotos(long id)
        {
                    if (Session["usuarioLogadoID"] != null)
                    {
                        mensagemInicioRegistrar();
                        Prancha Obj = new Prancha();
                        Obj.IdPrancha = id;
                        ObjPranchaBLL.find(Obj);

                        //return View(objFornecedor);
                        List<Entidades.PranchaImagem> Listar = ObjPranchaImagemBLL.ListarPranchaImagem(id);
                        ViewBag.ImagensPrancha = Listar;

                return View(Obj);
                    }
                    else
                    {
                        return RedirectToAction("../Home");
                    }
          }


        [HttpPost]
        public ActionResult UploadFotos(HttpPostedFileBase file, Prancha Obj)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                PranchaImagem ObjImg = new PranchaImagem();
            ObjImg.IdStatus = 1;
            ObjImg.Capa = true;
            ObjImg.IdPrancha = Convert.ToInt32(Obj.IdPrancha.ToString());

            if (file != null)
                {

                    string[] contentTypes = new string[] { "image/jpg", "image/png" };
                    if (!contentTypes.Contains(file.ContentType))
                    {
                        string pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Content/ImagensPrancha"), pic);
                        // file is uploaded
                        file.SaveAs(path);
                        ObjImg.Imagem = pic;
                        ObjImg.Caminho = path;

                        // save the image path path to the database or you can send image 
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            ObjImg.Img = array.ToString();
                        }
                    }

                }
              else
                {
                    return RedirectToAction("UploadFotos/" + ObjImg.IdPrancha);
                }
            
            ObjPranchaImagemBLL.create(ObjImg);

            // after successfully uploading redirect the user
            return RedirectToAction("Atualizar/"+ObjImg.IdPrancha);
            }
            else
            {
                return RedirectToAction("../Home");
            }
        }
        ///////////////////////////////////////////////////////////////////////

    }
}
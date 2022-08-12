using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SurfsUpClubVer2.Controllers
{
    public class HomeController : Controller
    {
        BLL.Cliente ObjClienteBLL;

        public HomeController()
        {
            ObjClienteBLL = new BLL.Cliente();
        }
        public ActionResult Index()
        {
            return View();
        }

        #region Cadastro


        [HttpGet]
        public ActionResult Cadastro()
        {

            BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
            List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
            SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
            ViewBag.ListarAllEstados = ListarEstados;

            ViewBag.ListarSexo = new SelectList
            (
                new Sexo().ListarSexo(),
                "IdSexo",
                "NomeSexo"
            );

            mensagemInicioRegistrar();
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Cadastro(Cliente Obj)
        {
            BLL.CidadeEstadoPais ObjCidadeEstadoPaisBLL = new BLL.CidadeEstadoPais();
            List<CidadeEstadoPais> DataEstado = ObjCidadeEstadoPaisBLL.ListarAllEstados();
            SelectList ListarEstados = new SelectList(DataEstado, "UF", "Uf");
            ViewBag.ListarAllEstados = ListarEstados;

            ViewBag.ListarSexo = new SelectList
            (
                new Sexo().ListarSexo(),
                "IdSexo",
                "NomeSexo"
            );


            mensagemInicioRegistrar();
            Obj.IdStatus = 1;
            Obj.Telefone1 = "(" + Obj.DDD1 + ")" + Obj.Telefone1;
            Obj.Telefone2 = "(" + Obj.DDD2 + ")" + Obj.Telefone2;
            Obj.Telefone3 = "(" + Obj.DDD3 + ")" + Obj.Telefone3;
            Obj.Telefone4 = "(" + Obj.DDD4 + ")" + Obj.Telefone4;
            ObjClienteBLL.create(Obj);
            MensagemErroRegistrar(Obj);
            ModelState.Clear();
            if (Obj.Resposta == 0)
            {

                //crio objeto responsável pela mensagem de email
                MailMessage objEmail = new MailMessage();

                StringBuilder sb = new StringBuilder();
                string CorpoEmail;
                sb.Append(@"<html><head><meta http-equiv='Content-Type'content='text/html; charset=UTF-8' /><title>----------</title></head> <body>Nome: " + Obj.Nome + "<br>Senha:" + Obj.Senha + " <br>E-mail:" + Obj.Email + "< br></body></html> ");
                CorpoEmail = sb.ToString();

                //rementente do email
                objEmail.From = new MailAddress("anddesigner01@gmail.com");
                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
                objEmail.ReplyTo = new MailAddress("anddesigner01@gmail.com");
                //destinatário(s) do email(s). Obs. pode ser mais de um, pra isso basta repetir a linha
                //abaixo com outro endereço
                objEmail.To.Add(Obj.Email); //"destinatario@provedor.com.br"

                //se quiser enviar uma cópia oculta pra alguém, utilize a linha abaixo:
                objEmail.Bcc.Add("web_asb@yahoo.com.br");
                //prioridade do email

                objEmail.Priority = MailPriority.Normal;
                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto

                objEmail.IsBodyHtml = true;
                //Assunto do email
                objEmail.Subject = "Cadastro Realizado com Sucesso";

                //corpo do email a ser enviado

                objEmail.Body = CorpoEmail;
                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.

                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.

                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email

                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)

                objSmtp.Host = "smtp.gmail.com";

                //para envio de email autenticado, coloque login e senha de seu servidor de email

                //para detalhes leia abaixo do código

                objSmtp.Credentials = new NetworkCredential("contatosurfsup@gmail.com", "Surfsup123");

                //envia o email
                //======>// objSmtp.Send(objEmail);


                return RedirectToAction("Sucesso");
            }
            else
            {
                return View();
            }
            
        }

        //mensagem de erro
        public void MensagemErroRegistrar(Cliente obj)
        {

            switch (obj.Resposta)
            {
                #region Retorno Basico de Procedure
                case -1://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + obj.CPF + "] já está no sistema";
                    break;

                case -2://campo Registro Excluido
                    ViewBag.MensagemErro = "Registro Inexistente no Sistema";
                    break;

                case -3://campo Atualizado
                    ViewBag.MensagemErro = "Registro [" + obj.Nome + "] foi Atualizado no sistema";
                    break;
                //////////////////////////
                #endregion

                case -4://campo nome vazio
                    ViewBag.MensagemErro = "Campo Obrigatório";
                    break;
                case -5://Registro Encontrado
                    ViewBag.MensagemExito = "Registro Encontrado no sistema";
                    break;
                case -6://Registro Não Encontrado
                    ViewBag.MensagemExito = "Registro não Encontrado no sistema";
                    break;
                case -7://erro de duplicidade
                    ViewBag.MensagemErro = "Registro [" + obj.Email + "] já está no sistema";
                    break;
                case -8://Registro Não Encontrado
                    ViewBag.MensagemExito = "Data de Nascimento Invalida";
                    break;
                case -60://erro de Quantidade de Caracteres
                    ViewBag.MensagemErro = "O nome não pode ter mais de 60 caracteres";
                    break;
                case -40://erro de Quantidade de Caracteres
                    ViewBag.MensagemErro = "O nome não pode ter mais de 40 caracteres";
                    break;

                default://Registro Salvo com Sucesso
                    ViewBag.MensagemExito = "Registro [" + obj.Nome + "] foi inserido no sistema";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Fornecedor e clique em salvar";
        }

        #endregion
    }
}
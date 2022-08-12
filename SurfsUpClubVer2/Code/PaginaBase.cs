using System;
using System.Configuration;
using System.Text;
using System.Data;
using RaiCore;
using System.Threading.Tasks;

namespace ADMSurfsupClub.Controllers
{
    public class PaginaBase
    {

        static string EmailTesteDesenvolvedor = "anddesigner@hotmail.com";
        static string EmailAtendimento = "anddesigner@hotmail.com";

        public string RemoverAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return String.Empty;
            else
            {
                texto = texto.Replace(" ", "-");
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(texto);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
        public Boolean IsNumeric(String num)
        {
            Int32 numero;

            return Int32.TryParse(num, out numero);
        }
        public Boolean IsNumeric(Object num)
        {
            Int32 numero;

            return Int32.TryParse(num.ToString(), out numero);
        }
        public String Upper(String texto)
        {
            return texto.ToUpper();
        }
        public String Lower(String texto)
        {
            return texto.ToLower();
        }
        public Boolean IsDate(String date)
        {
            DateTime data;

            return DateTime.TryParse(date.ToString(), out data);
        }
        public Boolean IsDate(Object date)
        {
            DateTime data;

            return DateTime.TryParse(date.ToString(), out data);
        }

        public static void EnviaEmailPadrao(string Assunto, string Corpo, string para)
        {
            String[] destinatarios = { EmailAtendimento, EmailTesteDesenvolvedor, para };
            string CorpoEmail;
            string[] copia = { };
            CorpoEmail = Corpo;
            Email email = new Email(AppSettings("User"), destinatarios, copia, Assunto, CorpoEmail, System.Net.Mail.MailPriority.Normal, null, AppSettings("SMTP"), AppSettings("User"), AppSettings("Password"), int.Parse(AppSettings("Port")), true);
            email.SendEmailAutenticado();
        }
        public static void EnviaEmailLembreteSenha(string Nome, string Login, string Senha, string Email, string titulo)
        {
            StringBuilder sb = new StringBuilder();
            String[] destinatarios = { Email };
            string CorpoEmail;
            string[] copia = { };


            sb.Append(@"


<html>
<head>
<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
<title>Plataforma de brindes Santander</title>
</head>

<body>
<table width='600' height='646' border='0' cellpadding='0' cellspacing='0' align='center'>
  <tr>
    <td><img src='http://gruporai.clientes.ananke.com.br/SistemaSantander_homolog/emkt/images/emkt_5_01.jpg' width='600' height='160' alt=''></td>
  </tr>
  <tr>
    <td height='43' style='font-family:Arial, Helvetica, sans-serif; color:#fe0000; text-transform:uppercase; font-size:24px; text-align:center;'>Lembrete de Senha</td>
  </tr>
  <tr>
    <td height='400'><table width='498' border='0' cellspacing='0' cellpadding='0' align='center' style='display:block; border:1px solid #cccccc;'>
        <tr>
          <td width='17' height='33' bgcolor='#fff' style='border-bottom: 1px solid #cccccc;'>&nbsp;</td>
          <td width='179' bgcolor='#fff' style='color:#000; border-bottom:1px solid #cccccc; border-right:1px solid #cccccc; font-family:Arial, Helvetica, sans-serif; font-size:14px;'>Nome:</td>
          <td width='300' style='color:#000; border-bottom:1px solid #cccccc; margin-left:10px; font-family:Arial, Helvetica, sans-serif; font-size:14px;padding: 0 10px 0 10px; '>" + Nome + @"</td>
        </tr>
        <tr>
          <td width='17' height='33' bgcolor='#eaeaea' style='border-bottom: 1px solid #cccccc;'>&nbsp;</td>
          <td width='179' bgcolor='#eaeaea' style='color:#000; border-bottom:1px solid #cccccc;border-right:1px solid #cccccc; font-family:Arial, Helvetica, sans-serif; font-size:14px;'>E-mail/ Login:</td>
          <td width='300' bgcolor='#eaeaea' style='color:#000; border-bottom:1px solid #cccccc; margin-left:10px; font-family:Arial, Helvetica, sans-serif; font-size:14px; line-height:18px;padding: 0 10px 0 10px;'>" + Login + @"</td>
        </tr>
        <tr>
          <td width='17' height='33' bgcolor='#fff' style='border-bottom: 1px solid #cccccc;'>&nbsp;</td>
          <td width='179' bgcolor='#fff' style='color:#000; border-bottom:1px solid #cccccc;border-right:1px solid #cccccc; font-family:Arial, Helvetica, sans-serif; font-size:14px;'>Senha:</td>
          <td width='300' style='color:#000; border-bottom:1px solid #cccccc;margin-left:10px; font-family:Arial, Helvetica, sans-serif; font-size:14px; line-height:18px;padding: 0 10px 0 10px;'>" + Senha + @"</td>
        </tr>

</table>
</td>
  </tr>
  <tr width='600' height='45'>
    <td width='600' height='45' style='color:#000;padding: 0 10px 0 10px; font-family:Arial, Helvetica, sans-serif; font-size:19px; line-height:18px;text-align:center'>Acesse o sistema pelo link:</td>
  </tr>
  <tr>
    <td align='center' style='color:#000; border-bottom:1px solid #fff; font-family:Arial, Helvetica, sans-serif; font-size:14px;'><a href='http://plataformadebrindesstd.com.br/' target='_blank'>http://plataformadebrindesstd.com.br/</a></td>
  </tr>
  <tr>
    <td width='600' style='text-align:center'><img src='http://gruporai.clientes.ananke.com.br/SistemaSantander_homolog/emkt/images/emkt_5_06.jpg' width='498' height='68' alt=''></td>
  </tr>
</table>
</body>
</html>


");

            CorpoEmail = sb.ToString();

            Email email = new Email(AppSettings("User"), destinatarios, copia, titulo, CorpoEmail, System.Net.Mail.MailPriority.Normal, null, AppSettings("SMTP"), AppSettings("User"), AppSettings("Password"), int.Parse(AppSettings("Port")), true);
            email.SendEmailAutenticado();
        }

        public static string AppSettings(string item)
        {
            return ConfigurationManager.AppSettings[item].ToString();
        }
        public static string BuscaWebCEP(string CEP)
        {

            string uf;
            string cidade;
            string bairro;
            string tipo_lagradouro;
            string lagradouro;
            string resultado;
            string resultato_txt;

            uf = "";
            cidade = "";
            bairro = "";
            tipo_lagradouro = "";
            lagradouro = "";
            resultado = "0";
            resultato_txt = "CEP não encontrado";

            //Cria um DataSet  baseado no retorno do XML  
            DataSet ds = new DataSet();
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                    switch (resultado)
                    {
                        case "1":
                            uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                            tipo_lagradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                            lagradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                            resultato_txt = "CEP completo";
                            break;
                        case "2":
                            uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            bairro = "";
                            tipo_lagradouro = "";
                            lagradouro = "";
                            resultato_txt = "CEP  único";
                            break;
                        default:
                            uf = "";
                            cidade = "";
                            bairro = "";
                            tipo_lagradouro = "";
                            lagradouro = "";
                            resultato_txt = "CEP não  encontrado";
                            break;
                    }
                }
            }




            //Exemplo do retorno da  WEB  
            //<?xml version="1.0"  encoding="iso-8859-1"?>  
            //<webservicecep>  
            //<uf>RS</uf>  
            //<cidade>Porto  Alegre</cidade>  
            //<bairro>Passo  D'Areia</bairro>  
            //<tipo_logradouro>Avenida</tipo_logradouro>  
            //<logradouro>Assis Brasil</logradouro>  
            //<resultado>1</resultado>  
            //<resultado_txt>sucesso - cep  completo</resultado_txt>  
            //</webservicecep>  


            return uf + "#" + cidade + "#" + bairro + "#" + tipo_lagradouro + "#" + lagradouro + "#" + resultato_txt;
        }
        //Definido variável com os caracteres utilizados na geração da senha
        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890";
        public static string CreatePassword(int tamanho)
        {
            //Aqui eu defino o número de caracteres que a senha terá
            //int tamanho = 8;
            //Aqui pego o valor máximo de caracteres para gerar a senha
            int valormaximo = SenhaCaracteresValidos.Length;
            //Criamos um objeto do tipo randon
            Random random = new Random(DateTime.Now.Millisecond);
            //Criamos a string que montaremos a senha
            StringBuilder senha = new StringBuilder(tamanho);
            //Fazemos um for adicionando os caracteres a senha
            for (int i = 0; i < tamanho; i++)
                senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);
            //retorna a senha
            return senha.ToString();
        }

        ////Instância classe email
        //MailMessage mail = new MailMessage();
        //mail.To.Add(_objModelMail.To);
        //mail.From = new MailAddress(_objModelMail.From);
        //mail.Subject = _objModelMail.Subject;
        //string Body = _objModelMail.Body;
        //mail.Body = Body;
        //mail.IsBodyHtml = true;

        ////Instância smtp do servidor, neste caso o gmail.
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.gmail.com";
        //smtp.Port = 587;
        //smtp.UseDefaultCredentials = false;
        //smtp.Credentials = new System.Net.NetworkCredential
        //("username", "password");// Login e senha do e-mail.
        //smtp.EnableSsl = true;
        //smtp.Send(mail);
        //return View("Index", _objModelMail);

    }
}
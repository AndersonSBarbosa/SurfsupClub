using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
        private DAL.Cliente objCliente;

        public Cliente()
        {
            objCliente = new DAL.Cliente();
        }

        public List<Entidades.Cliente> findAll()
        {
            return objCliente.findAll();
        }

        public void create(Entidades.Cliente Obj)
        {
            bool verificacao = true;

            // Nome obrigatorio com no maximo 40 caracteres
            string Nome = Obj.Nome;
            if (Nome == null)
            {
                Obj.Resposta = -4;
                return;
            }
            else
            {
                Nome = Obj.Nome.Trim();
                verificacao = Nome.Length <= 40 && Nome.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = -40;
                    return;
                }
            }

            // Sobrenome obrigatorio com no maximo 60 caracteres
            string Sobrenome = Obj.Sobrenome;
            if (Sobrenome == null)
            {
                Obj.Resposta = -4;
                return;
            }
            else
            {
                Sobrenome = Obj.Sobrenome.Trim();
                verificacao = Sobrenome.Length <= 60 && Sobrenome.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = -60;
                    return;
                }
            }

            // CNPJ obrigatorio com no maximo 60 caracteres
            string CPF = Obj.CPF;
            if (CPF == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                CPF = Obj.CPF.Trim();
                verificacao = CPF.Length <= 60 && CPF.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
                else
                {
                    //Verificar duplicidade cpf
                    Entidades.Cliente rs = new Entidades.Cliente();
                    rs.CPF = Obj.CPF;
                    verificacao = !objCliente.BuscarCPF(rs);
                    if (!verificacao)
                    {
                        Obj.Resposta = -1;
                        return;
                    }
                    else
                    {
                        Obj.Resposta = 0;
                    }

                }
            }

            // RazaoSocial obrigatorio com no maximo 60 caracteres
            string Email = Obj.Email;
            if (Email == null)
            {
                Obj.Resposta = -4;
                return;
            }
            else
            {
                Email = Obj.Email.Trim();
                verificacao = Email.Length <= 60 && Email.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = -60;
                    return;
                }
                else
                {
                    ////Verificar duplicidade EMAil
                    Entidades.Cliente rse = new Entidades.Cliente();
                    rse.Email = Obj.Email;
                    verificacao = !objCliente.BuscarEMAIL(rse);
                    if (!verificacao)
                    {
                        Obj.Resposta = -7;
                        return;
                    }
                    else
                    {
                        Obj.Resposta = 0;
                    }
                }
            }


            // Validade de Data
            string DataNascimento = Obj.DataNascimento.ToString();
            if (IsDate(DataNascimento))
            {
                Obj.Resposta = 0;
                return;
            }
            else
            {
                 Obj.Resposta = -8;
                    return;
            }

            //se nao tem erro
            Obj.Resposta = 0;
            Obj.IdCliente = 0;
            objCliente.create(Obj);
            return;
        }

        public Boolean IsDate(String date)
        {
            DateTime data;

            return DateTime.TryParse(date.ToString(), out data);
        }

        public bool find(Entidades.Cliente Obj)
        {
            return objCliente.find(Obj);
        }
        public Entidades.Cliente FornecedorDetalhes(long IdCliente)
        {
            try
            {
                DAL.Cliente rs = new DAL.Cliente();
                return rs.ClienteDetalhes(IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Cliente Obj)
        {
            bool verificacao = true;
            // NomeFantasia obrigatorio com no maximo 40 caracteres
            string Nome = Obj.Nome;
            if (Nome == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                Nome = Obj.Nome.Trim();
                verificacao = Nome.Length <= 40 && Nome.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // RazaoSocial obrigatorio com no maximo 60 caracteres
            string Sobrenome = Obj.Sobrenome;
            if (Sobrenome == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                Sobrenome = Obj.Sobrenome.Trim();
                verificacao = Sobrenome.Length <= 60 && Sobrenome.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // CNPJ obrigatorio com no maximo 60 caracteres
            string CPF = Obj.CPF;
            if (CPF == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                CPF = Obj.CPF.Trim();
                verificacao = CPF.Length <= 60 && CPF.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // RazaoSocial obrigatorio com no maximo 60 caracteres
            string Email = Obj.Email;
            if (Email == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                Email = Obj.Email.Trim();
                verificacao = Email.Length <= 60 && Email.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            //Verificar duplicidade RG
            Entidades.Cliente rs = new Entidades.Cliente();
            rs.CPF = Obj.CPF;
            rs.IdCliente = Obj.IdCliente;
            verificacao = !objCliente.BuscarCPFIdCliente(rs);
            if (!verificacao)
            {
                Obj.Resposta = 1;
                return;
            }
            //se nao tem erro
            Obj.Resposta = 3;
            objCliente.update(Obj);
            return;
        }

        public List<Entidades.Cliente> Buscar(Entidades.Cliente Obj)
        {
            return objCliente.Buscar(Obj);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class Fornecedor
    {
        private DAL.Fornecedor objFornecedor;

        public Fornecedor()
        {
            objFornecedor = new DAL.Fornecedor();
        }

        public List<Entidades.Fornecedor> findAll()
        {
            return objFornecedor.findAll();
        }

        public List<Entidades.Fornecedor> ListarFornecedorVinculadoUsuario(Int32 Carregamento, Int32 IdFornecedor, Int32 IdUsuario)
        {
            return objFornecedor.ListarFornecedorVinculadoUsuario(Carregamento, IdFornecedor, IdUsuario);
        }

        public void create(Entidades.Fornecedor Obj)
        {
            bool verificacao = true;

            // NomeFantasia obrigatorio com no maximo 40 caracteres
            string NomeFantasia = Obj.NomeFantasia;
            if (NomeFantasia == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                NomeFantasia = Obj.NomeFantasia.Trim();
                verificacao = NomeFantasia.Length <= 40 && NomeFantasia.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // RazaoSocial obrigatorio com no maximo 60 caracteres
            string RazaoSocial = Obj.RazaoSocial;
            if (RazaoSocial == null)
            {
                Obj.Resposta = 3;
                return;
            }
            else
            {
                RazaoSocial = Obj.NomeFantasia.Trim();
                verificacao = RazaoSocial.Length <= 60 && RazaoSocial.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // CNPJ obrigatorio com no maximo 60 caracteres
            string CNPJ = Obj.CNPJ;
            if (CNPJ == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                CNPJ = Obj.CNPJ.Trim();
                verificacao = CNPJ.Length <= 60 && CNPJ.Length > 0;
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
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            rs.CNPJ = Obj.CNPJ;
            verificacao = !objFornecedor.BuscarCNPJ(rs);
            if (!verificacao)
            {
                Obj.Resposta = 2;
                return;
            }
            //se nao tem erro
            Obj.Resposta = 0;

            Obj.IdFornecedor = 0;
            objFornecedor.create(Obj);
            return;
        }

        public bool find(Entidades.Fornecedor Obj)
        {
          return  objFornecedor.find(Obj);
        }
        public Entidades.Fornecedor Detalhes(long IdFornecedor)
        {
            try
            {
                DAL.Fornecedor rs = new DAL.Fornecedor();
                return rs.Detalhes(IdFornecedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Entidades.Fornecedor Obj)
        {
            bool verificacao = true;
            // NomeFantasia obrigatorio com no maximo 40 caracteres
            string NomeFantasia = Obj.NomeFantasia;
            if (NomeFantasia == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                NomeFantasia = Obj.NomeFantasia.Trim();
                verificacao = NomeFantasia.Length <= 40 && NomeFantasia.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // RazaoSocial obrigatorio com no maximo 60 caracteres
            string RazaoSocial = Obj.RazaoSocial;
            if (RazaoSocial == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                RazaoSocial = Obj.NomeFantasia.Trim();
                verificacao = RazaoSocial.Length <= 60 && RazaoSocial.Length > 0;
                if (!verificacao)
                {
                    Obj.Resposta = 250;
                    return;
                }
            }

            // CNPJ obrigatorio com no maximo 60 caracteres
            string CNPJ = Obj.CNPJ;
            if (CNPJ == null)
            {
                Obj.Resposta = 4;
                return;
            }
            else
            {
                CNPJ = Obj.CNPJ.Trim();
                verificacao = CNPJ.Length <= 60 && CNPJ.Length > 0;
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
            Entidades.Fornecedor rs = new Entidades.Fornecedor();
            rs.CNPJ = Obj.CNPJ;
            rs.IdFornecedor = Obj.IdFornecedor;
            verificacao = !objFornecedor.BuscarCNPJIdFornecedor(rs);
            if (!verificacao)
            {
                //se nao tem erro
                Obj.Resposta = 3;
                objFornecedor.update(Obj);

                
                return;
            }
             Obj.Resposta = 1;
            return;
        }

        public void VincularFornecedoresUsuario(Entidades.Fornecedor Obj)
        {
            Obj.Resposta = 3;
            objFornecedor.VincularFornecedoresUsuario(Obj);
            return;
        }



        public List<Entidades.Fornecedor> BuscarRazaoSocialCNPJCodInterno(Entidades.Fornecedor Obj)
        {
            return objFornecedor.BuscarRazaoSocialCNPJCodInterno(Obj);
        }

        public List<Entidades.Fornecedor> ListarAllFornecedorAtivo()
        {
            return objFornecedor.ListarAllFornecedorAtivo();
        }

        public List<Entidades.Fornecedor> ListarFornecedorSelecionado(Int32 idFornecedor)
        {
            return objFornecedor.ListarFornecedorSelecionado(idFornecedor);
        }


    }

}


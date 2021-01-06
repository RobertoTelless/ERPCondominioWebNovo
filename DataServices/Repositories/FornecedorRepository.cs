using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class FornecedorRepository : RepositoryBase<FORNECEDOR>, IFornecedorRepository
    {
        public FORNECEDOR CheckExist(FORNECEDOR conta, Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            query = query.Where(p => p.FORN_NM_NOME == conta.FORN_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public FORNECEDOR GetByEmail(String email, Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR.Where(p => p.FORN_IN_ATIVO == 1);
            query = query.Where(p => p.FORN_NM_EMAIL == email);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.Include(p => p.ASSINANTE);
            return query.FirstOrDefault();
        }

        public FORNECEDOR GetItemById(Int32 id)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            query = query.Where(p => p.FORN_CD_ID == id);
            query = query.Include(p => p.ASSINANTE);
            return query.FirstOrDefault();
        }

        public List<FORNECEDOR> GetAllItens(Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR.Where(p => p.FORN_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.Include(p => p.ASSINANTE);
            return query.ToList();
        }

        public List<FORNECEDOR> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.Include(p => p.ASSINANTE);
            return query.ToList();
        }

        public List<FORNECEDOR> ExecuteFilter(Int32? catId, String nome, String telefone, String email, String cpf, String cnpj, String descricao, String escopo, Int32 idAss)
        {
            List<FORNECEDOR> lista = new List<FORNECEDOR>();
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            if (catId != null)
            {
                query = query.Where(p => p.CATEGORIA_FORNECEDOR.CAFO_CD_ID == catId);
            }
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.FORN_NM_NOME.Contains(nome));
            }
            if (!String.IsNullOrEmpty(cpf))
            {
                query = query.Where(p => p.FORN_NR_CPF == cpf);
            }
            if (!String.IsNullOrEmpty(cnpj))
            {
                query = query.Where(p => p.FORN_NR_CNPJ == cnpj);
            }
            if (!String.IsNullOrEmpty(telefone))
            {
                query = query.Where(p => p.FORN_NR_TELEFONE.Contains(telefone));
            }
            if (!String.IsNullOrEmpty(email))
            {
                query = query.Where(p => p.FORN_NM_EMAIL.Contains(email));
            }
            if (!String.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.FORN_DS_DESCRICAO.Contains(descricao));
            }
            if (!String.IsNullOrEmpty(escopo))
            {
                query = query.Where(p => p.FORN_DS_ESCOPO.Contains(escopo));
            }
            if (query != null)
            {
                query = query.Where(p => p.FORN_IN_ATIVO == 1);
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.FORN_NM_NOME);
                lista = query.ToList<FORNECEDOR>();
            }
            return lista;
        }
    }
}

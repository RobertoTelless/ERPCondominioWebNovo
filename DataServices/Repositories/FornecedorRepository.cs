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
        public FORNECEDOR GetItemById(Int32 id)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            query = query.Where(p => p.FORN_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<FORNECEDOR> GetAllItens(Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR.Where(p => p.FORN_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.OrderBy(a => a.FORN_NM_NOME);
            return query.ToList();
        }

        public List<FORNECEDOR> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.OrderBy(a => a.FORN_NM_NOME);
            return query.ToList();
        }

        public List<FORNECEDOR> ExecuteFilter(Int32? cat, String nome, String telefone, String descricao, String escopo, Int32 idAss)
        {
            List<FORNECEDOR> lista = new List<FORNECEDOR>();
            IQueryable<FORNECEDOR> query = Db.FORNECEDOR;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.FORN_NM_NOME.Contains(nome));
            }
            if (cat != null)
            {
                query = query.Where(p => p.CAFO_CD_ID == cat);
            }
            if (!String.IsNullOrEmpty(telefone))
            {
                query = query.Where(p => p.FORN_NR_TELEFONE.Contains(telefone));
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
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.FORN_NM_NOME);
                lista = query.ToList<FORNECEDOR>();
            }
            return lista;
        }
    }
}

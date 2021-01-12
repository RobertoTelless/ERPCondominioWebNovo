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
    public class FornecedorMensagemRepository : RepositoryBase<FORNECEDOR_MENSAGEM>, IFornecedorMensagemRepository
    {
        public List<FORNECEDOR_MENSAGEM> GetAllItens(Int32 idAss)
        {
            return Db.FORNECEDOR_MENSAGEM.ToList();
        }

        public FORNECEDOR_MENSAGEM GetItemById(Int32 id)
        {
            IQueryable<FORNECEDOR_MENSAGEM> query = Db.FORNECEDOR_MENSAGEM.Where(p => p.FOME_CD_ID == id);
            return query.FirstOrDefault();
        }
    }
}

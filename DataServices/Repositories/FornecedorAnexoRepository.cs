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
    public class FornecedorAnexoRepository : RepositoryBase<FORNECEDOR_ANEXO>, IFornecedorAnexoRepository
    {
        public List<FORNECEDOR_ANEXO> GetAllItens()
        {
            return Db.FORNECEDOR_ANEXO.ToList();
        }

        public FORNECEDOR_ANEXO GetItemById(Int32 id)
        {
            IQueryable<FORNECEDOR_ANEXO> query = Db.FORNECEDOR_ANEXO.Where(p => p.FOAN_CD_ID == id);
            return query.FirstOrDefault();
        }
    }
}

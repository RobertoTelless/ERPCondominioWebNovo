using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class TarefaVinculoRepository : RepositoryBase<TAREFA_VINCULO>, ITarefaVinculoRepository
    {
        public List<TAREFA_VINCULO> GetAllItens()
        {
            return Db.TAREFA_VINCULO.ToList();
        }

        public TAREFA_VINCULO GetItemById(Int32 id)
        {
            IQueryable<TAREFA_VINCULO> query = Db.TAREFA_VINCULO.Where(p => p.TAVI_CD_ID == id);
            return query.FirstOrDefault();
        }
    }
}

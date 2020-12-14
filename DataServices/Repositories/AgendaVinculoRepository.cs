using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class AgendaVinculoRepository : RepositoryBase<AGENDA_VINCULO>, IAgendaVinculoRepository
    {
        public List<AGENDA_VINCULO> GetAllItens()
        {
            return Db.AGENDA_VINCULO.ToList();
        }

        public AGENDA_VINCULO GetItemById(Int32 id)
        {
            IQueryable<AGENDA_VINCULO> query = Db.AGENDA_VINCULO.Where(p => p.AGVI_CD_ID == id);
            return query.FirstOrDefault();
        }
    }
}
 
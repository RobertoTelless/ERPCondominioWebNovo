using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IAgendaVinculoRepository : IRepositoryBase<AGENDA_VINCULO>
    {
        List<AGENDA_VINCULO> GetAllItens();
        AGENDA_VINCULO GetItemById(Int32 id);
    }
}

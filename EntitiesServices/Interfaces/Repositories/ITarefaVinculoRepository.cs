using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITarefaVinculoRepository : IRepositoryBase<TAREFA_VINCULO>
    {
        List<TAREFA_VINCULO> GetAllItens();
        TAREFA_VINCULO GetItemById(Int32 id);
    }
}

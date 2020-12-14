using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IConfiguracaoAssociacaoRepository : IRepositoryBase<CONFIGURACAO_ASSOCIACAO>
    {
        List<CONFIGURACAO_ASSOCIACAO> GetAllItens(Int32 id);
        CONFIGURACAO_ASSOCIACAO GetItemById(Int32 id);
    }
}

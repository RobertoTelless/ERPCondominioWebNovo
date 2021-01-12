using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IFornecedorMensagemRepository : IRepositoryBase<FORNECEDOR_MENSAGEM>
    {
        List<FORNECEDOR_MENSAGEM> GetAllItens(Int32 idAss);
        FORNECEDOR_MENSAGEM GetItemById(Int32 id);
    }
}

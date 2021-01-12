using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITipoMensagemRepository : IRepositoryBase<TIPO_MENSAGEM>
    {
        List<TIPO_MENSAGEM> GetAllItens();
        TIPO_MENSAGEM GetItemById(Int32 id);
        List<TIPO_MENSAGEM> GetAllItensAdm();
    }
}

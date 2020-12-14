using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ICategoriaNotificacaoService : IServiceBase<CATEGORIA_NOTIFICACAO>
    {
        Int32 Create(CATEGORIA_NOTIFICACAO item, LOG log);
        Int32 Create(CATEGORIA_NOTIFICACAO item);
        Int32 Edit(CATEGORIA_NOTIFICACAO item, LOG log);
        Int32 Edit(CATEGORIA_NOTIFICACAO item);
        Int32 Delete(CATEGORIA_NOTIFICACAO item, LOG log);

        CATEGORIA_NOTIFICACAO CheckExist(CATEGORIA_NOTIFICACAO item, Int32? idAss);
        List<CATEGORIA_NOTIFICACAO> GetAllItens(Int32? idAss);
        CATEGORIA_NOTIFICACAO GetItemById(Int32 id);
        List<CATEGORIA_NOTIFICACAO> GetAllItensAdm(Int32? idAss);
    }
}

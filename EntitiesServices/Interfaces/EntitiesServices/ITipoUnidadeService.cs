using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ITipoUnidadeService : IServiceBase<TIPO_UNIDADE>
    {
        Int32 Create(TIPO_UNIDADE item, LOG log);
        Int32 Create(TIPO_UNIDADE item);
        Int32 Edit(TIPO_UNIDADE item, LOG log);
        Int32 Edit(TIPO_UNIDADE item);
        Int32 Delete(TIPO_UNIDADE item, LOG log);

        TIPO_UNIDADE CheckExist(TIPO_UNIDADE item, Int32? idAss);
        List<TIPO_UNIDADE> GetAllItens(Int32? idAss);
        TIPO_UNIDADE GetItemById(Int32 id);
        List<TIPO_UNIDADE> GetAllItensAdm(Int32? idAss);
    }
}

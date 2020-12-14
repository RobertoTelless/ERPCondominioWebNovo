using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ITipoGrupoService : IServiceBase<TIPO_GRUPO>
    {
        Int32 Create(TIPO_GRUPO item, LOG log);
        Int32 Create(TIPO_GRUPO item);
        Int32 Edit(TIPO_GRUPO item, LOG log);
        Int32 Edit(TIPO_GRUPO item);
        Int32 Delete(TIPO_GRUPO item, LOG log);

        TIPO_GRUPO CheckExist(TIPO_GRUPO item, Int32? idAss);
        List<TIPO_GRUPO> GetAllItens(Int32? idAss);
        TIPO_GRUPO GetItemById(Int32 id);
        List<TIPO_GRUPO> GetAllItensAdm(Int32? idAss);
    }
}

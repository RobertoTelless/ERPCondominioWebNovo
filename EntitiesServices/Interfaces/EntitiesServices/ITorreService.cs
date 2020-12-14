using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ITorreService : IServiceBase<TORRE>
    {
        Int32 Create(TORRE item, LOG log);
        Int32 Create(TORRE item);
        Int32 Edit(TORRE item, LOG log);
        Int32 Edit(TORRE item);
        Int32 Delete(TORRE item, LOG log);

        TORRE CheckExist(TORRE item, Int32? idAss);
        List<TORRE> GetAllItens(Int32? idAss);
        TORRE GetItemById(Int32 id);
        List<TORRE> GetAllItensAdm(Int32? idAss);
    }
}

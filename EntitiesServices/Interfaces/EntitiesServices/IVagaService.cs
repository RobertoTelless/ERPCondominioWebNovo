using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IVagaService : IServiceBase<VAGA>
    {
        Int32 Create(VAGA item, LOG log);
        Int32 Create(VAGA item);
        Int32 Edit(VAGA item, LOG log);
        Int32 Edit(VAGA item);
        Int32 Delete(VAGA item, LOG log);

        VAGA CheckExist(VAGA item, Int32? idAss);
        List<VAGA> GetAllItens(Int32? idAss);
        VAGA GetItemById(Int32 id);
        List<VAGA> GetAllItensAdm(Int32? idAss);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ITorreAppService : IAppServiceBase<TORRE>
    {
        Int32 ValidateCreate(TORRE item, USUARIO usuario);
        Int32 ValidateEdit(TORRE item, TORRE itemAntes, USUARIO usuario);
        Int32 ValidateEdit(TORRE item, TORRE itemAntes);
        Int32 ValidateDelete(TORRE item, USUARIO usuario);
        Int32 ValidateReativar(TORRE item, USUARIO usuario);

        TORRE CheckExist(TORRE tarefa, Int32 idUsu);
        List<TORRE> GetAllItens(Int32? idAss);
        List<TORRE> GetAllItensAdm(Int32? idAss);
        TORRE GetItemById(Int32 id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ITipoGrupoAppService : IAppServiceBase<TIPO_GRUPO>
    {
        Int32 ValidateCreate(TIPO_GRUPO item, USUARIO usuario);
        Int32 ValidateEdit(TIPO_GRUPO item, TIPO_GRUPO itemAntes, USUARIO usuario);
        Int32 ValidateEdit(TIPO_GRUPO item, TIPO_GRUPO itemAntes);
        Int32 ValidateDelete(TIPO_GRUPO item, USUARIO usuario);
        Int32 ValidateReativar(TIPO_GRUPO item, USUARIO usuario);

        TIPO_GRUPO CheckExist(TIPO_GRUPO item, Int32? idAss);
        List<TIPO_GRUPO> GetAllItens(Int32? idAss);
        TIPO_GRUPO GetItemById(Int32 id);
        List<TIPO_GRUPO> GetAllItensAdm(Int32? idAss);
    }
}

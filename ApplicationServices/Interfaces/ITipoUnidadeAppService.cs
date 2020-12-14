using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ITipoUnidadeAppService : IAppServiceBase<TIPO_UNIDADE>
    {
        Int32 ValidateCreate(TIPO_UNIDADE item, USUARIO usuario);
        Int32 ValidateEdit(TIPO_UNIDADE item, TIPO_UNIDADE itemAntes, USUARIO usuario);
        Int32 ValidateEdit(TIPO_UNIDADE item, TIPO_UNIDADE itemAntes);
        Int32 ValidateDelete(TIPO_UNIDADE item, USUARIO usuario);
        Int32 ValidateReativar(TIPO_UNIDADE item, USUARIO usuario);

        TIPO_UNIDADE CheckExist(TIPO_UNIDADE tarefa, Int32 idUsu);
        List<TIPO_UNIDADE> GetAllItens(Int32? idAss);
        List<TIPO_UNIDADE> GetAllItensAdm(Int32? idAss);
        TIPO_UNIDADE GetItemById(Int32 id);
    }
}

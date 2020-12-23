using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IUnidadeAppService : IAppServiceBase<UNIDADE>
    {
        Int32 ValidateCreate(UNIDADE item, Int32? torre, USUARIO usuario);
        Int32 ValidateEdit(UNIDADE item, UNIDADE itemAntes, USUARIO usuario);
        Int32 ValidateEdit(UNIDADE item, UNIDADE itemAntes);
        Int32 ValidateDelete(UNIDADE item, USUARIO usuario);
        Int32 ValidateReativar(UNIDADE item, USUARIO usuario);

        UNIDADE CheckExist(UNIDADE unidade, Int32 idUsu);
        List<UNIDADE> GetAllItens(Int32? idAss);
        List<UNIDADE> GetAllItensAdm(Int32? idAss);
        UNIDADE GetItemById(Int32 id);
        List<TIPO_UNIDADE> GetAllTipos(Int32? idAss);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IVagaAppService : IAppServiceBase<VAGA>
    {
        Int32 ValidateCreate(VAGA item, Int32? unidade, USUARIO usuario);
        Int32 ValidateEdit(VAGA item, VAGA itemAntes, USUARIO usuario);
        Int32 ValidateEdit(VAGA item, VAGA itemAntes);
        Int32 ValidateDelete(VAGA item, USUARIO usuario);
        Int32 ValidateReativar(VAGA item, VAGA usuario);

        VAGA CheckExist(VAGA tarefa, Int32 idUsu);
        List<VAGA> GetAllItens(Int32? idAss);
        List<VAGA> GetAllItensAdm(Int32? idAss);
        VAGA GetItemById(Int32 id);
    }
}

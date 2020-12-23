using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IFuncaoCorpoDiretivoRepository : IRepositoryBase<FUNCAO_CORPO_DIRETIVO>
    {
        FUNCAO_CORPO_DIRETIVO CheckExist(FUNCAO_CORPO_DIRETIVO item, Int32? idAss);
        List<FUNCAO_CORPO_DIRETIVO> GetAllItens(Int32 idAss);
        FUNCAO_CORPO_DIRETIVO GetItemById(Int32 id);
        List<FUNCAO_CORPO_DIRETIVO> GetAllItensAdm(Int32 idAss);
    }
}

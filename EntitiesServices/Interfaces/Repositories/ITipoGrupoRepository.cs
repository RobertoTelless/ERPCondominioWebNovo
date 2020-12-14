using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITipoGrupoRepository : IRepositoryBase<TIPO_GRUPO>
    {
        TIPO_GRUPO CheckExist(TIPO_GRUPO item, Int32? idAss);
        List<TIPO_GRUPO> GetAllItens(Int32 idAss);
        TIPO_GRUPO GetItemById(Int32 id);
        List<TIPO_GRUPO> GetAllItensAdm(Int32 idAss);
    }
}

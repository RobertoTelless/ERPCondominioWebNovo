using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IGrauParentescoRepository : IRepositoryBase<GRAU_PARENTESCO>
    {
        GRAU_PARENTESCO CheckExist(GRAU_PARENTESCO item);
        List<GRAU_PARENTESCO> GetAllItens();
        GRAU_PARENTESCO GetItemById(Int32 id);
        List<GRAU_PARENTESCO> GetAllItensAdm();
    }
}

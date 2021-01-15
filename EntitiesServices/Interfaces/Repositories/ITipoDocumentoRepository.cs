using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITipoDocumentoRepository : IRepositoryBase<TIPO_DOCUMENTO>
    {
        TIPO_DOCUMENTO CheckExist(TIPO_DOCUMENTO item);
        List<TIPO_DOCUMENTO> GetAllItens();
        TIPO_DOCUMENTO GetItemById(Int32 id);
        List<TIPO_DOCUMENTO> GetAllItensAdm();
    }
}

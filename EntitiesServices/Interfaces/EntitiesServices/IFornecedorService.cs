using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IFornecedorService : IServiceBase<FORNECEDOR>
    {
        Int32 Create(FORNECEDOR item, LOG log);
        Int32 Create(FORNECEDOR item);
        Int32 Edit(FORNECEDOR item, LOG log);
        Int32 Edit(FORNECEDOR item);
        Int32 Delete(FORNECEDOR item, LOG log);

        FORNECEDOR GetItemById(Int32 id);
        List<FORNECEDOR> GetAllItens(Int32 idAss);
        List<FORNECEDOR> GetAllItensAdm(Int32 idAss);
        List<FORNECEDOR> ExecuteFilter(Int32? cat, String nome, String telefone, String descricao, String escopo, Int32 idAss);
        List<CATEGORIA_FORNECEDOR> GetAllCategorias(Int32 idAss);
        List<UF> GetAllUFs();
        List<TIPO_PESSOA> GetAllTipoPessoa();
    }
}

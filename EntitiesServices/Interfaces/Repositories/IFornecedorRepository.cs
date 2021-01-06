using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepositoryBase<FORNECEDOR>
    {
        FORNECEDOR CheckExist(FORNECEDOR item, Int32 idAss);
        FORNECEDOR GetItemById(Int32 id);
        List<FORNECEDOR> GetAllItens(Int32 idAss);
        FORNECEDOR GetByEmail(String email, Int32 idAss);
        List<FORNECEDOR> GetAllItensAdm(Int32 idAss);
        List<FORNECEDOR> ExecuteFilter(Int32? cat, String nome, String telefone, String email, String cpf, String cnpj, String descricao, String escopo, Int32 idAss);
    }
}

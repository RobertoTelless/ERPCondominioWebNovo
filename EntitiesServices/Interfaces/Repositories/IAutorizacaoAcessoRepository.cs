using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IAutorizacaoAcessoRepository : IRepositoryBase<AUTORIZACAO_ACESSO>
    {
        AUTORIZACAO_ACESSO CheckExist(AUTORIZACAO_ACESSO item, Int32? idAss);
        AUTORIZACAO_ACESSO GetItemById(Int32 id);
        List<AUTORIZACAO_ACESSO> GetAllItens(Int32? idAss);
        List<AUTORIZACAO_ACESSO> GetAllItensAdm(Int32? idAss);
        List<AUTORIZACAO_ACESSO> ExecuteFilter(String nome, String documento, Int32? unidade, DateTime? dataPrevista, DateTime? dataEntrada, Int32? tipo, String motivo, Int32 idAss);
    }
}

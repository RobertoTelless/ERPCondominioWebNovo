using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IAutorizacaoAcessoService : IServiceBase<AUTORIZACAO_ACESSO>
    {
        Int32 Create(AUTORIZACAO_ACESSO perfil, LOG log);
        Int32 Create(AUTORIZACAO_ACESSO perfil);
        Int32 Edit(AUTORIZACAO_ACESSO perfil, LOG log);
        Int32 Edit(AUTORIZACAO_ACESSO perfil);
        Int32 Delete(AUTORIZACAO_ACESSO perfil, LOG log);

        AUTORIZACAO_ACESSO CheckExist(AUTORIZACAO_ACESSO forn, Int32? idAss);
        AUTORIZACAO_ACESSO GetItemById(Int32 id);
        List<AUTORIZACAO_ACESSO> GetAllItens(Int32? idAss);
        List<AUTORIZACAO_ACESSO> GetAllItensAdm(Int32? idAss);
        List<AUTORIZACAO_ACESSO> ExecuteFilter(String nome, String documento, Int32? unidade, DateTime? dataPrevista, DateTime? dataEntrada, Int32? tipo, String motivo, Int32 idAss);

        List<GRAU_PARENTESCO> GetAllGraus();
        List<TIPO_DOCUMENTO> GetAllTipos();
        List<UNIDADE> GetAllUnidades();
        TEMPLATE GetTemplate(String code);
        CONFIGURACAO CarregaConfiguracao(Int32 id);
    }
}

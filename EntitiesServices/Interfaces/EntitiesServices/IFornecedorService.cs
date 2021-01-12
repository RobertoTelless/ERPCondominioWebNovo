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
        Int32 Create(FORNECEDOR perfil, LOG log);
        Int32 Create(FORNECEDOR perfil);
        Int32 Edit(FORNECEDOR perfil, LOG log);
        Int32 Edit(FORNECEDOR perfil);
        Int32 Delete(FORNECEDOR perfil, LOG log);

        FORNECEDOR CheckExist(FORNECEDOR forn, Int32 idAss);
        FORNECEDOR GetItemById(Int32 id);
        FORNECEDOR GetByEmail(String email, Int32 idAss);
        List<FORNECEDOR> GetAllItens(Int32 idAss);
        List<FORNECEDOR> GetAllItensAdm(Int32 idAss);
        List<FORNECEDOR> ExecuteFilter(Int32? cat, String nome, String telefone, String email, String cpf, String cnpj, String descricao, String escopo, Int32 idAss);

        List<CATEGORIA_FORNECEDOR> GetAllCategorias(Int32 idAss);
        List<TIPO_PESSOA> GetAllTiposPessoa();
        List<UF> GetAllUF();
        UF GetUFbySigla(String sigla);
        List<TIPO_MENSAGEM> GetAllTiposMensagem();
        TEMPLATE GetTemplate(String code);
        CONFIGURACAO CarregaConfiguracao(Int32 id);

        FORNECEDOR_ANEXO GetAnexoById(Int32 id);

        FORNECEDOR_CONTATO GetContatoById(Int32 id);
        Int32 EditContato(FORNECEDOR_CONTATO item);
        Int32 CreateContato(FORNECEDOR_CONTATO item);

        FORNECEDOR_MENSAGEM GetMensagemById(Int32 id);
        Int32 EditMensagem(FORNECEDOR_MENSAGEM item);
        Int32 CreateMensagem(FORNECEDOR_MENSAGEM item);
    }
}

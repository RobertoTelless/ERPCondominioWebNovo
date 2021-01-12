using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IFornecedorAppService : IAppServiceBase<FORNECEDOR>
    {
        Int32 ValidateCreate(FORNECEDOR perfil, USUARIO usuario);
        Int32 ValidateEdit(FORNECEDOR perfil, FORNECEDOR perfilAntes, USUARIO usuario);
        Int32 ValidateEdit(FORNECEDOR item, FORNECEDOR itemAntes);
        Int32 ValidateDelete(FORNECEDOR perfil, USUARIO usuario);
        Int32 ValidateReativar(FORNECEDOR perfil, USUARIO usuario);

        List<FORNECEDOR> GetAllItens(Int32 idAss);
        List<FORNECEDOR> GetAllItensAdm(Int32 idAss);
        FORNECEDOR GetItemById(Int32 id);
        FORNECEDOR GetByEmail(String email, Int32 idAss);
        FORNECEDOR CheckExist(FORNECEDOR conta, Int32 idAss);
        Int32 ExecuteFilter(Int32? cat, String nome, String telefone, String email, String cpf, String cnpj, String descricao, String escopo, Int32 idAss, out List<FORNECEDOR> objeto);

        List<CATEGORIA_FORNECEDOR> GetAllCategorias(Int32 idAss);
        List<TIPO_PESSOA> GetAllTiposPessoa();
        List<UF> GetAllUF();
        UF GetUFbySigla(String sigla);
        List<TIPO_MENSAGEM> GetAllTiposMensagem();
        TEMPLATE GetTemplate(String code);

        FORNECEDOR_ANEXO GetAnexoById(Int32 id);
  
        FORNECEDOR_CONTATO GetContatoById(Int32 id);
        Int32 ValidateEditContato(FORNECEDOR_CONTATO item);
        Int32 ValidateCreateContato(FORNECEDOR_CONTATO item);

        FORNECEDOR_MENSAGEM GetMensagemById(Int32 id);
        Int32 ValidateEditMensagem(FORNECEDOR_MENSAGEM item);
        Int32 ValidateCreateMensagem(FORNECEDOR_MENSAGEM item, USUARIO usuario);
    }
}

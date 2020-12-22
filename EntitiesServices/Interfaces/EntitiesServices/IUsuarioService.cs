using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IUsuarioService : IServiceBase<USUARIO>
    {
        Boolean VerificarCredenciais(String senha, USUARIO usuario);
        USUARIO GetByEmail(String email);
        USUARIO GetByLogin(String login);
        USUARIO RetriveUserByEmail(String email);
        Int32 CreateUser(USUARIO usuario, LOG log);
        Int32 CreateUser(USUARIO usuario);
        Int32 EditUser(USUARIO usuario, LOG log);
        Int32 EditUser(USUARIO usuario);

        USUARIO CheckExist(USUARIO item, Int32? idAss);
        Int32 VerifyUserSubscription(USUARIO usuario);
        Endereco GetAdressCEP(string CEP);
        CONFIGURACAO CarregaConfiguracao(Int32 id);
        List<USUARIO> GetAllUsuariosAdm(Int32 idAss);
        USUARIO GetItemById(Int32 id);
        List<USUARIO> GetAllUsuarios(Int32 idAss);
        TEMPLATE GetTemplate(String code);
        List<PERFIL> GetAllPerfis();
        List<USUARIO> GetAllItens(Int32 idAss);
        List<USUARIO> GetAllItensBloqueados(Int32 idAss);
        List<USUARIO> GetAllItensAcessoHoje(Int32 idAss);
        List<USUARIO> ExecuteFilter(Int32? causId, Int32? cargoId, Int32? unidId, String nome, String login, String email, String cpf, Int32 idAss);
        USUARIO_ANEXO GetAnexoById(Int32 id);
        List<NOTIFICACAO> GetAllItensUser(Int32 id, Int32 idAss);
        List<NOTIFICACAO> GetNotificacaoNovas(Int32 id, Int32 idAss);
        List<NOTICIA> GetAllNoticias(Int32 idAss);
        USUARIO GetSindico(Int32 idAss);
        List<UF> GetAllUF();
        List<CATEGORIA_USUARIO> GetAllTipos(Int32 idAss);
        List<CARGO> GetAllCargos(Int32 idAss);
        List<UNIDADE> GetAllUnidades(Int32 idAss);
        List<TORRE> GetAllTorres(Int32 idAss);
        USUARIO GetResponsavel(USUARIO usu);
    }
}

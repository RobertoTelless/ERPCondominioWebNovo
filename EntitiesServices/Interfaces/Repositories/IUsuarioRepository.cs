using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<USUARIO>
    {
        USUARIO GetByEmail(String email);
        USUARIO GetByLogin(String login);
        USUARIO GetItemById(Int32 id);
        List<USUARIO> GetAllUsuarios(Int32 idAss);
        List<USUARIO> GetAllItens(Int32 idAss);
        List<USUARIO> GetAllItensBloqueados(Int32 idAss);
        List<USUARIO> GetAllItensAcessoHoje(Int32 idAss);
        List<USUARIO> GetAllUsuariosAdm(Int32 idAss);
        List<USUARIO> ExecuteFilter(Int32? causId, String cargo, String nome, String login, String email, String cpf, Int32 idAss);
        USUARIO GetAdministrador(Int32 idAss);
    }
}

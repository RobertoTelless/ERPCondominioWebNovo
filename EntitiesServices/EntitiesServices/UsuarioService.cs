using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;
using ModelServices.Interfaces.Repositories;
using ModelServices.Interfaces.EntitiesServices;
using CrossCutting;
using System.Data.Entity;
using System.Data;

namespace ModelServices.EntitiesServices
{
    public class UsuarioService : ServiceBase<USUARIO>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfRepository;
        private readonly ILogRepository _logRepository;
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly IUsuarioAnexoRepository _anexoRepository;
        private readonly INotificacaoRepository _notRepository;
        private readonly INoticiaRepository _ntcRepository;
        private readonly IUFRepository _ufRepository;
        private readonly ICategoriaUsuarioRepository _cuRepository;
        private readonly ITemplateRepository _tempRepository;
        private readonly ICargoRepository _carRepository;
        private readonly IUnidadeRepository _uniRepository;
        private readonly ITorreRepository _torRepository;

        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogRepository logRepository, IConfiguracaoRepository configuracaoRepository, IPerfilRepository perfRepository, IUsuarioAnexoRepository anexoRepository, INotificacaoRepository notRepository, INoticiaRepository ntcRepository, IUFRepository ufRepository, ICategoriaUsuarioRepository cuRepository, ITemplateRepository tempRepository, ICargoRepository carRepository, IUnidadeRepository uniRepository, ITorreRepository torRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _logRepository = logRepository;
            _configuracaoRepository = configuracaoRepository;
            _perfRepository = perfRepository;
            _anexoRepository = anexoRepository;
            _notRepository = notRepository;
            _ntcRepository = ntcRepository;
            _ufRepository = ufRepository;
            _cuRepository = cuRepository;
            _tempRepository = tempRepository;
            _carRepository = carRepository;
            _uniRepository = uniRepository;
            _torRepository = torRepository;
        }

        public USUARIO CheckExist(USUARIO item, Int32? idAss)
        {
            USUARIO volta = _usuarioRepository.CheckExist(item, idAss);
            return volta;
        }

        public USUARIO RetriveUserByEmail(String email)
        {
            USUARIO usuario = _usuarioRepository.GetByEmail(email);
            return usuario;
        }

        public List<CATEGORIA_USUARIO> GetAllTipos(Int32 idAss)
        {
            return _cuRepository.GetAllItens(idAss);
        }

        public List<CARGO> GetAllCargos(Int32 idAss)
        {
            return _carRepository.GetAllItens(idAss);
        }

        public List<UNIDADE> GetAllUnidades(Int32 idAss)
        {
            return _uniRepository.GetAllItensAssinante(idAss);
        }

        public List<TORRE> GetAllTorres(Int32 idAss)
        {
            return _torRepository.GetAllItens(idAss);
        }

        public TEMPLATE GetTemplate(String code)
        {
            return _tempRepository.GetByCode(code);
        }

        public Boolean VerificarCredenciais (String senha, USUARIO usuario)
        {
            // Criptografa senha informada
            //String senhaCrip = Cryptography.Encode(senha);
            string senhaCrip = senha;

            // verifica senha
            if (usuario.USUA_NM_SENHA.Trim() != senhaCrip.Trim())
            {
                return false;
            }
            return true;
        }

        public USUARIO GetByEmail(String email)
        {
            return _usuarioRepository.GetByEmail(email);
        }

        public USUARIO_ANEXO GetAnexoById(Int32 id)
        {
            return _anexoRepository.GetItemById(id);
        }

        public USUARIO GetByLogin(String login)
        {
            return _usuarioRepository.GetByLogin(login);
        }

        public USUARIO GetItemById(Int32 id)
        {
            return _usuarioRepository.GetItemById(id);
        }

        public List<USUARIO> GetAllUsuariosAdm(Int32 idAss)
        {
            return _usuarioRepository.GetAllUsuariosAdm(idAss);
        }

        public List<USUARIO> GetAllUsuarios(Int32 idAss)
        {
            return _usuarioRepository.GetAllUsuarios(idAss);
        }

        public List<USUARIO> GetAllItens(Int32 idAss)
        {
            return _usuarioRepository.GetAllItens(idAss);
        }

        public List<USUARIO> GetAllItensBloqueados(Int32 idAss)
        {
            return _usuarioRepository.GetAllItensBloqueados(idAss);
        }

        public USUARIO GetSindico(Int32 idAss)
        {
            return _usuarioRepository.GetSindico(idAss);
        }

        public USUARIO GetResponsavel(USUARIO usu)
        {
            return _usuarioRepository.GetResponsavel(usu);
        }

        public List<USUARIO> GetAllItensAcessoHoje(Int32 idAss)
        {
            return _usuarioRepository.GetAllItensAcessoHoje(idAss);
        }

        public Int32 CreateUser(USUARIO usuario, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _usuarioRepository.Add(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 CreateUser(USUARIO usuario)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _usuarioRepository.Add(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 EditUser(USUARIO usuario, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    USUARIO obj = _usuarioRepository.GetById(usuario.USUA_CD_ID);
                    _usuarioRepository.Detach(obj);
                    _logRepository.Add(log);
                    _usuarioRepository.Update(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 EditUser(USUARIO usuario)
        {
            try
            {
                usuario.PERFIL = null;
                usuario.CATEGORIA_USUARIO = null;
                usuario.ASSINANTE = null;
                usuario.AGENDA = null;
                USUARIO obj = _usuarioRepository.GetById(usuario.USUA_CD_ID);
                _usuarioRepository.Detach(obj);
                _usuarioRepository.Update(usuario);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 VerifyUserSubscription(USUARIO usuario)
        {
            return 0;
        }

        public Endereco GetAdressCEP(string CEP)
        {
            Endereco endereco = null;
            return endereco;
        }

        public CONFIGURACAO CarregaConfiguracao(Int32 id)
        {
            CONFIGURACAO conf = _configuracaoRepository.GetById(id);
            return conf;
        }

        public List<USUARIO> ExecuteFilter(Int32? causId, Int32? cargoId, Int32? unidId, String nome, String login, String email, String cpf, Int32 idAss)
        {
            List<USUARIO> lista = _usuarioRepository.ExecuteFilter(causId, cargoId, unidId, nome, login, email, cpf, idAss);
            return lista;
        }

        public List<PERFIL> GetAllPerfis()
        {
            List<PERFIL> lista = _perfRepository.GetAll().ToList();
            return lista;
        }

        public List<UF> GetAllUF()
        {
            List<UF> lista = _ufRepository.GetAllItens();
            return lista;
        }

        public List<NOTIFICACAO> GetAllItensUser(Int32 id, Int32 idAss)
        {
            return _notRepository.GetAllItensUser(id, idAss);
        }

        public List<NOTIFICACAO> GetNotificacaoNovas(Int32 id, Int32 idAss)
        {
            return _notRepository.GetNotificacaoNovas(id, idAss);
        }

        public List<NOTICIA> GetAllNoticias(Int32 idAss)
        {
            return _ntcRepository.GetAllItens(idAss);
        }

    }
}

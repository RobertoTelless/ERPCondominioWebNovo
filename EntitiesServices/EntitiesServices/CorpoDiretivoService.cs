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
    public class CorpoDiretivoService : ServiceBase<CORPO_DIRETIVO>, ICorpoDiretivoService
    {
        private readonly ICorpoDiretivoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly IFuncaoCorpoDiretivoRepository _funRepository;
        private readonly IUsuarioRepository _usuRepository;
        private readonly IConfiguracaoRepository _conRepository;
        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public CorpoDiretivoService(ICorpoDiretivoRepository baseRepository, ILogRepository logRepository, IFuncaoCorpoDiretivoRepository funRepository, IUsuarioRepository usuRepository, IConfiguracaoRepository confRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _funRepository = funRepository;
            _usuRepository = usuRepository;
            _conRepository = confRepository;
        }

        public CORPO_DIRETIVO GetItemById(Int32 id)
        {
            CORPO_DIRETIVO item = _baseRepository.GetItemById(id);
            return item;
        }

        public CONFIGURACAO CarregaConfiguracao(Int32 id)
        {
            CONFIGURACAO conf = _conRepository.GetById(id);
            return conf;
        }

        public List<CORPO_DIRETIVO> GetAllItens(Int32 idAss)
        {
            return _baseRepository.GetAllItens(idAss);
        }

        public List<CORPO_DIRETIVO> GetAllItensAdm(Int32 idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

        public List<FUNCAO_CORPO_DIRETIVO> GetAllFuncoes(Int32 idAss)
        {
            return _funRepository.GetAllItens(idAss);
        }

        public List<USUARIO> GetAllUsuarios(Int32 idAss)
        {
            return _usuRepository.GetAllItens(idAss);
        }

        public Int32 Create(CORPO_DIRETIVO item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _baseRepository.Add(item);
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

        public Int32 Create(CORPO_DIRETIVO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _baseRepository.Add(item);
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


        public Int32 Edit(CORPO_DIRETIVO item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CORPO_DIRETIVO obj = _baseRepository.GetById(item.CODI_CD_ID);
                    _baseRepository.Detach(obj);
                    _logRepository.Add(log);
                    _baseRepository.Update(item);
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

        public Int32 Edit(CORPO_DIRETIVO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CORPO_DIRETIVO obj = _baseRepository.GetById(item.CODI_CD_ID);
                    _baseRepository.Detach(obj);
                    _baseRepository.Update(item);
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

        public Int32 Delete(CORPO_DIRETIVO item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _baseRepository.Remove(item);
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
    }
}

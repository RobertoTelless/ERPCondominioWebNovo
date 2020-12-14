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
    public class CategoriaNotificacaoService : ServiceBase<CATEGORIA_NOTIFICACAO>, ICategoriaNotificacaoService
    {
        private readonly ICategoriaNotificacaoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public CategoriaNotificacaoService(ICategoriaNotificacaoRepository baseRepository, ILogRepository logRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
        }

        public CATEGORIA_NOTIFICACAO GetItemById(Int32 id)
        {
            CATEGORIA_NOTIFICACAO item = _baseRepository.GetItemById(id);
            return item;
        }

        public CATEGORIA_NOTIFICACAO CheckExist(CATEGORIA_NOTIFICACAO item, Int32? idAss)
        {
            CATEGORIA_NOTIFICACAO volta = _baseRepository.CheckExist(item, idAss);
            return volta;
        }

        public List<CATEGORIA_NOTIFICACAO> GetAllItens(Int32? id)
        {
            return _baseRepository.GetAllItens(id.Value);
        }

        public List<CATEGORIA_NOTIFICACAO> GetAllItensAdm(Int32? id)
        {
            return _baseRepository.GetAllItensAdm(id.Value);
        }
    
        public Int32 Create(CATEGORIA_NOTIFICACAO item, LOG log)
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

        public Int32 Create(CATEGORIA_NOTIFICACAO item)
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


        public Int32 Edit(CATEGORIA_NOTIFICACAO item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CATEGORIA_NOTIFICACAO obj = _baseRepository.GetById(item.CANO_CD_ID);
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

        public Int32 Edit(CATEGORIA_NOTIFICACAO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CATEGORIA_NOTIFICACAO obj = _baseRepository.GetById(item.CANO_CD_ID);
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

        public Int32 Delete(CATEGORIA_NOTIFICACAO item, LOG log)
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

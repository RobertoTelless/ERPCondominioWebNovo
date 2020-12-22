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
    public class UnidadeService : ServiceBase<UNIDADE>, IUnidadeService
    {
        private readonly IUnidadeRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public UnidadeService(IUnidadeRepository baseRepository, ILogRepository logRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
        }

        public UNIDADE GetItemById(Int32 id)
        {
            UNIDADE item = _baseRepository.GetItemById(id);
            return item;
        }

        public UNIDADE CheckExist(UNIDADE item, Int32? idAss)
        {
            UNIDADE volta = _baseRepository.CheckExist(item, idAss);
            return volta;
        }

        public List<UNIDADE> GetAllItens(Int32? id)
        {
            return _baseRepository.GetAllItens(id.Value);
        }

        public List<UNIDADE> GetAllItensAssinante(Int32 id)
        {
            return _baseRepository.GetAllItensAssinante(id);
        }

        public List<UNIDADE> GetAllItensAdm(Int32? id)
        {
            return _baseRepository.GetAllItensAdm(id.Value);
        }
    
        public Int32 Create(UNIDADE item, LOG log)
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

        public Int32 Create(UNIDADE item)
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


        public Int32 Edit(UNIDADE item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    UNIDADE obj = _baseRepository.GetById(item.UNID_CD_ID);
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

        public Int32 Edit(UNIDADE item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    UNIDADE obj = _baseRepository.GetById(item.UNID_CD_ID);
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

        public Int32 Delete(UNIDADE item, LOG log)
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

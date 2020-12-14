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
    public class ConfiguracaoService : ServiceBase<CONFIGURACAO>, IConfiguracaoService
    {
        private readonly IConfiguracaoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly IConfiguracaoAssociacaoRepository _assRepository;
        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public ConfiguracaoService(IConfiguracaoRepository baseRepository, ILogRepository logRepository, IConfiguracaoAssociacaoRepository assRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _assRepository = assRepository;
        }

        public CONFIGURACAO GetItemById(Int32 id)
        {
            CONFIGURACAO item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<CONFIGURACAO> GetAllItems()
        {
            List<CONFIGURACAO> item = _baseRepository.GetAllItems();
            return item;
        }

        public List<CONFIGURACAO_ASSOCIACAO> GetAllAssociacoes(Int32 id)
        {
            List<CONFIGURACAO_ASSOCIACAO> item = _assRepository.GetAllItens(id);
            return item;
        }

        public Int32 Edit(CONFIGURACAO item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CONFIGURACAO obj = _baseRepository.GetById(item.CONF_CD_ID);
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

        public Int32 Create(CONFIGURACAO item)
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
    }
}

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
    public class FornecedorService : ServiceBase<FORNECEDOR>, IFornecedorService
    {
        private readonly IFornecedorRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly ICategoriaFornecedorRepository _catRepository;
        private readonly IUFRepository _ufRepository;
        private readonly ITipoPessoaRepository _tpRepository;
        protected ERP_Condominio_DBEntities Db = new ERP_Condominio_DBEntities();

        public FornecedorService(IFornecedorRepository baseRepository, ILogRepository logRepository, ICategoriaFornecedorRepository catRepository, IUFRepository ufRepository, ITipoPessoaRepository tpRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _catRepository = catRepository;
            _ufRepository = ufRepository;
            _tpRepository = tpRepository;
        }

        public FORNECEDOR GetItemById(Int32 id)
        {
            FORNECEDOR item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<FORNECEDOR> GetAllItens(Int32 idAss)
        {
            return _baseRepository.GetAllItens(idAss);
        }

        public List<FORNECEDOR> GetAllItensAdm(Int32 idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

        public List<CATEGORIA_FORNECEDOR> GetAllCategorias(Int32 idAss)
        {
            return _catRepository.GetAllItens(idAss);
        }

        public List<UF> GetAllUFs()
        {
            return _ufRepository.GetAllItens();
        }

        public List<TIPO_PESSOA> GetAllTipoPessoa()
        {
            return _tpRepository.GetAllItens();
        }

        public List<FORNECEDOR> ExecuteFilter(Int32? cat, String nome, String telefone, String descricao, String escopo, Int32 idAss)
        {
            return _baseRepository.ExecuteFilter(cat, nome, telefone, descricao, escopo, idAss);

        }

        public Int32 Create(FORNECEDOR item, LOG log)
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

        public Int32 Create(FORNECEDOR item)
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


        public Int32 Edit(FORNECEDOR item, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    FORNECEDOR obj = _baseRepository.GetById(item.FORN_CD_ID);
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

        public Int32 Edit(FORNECEDOR item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    FORNECEDOR obj = _baseRepository.GetById(item.FORN_CD_ID);
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

        public Int32 Delete(FORNECEDOR item, LOG log)
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

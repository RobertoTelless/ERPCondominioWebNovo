using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class UnidadeRepository : RepositoryBase<UNIDADE>, IUnidadeRepository
    {
        public UNIDADE GetItemById(Int32 id)
        {
            IQueryable<UNIDADE> query = Db.UNIDADE;
            query = query.Where(p => p.UNID_CD_ID == id);
            return query.FirstOrDefault();
        }

        public UNIDADE CheckExist(UNIDADE item, Int32? idAss)
        {
            IQueryable<UNIDADE> query = Db.UNIDADE;
            query = query.Where(p => p.UNID_NR_NUMERO == item.UNID_NR_NUMERO);
            query = query.Where(p => p.TORR_CD_ID == item.TORR_CD_ID);
            return query.FirstOrDefault();
        }

        public List<UNIDADE> GetAllItens(Int32 idAss)
        {
            IQueryable<UNIDADE> query = Db.UNIDADE.Where(p => p.UNID_IN_ATIVO == 1);
            query = query.Where(p => p.TORR_CD_ID == idAss);
            return query.ToList();
        }

        public List<UNIDADE> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<UNIDADE> query = Db.UNIDADE;
            query = query.Where(p => p.TORR_CD_ID == idAss);
            return query.ToList();
        }
    }
}

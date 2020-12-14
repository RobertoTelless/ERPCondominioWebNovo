using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class CargoRepository : RepositoryBase<CARGO>, ICargoRepository
    {
        public CARGO GetItemById(Int32 id)
        {
            IQueryable<CARGO> query = Db.CARGO;
            query = query.Where(p => p.CARG_CD_ID == id);
            return query.FirstOrDefault();
        }

        public CARGO CheckExist(CARGO item, Int32? idAss)
        {
            IQueryable<CARGO> query = Db.CARGO;
            query = query.Where(p => p.CARG_NM_NOME == item.CARG_NM_NOME);
            return query.FirstOrDefault();
        }

        public List<CARGO> GetAllItens(Int32 idAss)
        {
            IQueryable<CARGO> query = Db.CARGO.Where(p => p.CARG_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CARGO> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<CARGO> query = Db.CARGO;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }
    }
}

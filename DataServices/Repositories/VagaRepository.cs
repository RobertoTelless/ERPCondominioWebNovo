using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class VagaRepository : RepositoryBase<VAGA>, IVagaRepository
    {
        public VAGA GetItemById(Int32 id)
        {
            IQueryable<VAGA> query = Db.VAGA;
            query = query.Where(p => p.VAGA_CD_ID == id);
            return query.FirstOrDefault();
        }

        public VAGA CheckExist(VAGA item, Int32? idAss)
        {
            IQueryable<VAGA> query = Db.VAGA;
            query = query.Where(p => p.VAGA_NR_NUMERO == item.VAGA_NR_NUMERO);
            query = query.Where(p => p.VAGA_NR_ANDAR == item.VAGA_NR_ANDAR);
            query = query.Where(p => p.UNID_CD_ID == item.UNID_CD_ID);
            return query.FirstOrDefault();
        }

        public List<VAGA> GetAllItens(Int32 idAss)
        {
            IQueryable<VAGA> query = Db.VAGA.Where(p => p.VAGA_IN_ATIVO == 1);
            query = query.Where(p => p.UNID_CD_ID == idAss);
            return query.ToList();
        }

        public List<VAGA> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<VAGA> query = Db.VAGA;
            query = query.Where(p => p.UNID_CD_ID == idAss);
            return query.ToList();
        }
    }
}

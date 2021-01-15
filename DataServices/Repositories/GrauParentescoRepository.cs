using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class GrauParentescoRepository : RepositoryBase<GRAU_PARENTESCO>, IGrauParentescoRepository
    {
        public GRAU_PARENTESCO GetItemById(Int32 id)
        {
            IQueryable<GRAU_PARENTESCO> query = Db.GRAU_PARENTESCO;
            query = query.Where(p => p.GRPA_CD_ID == id);
            return query.FirstOrDefault();
        }

        public GRAU_PARENTESCO CheckExist(GRAU_PARENTESCO item)
        {
            IQueryable<GRAU_PARENTESCO> query = Db.GRAU_PARENTESCO;
            query = query.Where(p => p.GRPA_NM_NOME == item.GRPA_NM_NOME);
            return query.FirstOrDefault();
        }

        public List<GRAU_PARENTESCO> GetAllItens()
        {
            IQueryable<GRAU_PARENTESCO> query = Db.GRAU_PARENTESCO.Where(p => p.GRPA_IN_ATIVO == 1);
            return query.ToList();
        }

        public List<GRAU_PARENTESCO> GetAllItensAdm()
        {
            IQueryable<GRAU_PARENTESCO> query = Db.GRAU_PARENTESCO;
            return query.ToList();
        }
    }
}

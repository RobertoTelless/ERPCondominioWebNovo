using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class TipoGrupoRepository : RepositoryBase<TIPO_GRUPO>, ITipoGrupoRepository
    {
        public TIPO_GRUPO GetItemById(Int32 id)
        {
            IQueryable<TIPO_GRUPO> query = Db.TIPO_GRUPO;
            query = query.Where(p => p.TIGR_CD_ID == id);
            return query.FirstOrDefault();
        }

        public TIPO_GRUPO CheckExist(TIPO_GRUPO item, Int32? idAss)
        {
            IQueryable<TIPO_GRUPO> query = Db.TIPO_GRUPO;
            query = query.Where(p => p.TIGR_NM_NOME == item.TIGR_NM_NOME);
            return query.FirstOrDefault();
        }

        public List<TIPO_GRUPO> GetAllItens(Int32 idAss)
        {
            IQueryable<TIPO_GRUPO> query = Db.TIPO_GRUPO.Where(p => p.TIGR_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<TIPO_GRUPO> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<TIPO_GRUPO> query = Db.TIPO_GRUPO;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }
    }
}

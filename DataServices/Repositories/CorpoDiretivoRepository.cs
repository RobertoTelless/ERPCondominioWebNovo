using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using EntitiesServices.Work_Classes;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class CorpoDiretivoRepository : RepositoryBase<CORPO_DIRETIVO>, ICorpoDiretivoRepository
    {
        public CORPO_DIRETIVO GetItemById(Int32 id)
        {
            IQueryable<CORPO_DIRETIVO> query = Db.CORPO_DIRETIVO;
            query = query.Where(p => p.CODI_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<CORPO_DIRETIVO> GetAllItens(Int32 idAss)
        {
            IQueryable<CORPO_DIRETIVO> query = Db.CORPO_DIRETIVO.Where(p => p.CODI_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CORPO_DIRETIVO> GetAllItensAdm(Int32 idAss)
        {
            IQueryable<CORPO_DIRETIVO> query = Db.CORPO_DIRETIVO;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CORPO_DIRETIVO> GetAllHistorico(Int32 idAss)
        {
            IQueryable<CORPO_DIRETIVO> query = Db.CORPO_DIRETIVO;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

    }
}

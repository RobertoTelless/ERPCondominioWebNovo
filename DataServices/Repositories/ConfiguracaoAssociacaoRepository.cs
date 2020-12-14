using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class ConfiguracaoAssociacaoRepository : RepositoryBase<CONFIGURACAO_ASSOCIACAO>, IConfiguracaoAssociacaoRepository
    {
        public CONFIGURACAO_ASSOCIACAO GetItemById(Int32 id)
        {
            IQueryable<CONFIGURACAO_ASSOCIACAO> query = Db.CONFIGURACAO_ASSOCIACAO;
            query = query.Where(p => p.COAS_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<CONFIGURACAO_ASSOCIACAO> GetAllItens(Int32 id)
        {
            IQueryable<CONFIGURACAO_ASSOCIACAO> query = Db.CONFIGURACAO_ASSOCIACAO;
            query = query.Where(p => p.CONF_CD_ID == id);
            return query.ToList();
        }
    }
}
 
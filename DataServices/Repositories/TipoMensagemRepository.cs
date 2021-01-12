using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class TipoMensagemRepository : RepositoryBase<TIPO_MENSAGEM>, ITipoMensagemRepository
    {
        public TIPO_MENSAGEM GetItemById(Int32 id)
        {
            IQueryable<TIPO_MENSAGEM> query = Db.TIPO_MENSAGEM;
            query = query.Where(p => p.TIME_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<TIPO_MENSAGEM> GetAllItensAdm()
        {
            IQueryable<TIPO_MENSAGEM> query = Db.TIPO_MENSAGEM;
            return query.ToList();
        }

        public List<TIPO_MENSAGEM> GetAllItens()
        {
            IQueryable<TIPO_MENSAGEM> query = Db.TIPO_MENSAGEM.Where(p => p.TIME_IN_ATIVO == 1);
            return query.ToList();
        }

    }
}
 
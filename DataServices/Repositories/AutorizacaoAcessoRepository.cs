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
    public class AutorizacaoAcessoRepository : RepositoryBase<AUTORIZACAO_ACESSO>, IAutorizacaoAcessoRepository
    {
        public AUTORIZACAO_ACESSO CheckExist(AUTORIZACAO_ACESSO conta, Int32? idAss)
        {
            IQueryable<AUTORIZACAO_ACESSO> query = Db.AUTORIZACAO_ACESSO;
            query = query.Where(p => p.AUAC_DT_VISITA == conta.AUAC_DT_VISITA);
            query = query.Where(p => p.AUAC_NM_VISITANTE == conta.AUAC_NM_VISITANTE);
            query = query.Where(p => p.AUAC_IN_TIPO == conta.AUAC_IN_TIPO);
            query = query.Where(p => p.UNID_CD_ID == conta.UNID_CD_ID);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public AUTORIZACAO_ACESSO GetItemById(Int32 id)
        {
            IQueryable<AUTORIZACAO_ACESSO> query = Db.AUTORIZACAO_ACESSO;
            query = query.Where(p => p.AUAC_CD_ID == id);
            query = query.Include(p => p.ASSINANTE);
            query = query.Include(p => p.USUARIO);
            query = query.Include(p => p.UNIDADE);
            query = query.Include(p => p.TIPO_DOCUMENTO);
            query = query.Include(p => p.GRAU_PARENTESCO);
            return query.FirstOrDefault();
        }

        public List<AUTORIZACAO_ACESSO> GetAllItens(Int32? idAss)
        {
            IQueryable<AUTORIZACAO_ACESSO> query = Db.AUTORIZACAO_ACESSO.Where(p => p.AUAC_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<AUTORIZACAO_ACESSO> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<AUTORIZACAO_ACESSO> query = Db.AUTORIZACAO_ACESSO;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<AUTORIZACAO_ACESSO> ExecuteFilter(String nome, String documento, Int32? unidade, DateTime? dataPrevista, DateTime? dataEntrada, Int32? tipo, String motivo, Int32 idAss)
        {
            List<AUTORIZACAO_ACESSO> lista = new List<AUTORIZACAO_ACESSO>();
            IQueryable<AUTORIZACAO_ACESSO> query = Db.AUTORIZACAO_ACESSO;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.AUAC_NM_VISITANTE.Contains(nome));
            }
            if (!String.IsNullOrEmpty(documento))
            {
                query = query.Where(p => p.AUAC_NR_DOCUMENTO.Contains(documento));
            }
            if (unidade != null)
            {
                query = query.Where(p => p.UNID_CD_ID == unidade);
            }
            if (dataPrevista != null)
            {
                query = query.Where(p => p.AUAC_DT_VISITA == dataPrevista);
            }
            if (dataEntrada != null)
            {
                query = query.Where(p => p.AUAC_DT_ENTRADA.Value.Date == dataEntrada.Value.Date);
            }
            if (tipo != null)
            {
                query = query.Where(p => p.AUAC_IN_TIPO == tipo);
            }
            if (!String.IsNullOrEmpty(motivo))
            {
                query = query.Where(p => p.AUAC_DS_MOTIVO.Contains(motivo));
            }
            if (query != null)
            {
                query = query.Where(p => p.AUAC_IN_ATIVO == 1);
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.AUAC_DT_VISITA);
                lista = query.ToList<AUTORIZACAO_ACESSO>();
            }
            return lista;
        }
    }
}

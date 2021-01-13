using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;
using ApplicationServices.Interfaces;
using ModelServices.Interfaces.EntitiesServices;
using CrossCutting;
using System.Text.RegularExpressions;

namespace ApplicationServices.Services
{
    public class CorpoDiretivoAppService : AppServiceBase<CORPO_DIRETIVO>, ICorpoDiretivoAppService
    {
        private readonly ICorpoDiretivoService _baseService;
        private readonly IUsuarioService _usuService;

        public CorpoDiretivoAppService(ICorpoDiretivoService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public List<CORPO_DIRETIVO> GetAllItens(Int32 idAss)
        {
            List<CORPO_DIRETIVO> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<CORPO_DIRETIVO> GetAllItensAdm(Int32 idAss)
        {
            List<CORPO_DIRETIVO> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public CORPO_DIRETIVO GetItemById(Int32 id)
        {
            CORPO_DIRETIVO item = _baseService.GetItemById(id);
            return item;
        }

        public List<FUNCAO_CORPO_DIRETIVO> GetAllFuncoes(Int32 idAss)
        {
            List<FUNCAO_CORPO_DIRETIVO> lista = _baseService.GetAllFuncoes(idAss);
            return lista;
        }

        public Int32 ValidateCreate(CORPO_DIRETIVO item, USUARIO usuario)
        {
            try
            {
                // Acerta campos
                CONFIGURACAO conf = _baseService.CarregaConfiguracao(usuario.ASSI_CD_ID);
                item.CODI_IN_ATIVO = 1;
                item.CODI_DT_FINAL = item.CODI_DT_INICIO.AddDays(conf.CONF_NR_CORPO_DIRETIVO_PERIODO.Value);
                item.ASSI_CD_ID = usuario.ASSI_CD_ID;

                // Recupera Lista
                List< CORPO_DIRETIVO> lista = _baseService.GetAllItens(usuario.ASSI_CD_ID);

                // Critica repetição
                lista = lista.Where(p => p.CODI_IN_ATIVO == 1 & p.ASSI_CD_ID == usuario.ASSI_CD_ID & p.USUA_CD_ID == item.USUA_CD_ID).ToList();
                if (lista.Count > 0)
                {
                    return 5;
                }

                // Checar datas
                if (item.CODI_DT_INICIO.Date > DateTime.Today.Date)
                {
                    return 6;
                }

                // Critica sindico
                if (item.FUCO_CD_ID == 1)
                {
                    lista = lista.Where(p => p.FUCO_CD_ID == 1 & p.CODI_IN_ATIVO == 1 & p.ASSI_CD_ID == usuario.ASSI_CD_ID).ToList();
                    if (lista.Count > 0)
                    {
                        return 1;
                    }
                }
                // Critica sub-sindico
                else if (item.FUCO_CD_ID == 2)
                {
                    lista = lista.Where(p => p.FUCO_CD_ID == 2 & p.CODI_IN_ATIVO == 1 & p.ASSI_CD_ID == usuario.ASSI_CD_ID).ToList();
                    if (lista.Count > 0)
                    {
                        return 2;
                    }
                }
                // Critica tesoureiro
                else if (item.FUCO_CD_ID == 3)
                {
                    lista = lista.Where(p => p.FUCO_CD_ID == 3 & p.CODI_IN_ATIVO == 1 & p.ASSI_CD_ID == usuario.ASSI_CD_ID).ToList();
                    if (lista.Count > 0)
                    {
                        return 3;
                    }
                }
                // Critica conselheiros
                else
                {
                    lista = lista.Where(p => p.FUCO_CD_ID == 4 & p.CODI_IN_ATIVO == 1 & p.ASSI_CD_ID == usuario.ASSI_CD_ID).ToList();
                    if (lista.Count >= conf.CONF_NR_NUMERO_CONSELHEIROS)
                    {
                        return 4;
                    }
                }

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddCODI",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CORPO_DIRETIVO>(item)
                };

                // Persiste
                Int32 volta = _baseService.Create(item, log);

                // Atualiza perfil de usuario
                USUARIO usu = _usuService.GetItemById(item.USUA_CD_ID.Value);
                if (item.FUCO_CD_ID == 1 || item.FUCO_CD_ID == 2)
                {
                    usu.PERF_CD_ID = 2;
                }
                else if (item.FUCO_CD_ID == 4 || item.FUCO_CD_ID == 3)
                {
                    usu.PERF_CD_ID = 3;
                }
                volta = _usuService.EditUser(usu);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(CORPO_DIRETIVO item, CORPO_DIRETIVO itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditCODI",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CORPO_DIRETIVO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CORPO_DIRETIVO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(CORPO_DIRETIVO item, CORPO_DIRETIVO itemAntes)
        {
            try
            {
                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(CORPO_DIRETIVO item, USUARIO usuario)
        {
            try
            {
                // Criticas
               
                // Acerta campos
                item.CODI_IN_ATIVO = 0;
                item.CODI_DT_SAIDA_REAL = DateTime.Today.Date;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCODI",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CORPO_DIRETIVO>(item)
                };

                // Persiste
                Int32 volta = _baseService.Edit(item, log);

                // Atualiza perfil de usuario
                USUARIO usu = _usuService.GetItemById(item.USUA_CD_ID.Value);
                usu.PERF_CD_ID = 6;
                volta = _usuService.EditUser(usu);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CORPO_DIRETIVO item, USUARIO usuario)
        {
            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

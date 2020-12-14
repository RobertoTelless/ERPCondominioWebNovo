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
    public class TipoGrupoAppService : AppServiceBase<TIPO_GRUPO>, ITipoGrupoAppService
    {
        private readonly ITipoGrupoService _baseService;

        public TipoGrupoAppService(ITipoGrupoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<TIPO_GRUPO> GetAllItens(Int32? idAss)
        {
            List<TIPO_GRUPO> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<TIPO_GRUPO> GetAllItensAdm(Int32? idAss)
        {
            List<TIPO_GRUPO> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public TIPO_GRUPO GetItemById(Int32 id)
        {
            TIPO_GRUPO item = _baseService.GetItemById(id);
            return item;
        }

        public TIPO_GRUPO CheckExist(TIPO_GRUPO ag, Int32? idAss)
        {
            TIPO_GRUPO item = _baseService.CheckExist(ag, idAss);
            return item;
        }

        public Int32 ValidateCreate(TIPO_GRUPO item, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, usuario.ASSI_CD_ID) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.TIGR_IN_ATIVO = 1;
                item.ASSI_CD_ID = usuario.ASSI_CD_ID;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "AddTIGR",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TIPO_GRUPO>(item)
                };

                // Persiste
                Int32 volta = _baseService.Create(item, log);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(TIPO_GRUPO item, TIPO_GRUPO itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "EditTIGR",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TIPO_GRUPO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<TIPO_GRUPO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(TIPO_GRUPO item, TIPO_GRUPO itemAntes)
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

        public Int32 ValidateDelete(TIPO_GRUPO item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                if (item.GRUPO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.TIGR_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DeleTIGR",
                    LOG_TX_REGISTRO = "Tipo de Grupo: " + item.TIGR_NM_NOME
                };

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(TIPO_GRUPO item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.TIGR_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatTIGR",
                    LOG_TX_REGISTRO = "Tipo de Grupo: " + item.TIGR_NM_NOME
                };

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

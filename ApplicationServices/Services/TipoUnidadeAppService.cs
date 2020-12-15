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
    public class TipoUnidadeAppService : AppServiceBase<TIPO_UNIDADE>, ITipoUnidadeAppService
    {
        private readonly ITipoUnidadeService _baseService;

        public TipoUnidadeAppService(ITipoUnidadeService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<TIPO_UNIDADE> GetAllItens(Int32? idAss)
        {
            List<TIPO_UNIDADE> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<TIPO_UNIDADE> GetAllItensAdm(Int32? idAss)
        {
            List<TIPO_UNIDADE> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public TIPO_UNIDADE GetItemById(Int32 id)
        {
            TIPO_UNIDADE item = _baseService.GetItemById(id);
            return item;
        }

        public TIPO_UNIDADE CheckExist(TIPO_UNIDADE ag, Int32 idAss)
        {
            TIPO_UNIDADE item = _baseService.CheckExist(ag, idAss);
            return item;
        }

        public Int32 ValidateCreate(TIPO_UNIDADE item, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, usuario.ASSI_CD_ID) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.TIUN_IN_ATIVO = 1;
                item.ASSI_CD_ID = usuario.ASSI_CD_ID;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "AddTIUN",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TIPO_UNIDADE>(item)
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

        public Int32 ValidateEdit(TIPO_UNIDADE item, TIPO_UNIDADE itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "EditTIUN",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TIPO_UNIDADE>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<TIPO_UNIDADE>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(TIPO_UNIDADE item, TIPO_UNIDADE itemAntes)
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

        public Int32 ValidateDelete(TIPO_UNIDADE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                if (item.UNIDADE.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.TIUN_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DeleTIUN",
                    LOG_TX_REGISTRO = "Tipo de Unidade: " + item.TIUN_NM_NOME
                };

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(TIPO_UNIDADE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.TIUN_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatTIUN",
                    LOG_TX_REGISTRO = "Tipo de Unidade: " + item.TIUN_NM_NOME
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

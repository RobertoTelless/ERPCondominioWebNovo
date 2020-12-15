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
    public class TorreAppService : AppServiceBase<TORRE>, ITorreAppService
    {
        private readonly ITorreService _baseService;

        public TorreAppService(ITorreService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<TORRE> GetAllItens(Int32? idAss)
        {
            List<TORRE> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<TORRE> GetAllItensAdm(Int32? idAss)
        {
            List<TORRE> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public TORRE GetItemById(Int32 id)
        {
            TORRE item = _baseService.GetItemById(id);
            return item;
        }

        public TORRE CheckExist(TORRE ag, Int32 idAss)
        {
            TORRE item = _baseService.CheckExist(ag, idAss);
            return item;
        }

        public Int32 ValidateCreate(TORRE item, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, usuario.ASSI_CD_ID) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.TORR_IN_ATIVO = 1;
                item.ASSI_CD_ID = usuario.ASSI_CD_ID;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "AddTORR",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TORRE>(item)
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

        public Int32 ValidateEdit(TORRE item, TORRE itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "EditTORR",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TORRE>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<TORRE>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(TORRE item, TORRE itemAntes)
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

        public Int32 ValidateDelete(TORRE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                if (item.UNIDADE.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.TORR_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DeleTORR",
                    LOG_TX_REGISTRO = "Torre: " + item.TORR_NR_NUMERO + " - " +item.TORR_NM_NOME
                };

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(TORRE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.TORR_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatTORR",
                    LOG_TX_REGISTRO = "Torre: " + item.TORR_NR_NUMERO + " - " + item.TORR_NM_NOME
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

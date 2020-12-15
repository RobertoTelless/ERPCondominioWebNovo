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
    public class VagaAppService : AppServiceBase<VAGA>, IVagaAppService
    {
        private readonly IVagaService _baseService;

        public VagaAppService(IVagaService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<VAGA> GetAllItens(Int32? idAss)
        {
            List<VAGA> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<VAGA> GetAllItensAdm(Int32? idAss)
        {
            List<VAGA> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public VAGA GetItemById(Int32 id)
        {
            VAGA item = _baseService.GetItemById(id);
            return item;
        }

        public VAGA CheckExist(VAGA ag, Int32 idAss)
        {
            VAGA item = _baseService.CheckExist(ag, idAss);
            return item;
        }

        public Int32 ValidateCreate(VAGA item, Int32? unidade, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, usuario.ASSI_CD_ID) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.VAGA_IN_ATIVO = 1;
                item.UNID_CD_ID = unidade.Value;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "AddVAGA",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<VAGA>(item)
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

        public Int32 ValidateEdit(VAGA item, VAGA itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_NM_OPERACAO = "EditVAGA",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<VAGA>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<VAGA>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(VAGA item, VAGA itemAntes)
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

        public Int32 ValidateDelete(VAGA item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                if (item.UNIDADE != null)
                {
                    return 1;
                }

                // Acerta campos
                item.VAGA_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DeleVAGA",
                    LOG_TX_REGISTRO = "Vaga: " + item.VAGA_NR_ANDAR + " - " +item.VAGA_NR_NUMERO
                };

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(VAGA item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.VAGA_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatVAGA",
                    LOG_TX_REGISTRO = "Vaga: " + item.VAGA_NR_ANDAR + " - " + item.VAGA_NR_NUMERO
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

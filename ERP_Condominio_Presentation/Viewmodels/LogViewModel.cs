using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace ERP_Condominio.ViewModels
{
    public class LogViewModel
    {
        public int LOG_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        public System.DateTime LOG_DT_DATA { get; set; }
        public string LOG_NM_OPERACAO { get; set; }
        public string LOG_TX_REGISTRO { get; set; }
        public string LOG_TX_REGISTRO_ANTES { get; set; }
        public int LOG_IN_ATIVO { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual ASSINANTE ASSINANTE1 { get; set; }
        public virtual USUARIO USUARIO { get; set; }

    }
}
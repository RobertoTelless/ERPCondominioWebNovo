using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace ERP_Condominio.ViewModels
{
    public class CorpoDiretivoViewModel
    {
        [Key]
        public int CODI_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo FUNÇÃO obrigatorio")]
        public int FUCO_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo DATA DE INÍCIO obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA DE INÍCIO Deve ser uma data válida")]
        public System.DateTime CODI_DT_INICIO { get; set; }
        [Required(ErrorMessage = "Campo DATA FINAL obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA FINAL Deve ser uma data válida")]
        public Nullable<System.DateTime> CODI_DT_FINAL { get; set; }
        [StringLength(500, ErrorMessage = "A OBSERVAÇÃO deve ter máximo 500 caracteres.")]
        public string CODI_TX_OBSERVACOES { get; set; }
        public System.DateTime CODI_DT_CADASTRO { get; set; }
        public int CODI_IN_ATIVO { get; set; }
        public Nullable<int> USUA_CD_ID { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE SAÍDA REAL Deve ser uma data válida")]
        public Nullable<System.DateTime> CODI_DT_SAIDA_REAL { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual FUNCAO_CORPO_DIRETIVO FUNCAO_CORPO_DIRETIVO { get; set; }
        public virtual USUARIO USUARIO { get; set; }

    }
}
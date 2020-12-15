//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntitiesServices.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTORIZACAO_ACESSO
    {
        public int AUAC_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        public Nullable<int> GRPA_CD_ID { get; set; }
        public string AUAC_NM_VISITANTE { get; set; }
        public string AUAC_NR_DOCUMENTO { get; set; }
        public string AUAC_DS_MOTIVO { get; set; }
        public string AUAC_NM_EMPRESA { get; set; }
        public int AUAC_IN_AVISO { get; set; }
        public int AUAC_IN_PERMANENTE { get; set; }
        public Nullable<System.DateTime> AUAC_DT_VISITA { get; set; }
        public Nullable<System.DateTime> AUAC_DT_LIMITE { get; set; }
        public Nullable<System.DateTime> AUAC_DT_ENTRADA { get; set; }
        public Nullable<System.DateTime> AUAC_DT_SAIDA { get; set; }
        public string AUAC_DS_OBSERVACOES { get; set; }
        public string AUAC_CD_VISITANTE { get; set; }
        public System.DateTime AUAC_DT_CADASTRO { get; set; }
        public int AUAC_IN_ATIVO { get; set; }
        public string AUAC_HR_ENTRADA { get; set; }
        public string AUAC_NR_SAIDA { get; set; }
        public int AUAC_IN_TIPO { get; set; }
        public Nullable<int> AUAC_IN_CONTROLE { get; set; }
        public Nullable<int> ASSI_CD_ID { get; set; }
        public Nullable<int> UNID_CD_ID { get; set; }
    
        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual GRAU_PARENTESCO GRAU_PARENTESCO { get; set; }
        public virtual UNIDADE UNIDADE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}

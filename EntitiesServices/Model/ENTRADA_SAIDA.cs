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
    
    public partial class ENTRADA_SAIDA
    {
        public int ENSA_CD_ID { get; set; }
        public Nullable<int> UNID_CD_ID { get; set; }
        public string ENSA_NR_DOCUMENTO { get; set; }
        public string ENSA_NM_EMPRESA { get; set; }
        public string ENSA_NM_NOME { get; set; }
        public string ENSA_NM_MOTIVO { get; set; }
        public Nullable<System.DateTime> ENSA_DT_ENTRADA { get; set; }
        public Nullable<System.DateTime> ENSA_DT_SAIDA { get; set; }
        public string ENSA_AQ_FOTO { get; set; }
        public string ENSA_DS_OBSERVACOES { get; set; }
        public int ENSA_IN_CONFIRMA { get; set; }
        public int ENSA_IN_LISTA_NEGRA { get; set; }
        public int ENSA_IN_STATUS { get; set; }
        public Nullable<int> ASSI_CD_ID { get; set; }
    
        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual UNIDADE UNIDADE { get; set; }
    }
}

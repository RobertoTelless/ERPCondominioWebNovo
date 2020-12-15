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
    
    public partial class ENCOMENDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENCOMENDA()
        {
            this.ENCOMENDA_ANEXO = new HashSet<ENCOMENDA_ANEXO>();
        }
    
        public int ENCO_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        public Nullable<int> FOEN_CD_ID { get; set; }
        public Nullable<int> TIEN_CD_ID { get; set; }
        public Nullable<System.DateTime> ENCO_DT_CHEGADA { get; set; }
        public string ENCO_NM_REMETENTE { get; set; }
        public string ENCO_NM_ENTREGADOR { get; set; }
        public string ENCO_DS_ENCOMENDA { get; set; }
        public string ENCO_CD_CODIGO { get; set; }
        public Nullable<System.DateTime> ENCO_DT_BAIXA { get; set; }
        public string ENCO_NM_PESSOA { get; set; }
        public int ENCO_IN_CONFIRMADO { get; set; }
        public int ENCO_IN_ATIVO { get; set; }
        public Nullable<int> UNID_CD_ID { get; set; }
        public Nullable<int> ASSI_CD_ID { get; set; }
    
        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENCOMENDA_ANEXO> ENCOMENDA_ANEXO { get; set; }
        public virtual FORMA_ENTREGA FORMA_ENTREGA { get; set; }
        public virtual TIPO_ENCOMENDA TIPO_ENCOMENDA { get; set; }
        public virtual UNIDADE UNIDADE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}

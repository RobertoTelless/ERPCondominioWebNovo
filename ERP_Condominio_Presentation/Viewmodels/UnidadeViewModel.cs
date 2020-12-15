using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;
using EntitiesServices.Attributes;

namespace ERP_Condominio.ViewModels
{
    public class UnidadeViewModel
    {
        [Key]
        public int UNID_CD_ID { get; set; }
        public int TORR_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo TIPO DE UNIDADE obrigatorio")]
        public int TIUN_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NÚMERO obrigatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O NÚMERO deve conter no minimo 1 e no máximo 10 caracteres.")]
        public string UNID_NR_NUMERO { get; set; }
        public Nullable<int> UNID_IN_ATIVO { get; set; }
        public Nullable<int> UNID_IN_ALUGADA { get; set; }

        public virtual TIPO_UNIDADE TIPO_UNIDADE { get; set; }
        public virtual TORRE TORRE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VAGA> VAGA { get; set; }
    }
}
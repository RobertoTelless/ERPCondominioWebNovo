using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;
using EntitiesServices.Attributes;

namespace ERP_Condominio.ViewModels
{
    public class VagaViewModel
    {
        [Key]
        public int VAGA_CD_ID { get; set; }
        public int UNID_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo ANDAR obrigatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O ANDAR deve conter no minimo 1 e no máximo 10 caracteres.")]
        public string VAGA_NR_ANDAR { get; set; }
        [Required(ErrorMessage = "Campo NÚMERO obrigatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O NÚMERO deve conter no minimo 1 e no máximo 10 caracteres.")]
        public string VAGA_NR_NUMERO { get; set; }
        public Nullable<int> VAGA_IN_ATIVO { get; set; }

        public virtual UNIDADE UNIDADE { get; set; }
    }
}
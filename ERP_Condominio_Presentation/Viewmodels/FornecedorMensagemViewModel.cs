using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace ERP_Condominio.ViewModels
{
    public class FornecedorMensagemViewModel
    {
        [Key]
        public int FOME_CD_ID { get; set; }
        public int FORN_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo TIPO DE MENSAGEM obrigatorio")]
        public int TIME_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo DATA obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "Deve ser uma data válida")]
        public System.DateTime FOME_DT_ENVIO { get; set; }
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "O TEXTO deve conter no minimo 1 e no máximo 5000 caracteres.")]
        public string FOME_DS_TEXTO { get; set; }
        public Nullable<int> FOME_IN_ATIVO { get; set; }
        public Nullable<int> FOME_IN_ENVIADO { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }
        public virtual TIPO_MENSAGEM TIPO_MENSAGEM { get; set; }
        public virtual USUARIO USUARIO { get; set; }

    }
}
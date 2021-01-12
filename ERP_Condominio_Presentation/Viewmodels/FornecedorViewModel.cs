using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;
using EntitiesServices.Attributes;

namespace ERP_Condominio.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int FORN_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo CATEGORIA obrigatorio")]
        public Nullable<int> CAFO_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo TIPO DE PESSOA obrigatorio")]
        public Nullable<int> TIPE_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve conter no minimo 1 e no máximo 50 caracteres.")]
        public string FORN_NM_NOME { get; set; }
        [StringLength(50, ErrorMessage = "A RAZÃO SOCIAL deve conter no máximo 50 caracteres.")]
        public string FORN_NM_RAZAO_SOCIAL { get; set; }
        [StringLength(50, ErrorMessage = "O DOCUMENTO deve conter no máximo 50 caracteres.")]
        public string FORN_NR_DOCUMENTO { get; set; }
        [StringLength(50, ErrorMessage = "O ENDREÇO deve conter no máximo 50 caracteres.")]
        public string FORM_NM_ENDERECO { get; set; }
        [StringLength(50, ErrorMessage = "O BAIRRO deve conter no máximo 50 caracteres.")]
        public string FORN_NM_BAIRRO { get; set; }
        [StringLength(50, ErrorMessage = "A CIDADE deve conter no máximo 50 caracteres.")]
        public string FORN_NM_CIDADE { get; set; }
        public Nullable<int> UF_CD_ID { get; set; }
        [StringLength(10, ErrorMessage = "O CEP deve conter no máximo 10 caracteres.")]
        public string FORN_NR_CEP { get; set; }
        [Required(ErrorMessage = "Campo TELEFONE obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O TELEFONE deve conter no minimo 1 e no máximo 50 caracteres.")]
        public string FORN_NR_TELEFONE { get; set; }
        [StringLength(50, ErrorMessage = "O NOME DO CONTATO deve conter no máximo 50 caracteres.")]
        public string FORN_NM_CONTATO { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O E-MAIL deve conter no minimo 1 e no máximo 100 caracteres.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Deve ser um e-mail válido")]
        public string FORN_NM_EMAIL { get; set; }
        [Required(ErrorMessage = "Campo DESCRICAO obrigatorio")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "A DESCRIÇÂO deve conter no minimo 1 e no máximo 1000 caracteres.")]
        public string FORN_DS_DESCRICAO { get; set; }
        public System.DateTime FORN_DT_CADASTRO { get; set; }
        public int FORN_IN_ATIVO { get; set; }
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "O ESCOPO deve conter no minimo 1 e no máximo 1000 caracteres.")]
        public string FORN_DS_ESCOPO { get; set; }
        [StringLength(50, ErrorMessage = "O CELULAR deve conter no máximo 50 caracteres.")]
        public string FORN_NR_CELULAR { get; set; }
        [StringLength(50, ErrorMessage = "O WHATSAPP deve conter no máximo 50 caracteres.")]
        public string FORN_NR_WHATSAPP { get; set; }
        [StringLength(50, ErrorMessage = "O SITE deve conter no máximo 50 caracteres.")]
        public string FORN_NM_WEBSITE { get; set; }
        [StringLength(50, ErrorMessage = "A INSCRIÇÂO ESTADUAL deve conter no máximo 50 caracteres.")]
        public string FORN_NR_INSCRICAO_ESTADUAL { get; set; }
        public string FORN_NM_SITUACAO { get; set; }
        [StringLength(50, ErrorMessage = "A INSCRIÇÂO MUNICIPAL deve conter no máximo 50 caracteres.")]
        public string FORN_NR_INSCRICAO_MUNICIPAL { get; set; }
        [StringLength(20, ErrorMessage = "O CPF deve conter no máximo 20 caracteres.")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string FORN_NR_CPF { get; set; }
        [StringLength(20, ErrorMessage = "O CNPJ deve conter no máximo 20 caracteres.")]
        [CustomValidationCNPJ(ErrorMessage = "CNPJ inválido")]
        public string FORN_NR_CNPJ { get; set; }
        [StringLength(250, ErrorMessage = "A IMAGEM deve conter no máximo 250 caracteres.")]
        public string FORN_AQ_FOTO { get; set; }
        public string FORN_TX_OBSERVACOES { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual CATEGORIA_FORNECEDOR CATEGORIA_FORNECEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDOR_ANEXO> FORNECEDOR_ANEXO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDOR_CONTATO> FORNECEDOR_CONTATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDOR_QUADRO_SOCIETARIO> FORNECEDOR_QUADRO_SOCIETARIO { get; set; }
        public virtual TIPO_PESSOA TIPO_PESSOA { get; set; }
        public virtual UF UF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDOR_COMENTARIO> FORNECEDOR_COMENTARIO { get; set; }
    }
}
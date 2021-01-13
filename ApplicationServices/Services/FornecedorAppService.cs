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
    public class FornecedorAppService : AppServiceBase<FORNECEDOR>, IFornecedorAppService
    {
        private readonly IFornecedorService _baseService;

        public FornecedorAppService(IFornecedorService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<FORNECEDOR> GetAllItens(Int32 idAss)
        {
            List<FORNECEDOR> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public TEMPLATE GetTemplate(String code)
        {
            return _baseService.GetTemplate(code);
        }

        public List<UF> GetAllUF()
        {
            List<UF> lista = _baseService.GetAllUF();
            return lista;
        }

        public UF GetUFbySigla(String sigla)
        {
            return _baseService.GetUFbySigla(sigla);
        }

        public List<FORNECEDOR> GetAllItensAdm(Int32 idAss)
        {
            List<FORNECEDOR> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public FORNECEDOR GetItemById(Int32 id)
        {
            FORNECEDOR item = _baseService.GetItemById(id);
            return item;
        }

        public FORNECEDOR GetByEmail(String email, Int32 idAss)
        {
            FORNECEDOR item = _baseService.GetByEmail(email, idAss);
            return item;
        }

        public FORNECEDOR CheckExist(FORNECEDOR conta, Int32 idAss)
        {
            FORNECEDOR item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<CATEGORIA_FORNECEDOR> GetAllCategorias(Int32 idAss)
        {
            List<CATEGORIA_FORNECEDOR> lista = _baseService.GetAllCategorias(idAss);
            return lista;
        }

        public FORNECEDOR_ANEXO GetAnexoById(Int32 id)
        {
            FORNECEDOR_ANEXO lista = _baseService.GetAnexoById(id);
            return lista;
        }

        public Int32 ExecuteFilter(Int32? catId, String nome, String telefone, String email, String cpf, String cnpj, String descricao, String escopo, Int32 idAss, out List<FORNECEDOR> objeto)
        {
            try
            {
                objeto = new List<FORNECEDOR>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(catId, nome, telefone, email, cpf, cnpj, descricao, escopo, idAss);
                if (objeto.Count == 0)
                {
                    volta = 1;
                }
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateCreate(FORNECEDOR item, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, usuario.ASSI_CD_ID) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.FORN_IN_ATIVO = 1;
                item.ASSI_CD_ID = usuario.ASSI_CD_ID;

                // Checa endereço
                if (String.IsNullOrEmpty(item.FORM_NM_ENDERECO))
                {
                    item.FORM_NM_ENDERECO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_BAIRRO))
                {
                    item.FORN_NM_BAIRRO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_CIDADE))
                {
                    item.FORN_NM_CIDADE = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NR_CEP))
                {
                    item.FORN_NR_CEP = "-";
                }
                if (item.UF_CD_ID == null)
                {
                    item.UF_CD_ID = 18;
                }

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddFORN",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<FORNECEDOR>(item)
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

        public Int32 ValidateEdit(FORNECEDOR item, FORNECEDOR itemAntes, USUARIO usuario)
        {
            try
            {
                // Checa endereço
                if (String.IsNullOrEmpty(item.FORM_NM_ENDERECO))
                {
                    item.FORM_NM_ENDERECO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_BAIRRO))
                {
                    item.FORN_NM_BAIRRO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_CIDADE))
                {
                    item.FORN_NM_CIDADE = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NR_CEP))
                {
                    item.FORN_NR_CEP = "-";
                }
                if (item.UF_CD_ID == null)
                {
                    item.UF_CD_ID = 28;
                }
                item.TIPO_PESSOA = null;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditFORN",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<FORNECEDOR>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<FORNECEDOR>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(FORNECEDOR item, FORNECEDOR itemAntes)
        {
            try
            {
                // Checa endereço
                if (String.IsNullOrEmpty(item.FORM_NM_ENDERECO))
                {
                    item.FORM_NM_ENDERECO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_BAIRRO))
                {
                    item.FORN_NM_BAIRRO = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NM_CIDADE))
                {
                    item.FORN_NM_CIDADE = "-";
                }
                if (String.IsNullOrEmpty(item.FORN_NR_CEP))
                {
                    item.FORN_NR_CEP = "-";
                }
                item.TIPO_PESSOA = null;

                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(FORNECEDOR item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                //if (item..Count > 0 || item.EQUIPAMENTO_MANUTENCAO.Count > 0)
                //{
                //    return 1;
                //}
               
                // Acerta campos
                item.FORN_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelFORN",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<FORNECEDOR>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(FORNECEDOR item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.FORN_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = usuario.ASSI_CD_ID,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatFORN",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<FORNECEDOR>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TIPO_PESSOA> GetAllTiposPessoa()
        {
            List<TIPO_PESSOA> lista = _baseService.GetAllTiposPessoa();
            return lista;
        }

        public FORNECEDOR_CONTATO GetContatoById(Int32 id)
        {
            FORNECEDOR_CONTATO lista = _baseService.GetContatoById(id);
            return lista;
        }

        public Int32 ValidateEditContato(FORNECEDOR_CONTATO item)
        {
            try
            {
                // Persiste
                return _baseService.EditContato(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateCreateContato(FORNECEDOR_CONTATO item)
        {
            try
            {
                // Persiste
                item.FOCO_IN_ATIVO = 1;
                Int32 volta = _baseService.CreateContato(item);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TIPO_MENSAGEM> GetAllTiposMensagem()
        {
            List<TIPO_MENSAGEM> lista = _baseService.GetAllTiposMensagem();
            return lista;
        }

        public FORNECEDOR_MENSAGEM GetMensagemById(Int32 id)
        {
            FORNECEDOR_MENSAGEM lista = _baseService.GetMensagemById(id);
            return lista;
        }

        public Int32 ValidateEditMensagem(FORNECEDOR_MENSAGEM item)
        {
            try
            {
                // Persiste
                return _baseService.EditMensagem(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateCreateMensagem(FORNECEDOR_MENSAGEM item, USUARIO usuario)
        {
            try
            {
                // Completa registro
                item.FOME_IN_ATIVO = 1;

                // Monta log
                String registro = item.FORNECEDOR.FORN_NM_NOME + " - " + item.TIPO_MENSAGEM.TIME_NM_NOME + " - " + item.FOME_DT_ENVIO.ToShortDateString() + " - " + item.FOME_DS_TEXTO;
                LOG log = new LOG();
                log.LOG_DT_DATA = DateTime.Now;
                log.LOG_NM_OPERACAO = "FornMSG";
                log.ASSI_CD_ID = usuario.ASSI_CD_ID;
                log.LOG_TX_REGISTRO = registro;
                log.LOG_IN_ATIVO = 1;

                // Processa e-mail
                if (item.TIME_CD_ID == 1)
                {
                    // Recupera template e-mail
                    String header = _baseService.GetTemplate("MSGFOR").TEMP_TX_CABECALHO;
                    String body = _baseService.GetTemplate("MSGFOR").TEMP_TX_CORPO;
                    String data = _baseService.GetTemplate("MSGFOR").TEMP_TX_DADOS;

                    // Prepara dados do e-mail  
                    header = header.Replace("{Nome}", item.FORNECEDOR.FORN_NM_NOME);
                    body = body.Replace("{Texto}", item.FOME_DS_TEXTO);
                    body = body.Replace("{Condominio}", item.USUARIO.ASSINANTE.ASSI_NM_NOME);
                    data = data.Replace("{Data}", item.FOME_DT_ENVIO.ToLongDateString());
                    data = data.Replace("{Usuario}", item.USUARIO.USUA_NM_NOME);

                    // Concatena
                    String emailBody = header + body + data;

                    // Prepara e-mail e enviar
                    CONFIGURACAO conf = _baseService.CarregaConfiguracao(usuario.ASSI_CD_ID);
                    Email mensagem = new Email();
                    mensagem.ASSUNTO = "Mensagem para Fornecedor - " + item.FORNECEDOR.FORN_NM_NOME;
                    mensagem.CORPO = emailBody;
                    mensagem.DEFAULT_CREDENTIALS = false;
                    mensagem.EMAIL_DESTINO = item.FORNECEDOR.FORN_NM_EMAIL;
                    mensagem.EMAIL_EMISSOR = conf.CONF_NM_EMAIL_EMISSOO;
                    mensagem.ENABLE_SSL = true;
                    mensagem.NOME_EMISSOR = usuario.USUA_NM_NOME;
                    mensagem.PORTA = conf.CONF_NM_PORTA_SMTP;
                    mensagem.PRIORIDADE = System.Net.Mail.MailPriority.High;
                    mensagem.SENHA_EMISSOR = conf.CONF_NM_SENHA_EMISSOR;
                    mensagem.SMTP = conf.CONF_NM_HOST_SMTP;

                    // Envia e-mail
                    Int32 voltaMail = CommunicationPackage.SendEmail(mensagem);
                }
                else if (item.TIME_CD_ID == 2)
                {
                    // Processa SMS

                }
                else
                {
                    // Processa WhatsApp
                }

                // Persiste
                item.FOME_IN_ENVIADO = 1;
                Int32 volta = _baseService.CreateMensagem(item);             
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EntitiesServices.Model;
using ERP_Condominio.ViewModels;

namespace MvcMapping.Mappers
{
    public class ViewModelToDomainMappingProfiles : Profile
    {
        public ViewModelToDomainMappingProfiles()
        {
            CreateMap<UsuarioViewModel, USUARIO>();
            CreateMap<UsuarioLoginViewModel, USUARIO>();
            CreateMap<LogViewModel, LOG>();
            CreateMap<ConfiguracaoViewModel, CONFIGURACAO>();
            CreateMap<NoticiaViewModel, NOTICIA>();
            CreateMap<NoticiaComentarioViewModel, NOTICIA_COMENTARIO>();
            CreateMap<NotificacaoViewModel, NOTIFICACAO>();
            CreateMap<TipoPessoaViewModel, TIPO_PESSOA>();
            CreateMap<TemplateViewModel, TEMPLATE>();
            CreateMap<TarefaViewModel, TAREFA>();
            CreateMap<CategoriaAgendaViewModel, CATEGORIA_AGENDA>();
            CreateMap<AgendaViewModel, AGENDA>();
            CreateMap<TarefaAcompanhamentoViewModel, TAREFA_ACOMPANHAMENTO>();
            CreateMap<TelefoneViewModel, TELEFONE>();
            CreateMap<GrupoViewModel, GRUPO>();
            CreateMap<SubgrupoViewModel, SUBGRUPO>();
            CreateMap<CategoriaAgendaViewModel, CATEGORIA_AGENDA>();
            CreateMap<CategoriaNotificacaoViewModel, CATEGORIA_NOTIFICACAO>();
            CreateMap<CategoriaTelefoneViewModel, CATEGORIA_TELEFONE>();
            CreateMap<CategoriaUsuarioViewModel, CATEGORIA_USUARIO>();
            CreateMap<TipoTarefaViewModel, TIPO_TAREFA>();
            CreateMap<CargoViewModel, CARGO>();
            CreateMap<TipoUnidadeViewModel, TIPO_UNIDADE>();
            CreateMap<TorreViewModel, TORRE>();
            CreateMap<UnidadeViewModel, UNIDADE>();
            CreateMap<VagaViewModel, VAGA>();

        }
    }
}
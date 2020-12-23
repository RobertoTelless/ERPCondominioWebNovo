using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices.Interfaces;
using EntitiesServices.Model;
using System.Globalization;
using EntitiesServices.Work_Classes;
using ERP_Condominio_Presentation.App_Start;
using AutoMapper;
using ERP_Condominio.ViewModels;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ERP_Condominio_Presentation.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeAppService baseApp;
        private readonly ILogAppService logApp;
        private String msg;
        private Exception exception;
        UNIDADE objeto = new UNIDADE();
        UNIDADE objetoAntes = new UNIDADE();
        List<UNIDADE> listaMaster = new List<UNIDADE>();
        String extensao;

        public UnidadeController(IUnidadeAppService baseApps, ILogAppService logApps)
        {
            baseApp = baseApps;
            logApp = logApps;
        }

        public ActionResult Voltar()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("CarregarBase", "BaseAdmin");
        }

        public ActionResult VoltarGeral()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("CarregarBase", "BaseAdmin");
        }

        public ActionResult VoltarBase()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("MontarTelaUnidade");
        }

        [HttpGet]
        public ActionResult MontarTelaUnidade()
        {
            // Verifica se tem usuario logado
            USUARIO usuario = new USUARIO();
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];

                // Verfifica permissão
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN" || usuario.PERFIL.PERF_SG_SIGLA != "CON")
                {
                    Session["MensUnidade"] = 2;
                    return RedirectToAction("CarregarBase", "BaseAdmin");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];

            // Carrega listas
            if ((List<UNIDADE>)Session["ListaUnidade"] == null)
            {
                listaMaster = baseApp.GetAllItens(idAss);
                Session["ListaUnidade"] = listaMaster;
            }
            ViewBag.Listas = (List<UNIDADE>)Session["ListaUnidade"];
            ViewBag.Title = "Unidades";
            ViewBag.Cats = new SelectList(baseApp.GetAllTipos(idAss), "TIUN_CD_ID", "TIUN_NM_NOME");

            // Indicadores
            ViewBag.Inids = ((List<UNIDADE>)Session["ListaUnidade"]).Count;
            ViewBag.Perfil = usuario.PERFIL.PERF_SG_SIGLA;

            // Mensagem
            if ((Int32)Session["MensUnidade"] == 1)
            {
                ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0016", CultureInfo.CurrentCulture));
            }
            if ((Int32)Session["MensUnidade"] == 2)
            {
                ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0011", CultureInfo.CurrentCulture));
            }

            // Abre view
            Session["MensUnidade"] = 0;
            objeto = new UNIDADE();
            return View(objeto);
        }

        public ActionResult RetirarFiltroUnidade()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            Session["ListaUnidade"] = null;
            listaMaster = new List<UNIDADE>();
            return RedirectToAction("MontarTelaUnidade");
        }

        public ActionResult MostrarTudoUnidade()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            listaMaster = baseApp.GetAllItensAdm(idAss);
            Session["ListaUnidade"] = listaMaster;
            return RedirectToAction("MontarTelaUnidade");
        }

        [HttpGet]
        public ActionResult IncluirUnidade()
        {
            USUARIO usuario = new USUARIO();
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];

                // Verfifica permissão
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN" || usuario.PERFIL.PERF_SG_SIGLA != "CON")
                {
                    Session["MensUnidade"] = 2;
                    return RedirectToAction("MontarTelaTelefone", "Telefone");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];

            // Prepara listas
            ViewBag.Cats = new SelectList(baseApp.GetAllTipos(idAss), "TIUN_CD_ID", "TIUN_NM_NOME");

            // Prepara view
            UNIDADE item = new UNIDADE();
            UnidadeViewModel vm = Mapper.Map<UNIDADE, UnidadeViewModel>(item);
            vm.ASSI_CD_ID = idAss;
            vm.UNID_IN_ATIVO = 1;
            vm.TORR_CD_ID = 1;
            vm.UNID_IN_ALUGADA = 0;
            vm.UNID_NM_NOME_TORRE = "Torre Única";
            return View(vm);
        }

        [HttpPost]
        public ActionResult IncluirUnidade(UnidadeViewModel vm)
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            ViewBag.Cats = new SelectList(baseApp.GetAllTipos(idAss), "TIUN_CD_ID", "TIUN_NM_NOME");
            if (ModelState.IsValid)
            {
                try
                {
                    // Executa a operação
                    UNIDADE item = Mapper.Map<UnidadeViewModel, UNIDADE>(vm);
                    USUARIO usuarioLogado = (USUARIO)Session["UserCredentials"];
                    Int32 volta = baseApp.ValidateCreate(item, 1, usuarioLogado);

                    // Verifica retorno

                    // Sucesso
                    listaMaster = new List<UNIDADE>();
                    Session["ListaUnidade"] = null;
                    Session["IdUnidadeVolta"] = item.UNID_CD_ID;
                    Session["Unidade"] = item;
                    Session["MensUnidade"] = 0;
                   return RedirectToAction("IncluirUnidade");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult EditarUnidade(Int32 id)
        {
            USUARIO usuario = new USUARIO();
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];

                // Verfifica permissão
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN" || usuario.PERFIL.PERF_SG_SIGLA != "CON")
                {
                    Session["MensUnidade"] = 2;
                    return RedirectToAction("MontarTelaUnidade", "Unidade");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];

            // Prepara view
            ViewBag.Cats = new SelectList(baseApp.GetAllTipos(idAss), "TIUN_CD_ID", "TIUN_NM_NOME");

            UNIDADE item = baseApp.GetItemById(id);
            objetoAntes = item;
            Session["Unidade"] = item;
            Session["IdVolta"] = id;
            UnidadeViewModel vm = Mapper.Map<UNIDADE, UnidadeViewModel>(item);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditarUnidade(UnidadeViewModel vm)
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            ViewBag.Cats = new SelectList(baseApp.GetAllTipos(idAss), "TIUN_CD_ID", "TIUN_NM_NOME");
            if (ModelState.IsValid)
            {
                try
                {
                    // Executa a operação
                    USUARIO usuarioLogado = (USUARIO)Session["UserCredentials"];
                    UNIDADE item = Mapper.Map<UnidadeViewModel, UNIDADE>(vm);
                    Int32 volta = baseApp.ValidateEdit(item, objetoAntes, usuarioLogado);

                    // Verifica retorno

                    // Sucesso
                    listaMaster = new List<UNIDADE>();
                    Session["ListaUnidade"] = null;
                    Session["MensUnidade"] = 0;
                    return RedirectToAction("MontarTelaUnidade");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult DesativarTelefone(Int32 id)
        {
            // Verifica se tem usuario logado
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            USUARIO usuario = new USUARIO();
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];
                // Verfifica permissão
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN" || usuario.PERFIL.PERF_SG_SIGLA != "CON")
                {
                    Session["MensUnidade"] = 2;
                    return RedirectToAction("MontarTelaUnidade", "Unidade");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }

            // Executar
            UNIDADE item = baseApp.GetItemById(id);
            objetoAntes = (UNIDADE)Session["Unidade"];
            item.UNID_IN_ATIVO = 0;
            Int32 volta = baseApp.ValidateDelete(item, usuario);
            listaMaster = new List<UNIDADE>();
            Session["ListaUnidade"] = null;
            return RedirectToAction("MontarTelaUnidade");
        }

        [HttpGet]
        public ActionResult ReativarUnidade(Int32 id)
        {
            // Verifica se tem usuario logado
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            USUARIO usuario = new USUARIO();
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];
                // Verfifica permissão
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN" || usuario.PERFIL.PERF_SG_SIGLA != "CON")
                {
                    Session["MensUnidade"] = 2;
                    return RedirectToAction("MontarTelaUnidade", "Unidade");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }

            // Executar
            UNIDADE item = baseApp.GetItemById(id);
            objetoAntes = (UNIDADE)Session["Unidade"];
            item.UNID_IN_ATIVO = 1;
            Int32 volta = baseApp.ValidateReativar(item, usuario);
            listaMaster = new List<UNIDADE>();
            Session["ListaUnidade"] = null;
            return RedirectToAction("MontarTelaUnidade");
        }

        [HttpGet]
        public ActionResult DashboardUnidade(Int32 id)
        {
            // Verifica se tem usuario logado
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            USUARIO usuario = new USUARIO();
            if ((USUARIO)Session["UserCredentials"] != null)
            {
                usuario = (USUARIO)Session["UserCredentials"];
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            UNIDADE item = baseApp.GetItemById(id);
            objetoAntes = item;
            UnidadeViewModel vm = Mapper.Map<UNIDADE, UnidadeViewModel>(item);
            return View(vm);
        }
    }
}
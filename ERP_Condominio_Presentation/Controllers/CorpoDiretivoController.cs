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
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Canducci.Zip;

namespace ERP_Condominio_Presentation.Controllers
{
    public class CorpoDiretivoController : Controller
    {
        private readonly ICorpoDiretivoAppService baseApp;
        private readonly ILogAppService logApp;
        private readonly IUsuarioAppService usuApp;

        private String msg;
        private Exception exception;
        CORPO_DIRETIVO objeto = new CORPO_DIRETIVO();
        CORPO_DIRETIVO objetoAntes = new CORPO_DIRETIVO();
        List<CORPO_DIRETIVO> listaMaster = new List<CORPO_DIRETIVO>();
        LOG objLog = new LOG();
        LOG objLogAntes = new LOG();
        List<LOG> listaMasterLog = new List<LOG>();
        String extensao;

        public CorpoDiretivoController(ICorpoDiretivoAppService baseApps, ILogAppService logApps, IUsuarioAppService usuApps)
        {
            baseApp = baseApps; ;
            logApp = logApps;
            usuApp = usuApps;
        }

        [HttpGet]
        public ActionResult Index()
        {
            CORPO_DIRETIVO item = new CORPO_DIRETIVO();
            CorpoDiretivoViewModel vm = Mapper.Map<CORPO_DIRETIVO, CorpoDiretivoViewModel>(item);
            return View(vm);
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

        [HttpGet]
        public ActionResult MontarTelaCorpoDiretivo()
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
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];


            // Carrega listas
            if ((List<CORPO_DIRETIVO>)Session["ListaCD"] == null)
            {
                listaMaster = baseApp.GetAllItens(idAss);
                listaMaster = listaMaster.Where(p => p.ASSI_CD_ID == idAss & p.CODI_IN_ATIVO == 1).ToList();
            }

            Session["ListaCD"] = listaMaster;
            ViewBag.Listas = listaMaster;
            ViewBag.Title = "CorpoDiretivo";
            ViewBag.Perfil = usuario.PERFIL.PERF_SG_SIGLA;

            // Indicadores

            // Mensagem
            if ((Int32)Session["MensCD"] == 2)
            {
                ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0011", CultureInfo.CurrentCulture));
            }

            // Abre view
            Session["MensCD"] = 0;
            objeto = new CORPO_DIRETIVO();
            return View(objeto);
        }

        [HttpGet]
        public ActionResult MontarTelaCorpoDiretivoHistorico()
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
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];


            // Carrega listas
            if ((List<CORPO_DIRETIVO>)Session["ListaCD"] == null)
            {
                listaMaster = baseApp.GetAllItensAdm(idAss);
            }

            Session["ListaCD"] = listaMaster;
            ViewBag.Listas = listaMaster;
            ViewBag.Title = "CorpoDiretivo";
            ViewBag.Perfil = usuario.PERFIL.PERF_SG_SIGLA;

            // Indicadores

            // Mensagem

            // Abre view
            Session["MensCD"] = 0;
            objeto = new CORPO_DIRETIVO();
            return View(objeto);
        }

       [HttpGet]
        public ActionResult IncluirCorpoDiretivo()
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
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN")
                {
                    Session["MensCD"] = 2;
                    return RedirectToAction("MontarTelaCorpoDiretivo");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }

            // Prepara listas
            Int32 idAss = (Int32)Session["IdAssinante"];
            ViewBag.Funcoes = new SelectList(baseApp.GetAllFuncoes(idAss), "FUCO_CD_ID", "FUCO_NM_NOME");
            ViewBag.Perfil = usuario.PERFIL.PERF_SG_SIGLA;
            List<USUARIO> usuarios = usuApp.GetAllItens(idAss).Where(p => p.PERF_CD_ID == 6 & p.USUA_IN_PROPRIETARIO == 1).ToList();
            ViewBag.Usuarios = new SelectList(usuarios, "USUA_CD_ID", "USUA_NM_NOME");

            // Prepara view 
            CONFIGURACAO conf = baseApp.CarregaConfiguracao(usuario.ASSI_CD_ID);
            CORPO_DIRETIVO item = new CORPO_DIRETIVO();
            CorpoDiretivoViewModel vm = Mapper.Map<CORPO_DIRETIVO, CorpoDiretivoViewModel>(item);
            vm.CODI_DT_CADASTRO = DateTime.Today;
            vm.CODI_IN_ATIVO = 1;
            vm.ASSI_CD_ID = idAss;
            vm.USUA_CD_ID = usuario.USUA_CD_ID;
            vm.CODI_DT_INICIO = DateTime.Today.Date;
            vm.CODI_DT_FINAL = DateTime.Today.Date.AddDays(conf.CONF_NR_CORPO_DIRETIVO_PERIODO.Value);
            return View(vm);
        }

        [HttpPost]
        public ActionResult IncluirCorpoDiretivo(CorpoDiretivoViewModel vm)
        {
            var result = new Hashtable();

            Int32 idAss = (Int32)Session["IdAssinante"];
            ViewBag.Funcoes = new SelectList(baseApp.GetAllFuncoes(idAss), "FUCO_CD_ID", "FUCO_NM_NOME");
            List<USUARIO> usuarios = usuApp.GetAllItens(idAss).Where(p => p.PERF_CD_ID == 6 & p.USUA_IN_PROPRIETARIO == 1).ToList();
            ViewBag.Usuarios = new SelectList(usuarios, "USUA_CD_ID", "USUA_NM_NOME");
            if (ModelState.IsValid)
            {
                try
                {
                    // Executa a operação
                    CORPO_DIRETIVO item = Mapper.Map<CorpoDiretivoViewModel, CORPO_DIRETIVO>(vm);
                    USUARIO usuario = (USUARIO)Session["UserCredentials"];
                    Int32 volta = baseApp.ValidateCreate(item, usuario);

                    // Verifica retorno
                    if (volta == 1)
                    {
                        ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0038", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 2)
                    {
                        ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0039", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 4)
                    {
                        ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0040", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 5)
                    {
                        ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0041", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 6)
                    {
                        ModelState.AddModelError("", ERP_Condominio_Resources.ResourceManager.GetString("M0042", CultureInfo.CurrentCulture));
                        return View(vm);
                    }

                    // Sucesso
                    listaMaster = new List<CORPO_DIRETIVO>();
                    Session["ListaCD"] = null;
                    Session["MensCD"] = 0;
                    return RedirectToAction("MontarTelaCorpoDiretivo");

                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    result.Add("error", ex.Message);
                    return Json(result);
                }
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult ExcluirCorpoDiretivo(Int32 id)
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
                if (usuario.PERFIL.PERF_SG_SIGLA != "ADM" || usuario.PERFIL.PERF_SG_SIGLA != "SIN")
                {
                    Session["MensCD"] = 2;
                    return RedirectToAction("MontarTelaCorpoDiretivo");
                }
            }
            else
            {
                return RedirectToAction("Login", "ControleAcesso");
            }

            // Executar
            CORPO_DIRETIVO item = baseApp.GetItemById(id);
            objetoAntes = (CORPO_DIRETIVO)Session["CD"];
            item.CODI_IN_ATIVO = 0;
            item.CODI_DT_SAIDA_REAL = DateTime.Today.Date;
            Int32 volta = baseApp.ValidateDelete(item, usuario);
            listaMaster = new List<CORPO_DIRETIVO>();
            Session["ListaCD"] = null;
            return RedirectToAction("MontarTelaCorpoDiretivo");
        }

        public ActionResult VoltarBaseCorpoDiretivo()
        {
            // Verificar login
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("MontarTelaCorpoDiretivo");
        }

        [HttpGet]
        public ActionResult VerMembroCorpoDiretivo(Int32 id)
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Session["IdVolta"] = id;
            Session["Ver"] = 1;
            CORPO_DIRETIVO item = baseApp.GetItemById(id);
            CorpoDiretivoViewModel vm = Mapper.Map<CORPO_DIRETIVO, CorpoDiretivoViewModel>(item);
            return View(vm);
        }

    }
}
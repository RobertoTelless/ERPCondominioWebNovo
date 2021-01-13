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

        private String msg;
        private Exception exception;
        CORPO_DIRETIVO objeto = new CORPO_DIRETIVO();
        CORPO_DIRETIVO objetoAntes = new CORPO_DIRETIVO();
        List<CORPO_DIRETIVO> listaMaster = new List<CORPO_DIRETIVO>();
        LOG objLog = new LOG();
        LOG objLogAntes = new LOG();
        List<LOG> listaMasterLog = new List<LOG>();
        String extensao;

        public CorpoDiretivoController(ICorpoDiretivoAppService baseApps, ILogAppService logApps)
        {
            baseApp = baseApps; ;
            logApp = logApps;
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
        public ActionResult MontarTelaQuadroSocietario()
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





    }
}
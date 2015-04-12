using HeroisDoCancer.ContextoDados;
using HeroisDoCancer.Repositorios;
using HeroisDoCancer.Services;
using HeroisDoCancer.ViewModels;
using HeroisDoCancer.WebUtils;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HeroisDoCancer.Controllers
{
    public class EventoController : Controller
    {
        private EventoRepositorio eventoRepo;
        private VoluntarioService voluntarioSer;
        private SessionWrapper session;

        public EventoController()
        {
            var contexto = new ContextoEmMemoria();

            this.eventoRepo = new EventoRepositorio(contexto);
            this.voluntarioSer = new VoluntarioService(contexto);
            this.session = new SessionWrapper(new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var eventos = this.eventoRepo.ObterTodosConfirmados();
            var vm = new PesquisaEventoViewModel
            {
                Eventos = eventos,
                CriarInstancia = evento => new ItemEventoViewModel 
                {
                    Evento = evento,
                    UsuarioLogadoPodeParticipar = () => 
                    {
                        var voluntarion = this.session.Voluntario;
                        return voluntarion != null && this.voluntarioSer.PodeParticipar(this.session.Voluntario, evento);
                    }
                }
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Participar(Int32 idEvento)
        {
            if (idEvento <= 0)
                throw new HttpException((Int32)HttpStatusCode.BadRequest, "Bad Request");

            var result = new RespostaOperacaoViewModel();

            var evento = this.eventoRepo.GetById(idEvento);

            try
            {
                this.voluntarioSer.Participar(session.Voluntario, evento);

                result.Data = new
                {
                    TotalParticipantesRestantes = evento.NroParticipantesRestantes,
                    Situacao = evento.TipoSituacao
                };
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = ex.Message;
            }

            return Json(result);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize]
        [HttpPut]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using HeroisDoCancer.ContextoDados;
using HeroisDoCancer.Repositorios;
using HeroisDoCancer.ViewModels;
using System.Web.Mvc;

namespace HeroisDoCancer.Controllers
{
    public class EventoController : Controller
    {
        private EventoRepositorio eventoRepo;

        public EventoController()
        {
            this.eventoRepo = new EventoRepositorio(new ContextoEmMemoria());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var eventos = this.eventoRepo.ObterTodosConfirmados();
            var vm = new PesquisaEventoViewModel 
            {
                Eventos = eventos
            };

            return View(vm);
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
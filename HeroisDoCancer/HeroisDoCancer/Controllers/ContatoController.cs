using HeroisDoCancer.ContextoDados;
using HeroisDoCancer.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroisDoCancer.Controllers
{
    public class ContatoController : Controller
    {
        private HospitalRepositorio hospitalRepo;

        public ContatoController()
        {
            var contexto = new ContextoEmMemoria();

            this.hospitalRepo = new HospitalRepositorio(contexto);
        }

        public ActionResult Index()
        {
            var hospitais = this.hospitalRepo.ObterTodos();

            return View(hospitais);
        }

    }
}
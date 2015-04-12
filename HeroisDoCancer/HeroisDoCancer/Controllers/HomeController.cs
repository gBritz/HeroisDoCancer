using HeroisDoCancer.ContextoDados;
using HeroisDoCancer.Models;
using HeroisDoCancer.ViewModels;
using HeroisDoCancer.WebUtils;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HeroisDoCancer.Controllers
{
    public class HomeController : Controller
    {
        private readonly SessionWrapper session;
        private readonly IContextoDados context;

        public HomeController()
        {
            this.session = new SessionWrapper(new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session));
            this.context = new ContextoEmMemoria();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Voluntario voluntario)
        {
            if (voluntario == null)
                throw new HttpException((Int32)HttpStatusCode.BadRequest, "Bad Request");
            
            var result = new RespostaOperacaoViewModel
            {
                Mensagem = "Logado com sucesso"
            };

            var mensagemError = String.Empty;
            if (!ValidoParaLogin(voluntario, ref mensagemError))
            {
                result.Erro = true;
                result.Mensagem = mensagemError;
            }
            else
            {
                FormsAuthentication.SetAuthCookie(voluntario.Nome, true);

                var user = context.Voluntarios.First(v => v.Login.Equals(voluntario.Login, StringComparison.InvariantCultureIgnoreCase));
                result.Data = new 
                { 
                    NomeUsuario = user.Nome,
                    Foto = user.Foto
                };

                session.Voluntario = user;
            }
            
            return Json(result);
        }

        [HttpPost]
        public void Logout()
        {
            session.Close();
            FormsAuthentication.SignOut();
        }

        [ChildActionOnly]
        public ActionResult ModalLogin()
        {
            return View("_Login", this.session.Voluntario);
        }

        private Boolean ValidoParaLogin(Voluntario voluntario, ref String erro)
        {
            erro = String.Empty;

            if (User.Identity.IsAuthenticated)
            {
                erro = "Usuário já logado.";
            }
            else if (String.IsNullOrEmpty(voluntario.Login) || String.IsNullOrEmpty(voluntario.Senha))
            {
                erro = "Login e senha são necessários.";
            }
            else if (!context.Voluntarios.Any(v => v.Login.Equals(voluntario.Login, StringComparison.InvariantCultureIgnoreCase) && v.Senha.Equals(voluntario.Senha, StringComparison.InvariantCultureIgnoreCase)))
            {
                erro = "Voluntário não encontrado.";
            }

            return String.IsNullOrEmpty(erro);
        }
    }
}
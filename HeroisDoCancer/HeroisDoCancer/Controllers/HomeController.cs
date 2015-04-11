using HeroisDoCancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroisDoCancer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public void HospitalMock()
        {
            List<Hospital> lstHospitais = new List<Hospital>();

            lstHospitais.Add(new Hospital()
            {
                Id = 1,
                Nome = "Hospital de Clínicas UFRGS",
                Endereco = "Rua Ramiro Barcelos, 2350",
                latitude = "-30.039119",
                longitude = "-51.207156",
                Site = "http://www.hcpa.ufrgs.br",
                Telefone = "(51)3359-8000"
            });

            lstHospitais.Add(new Hospital()
            {
                Id = 2,
                Nome = "Hospital São Lucas da PUC-RS",
                Endereco = "Av. Ipiranga, 6690",
                latitude = "-30.0555189",
                longitude = "-51.1704967",
                Site = "http://www.hospitalsaolucas.pucrs.br",
                Telefone = "(51)3320-3000"
            });

            lstHospitais.Add(new Hospital()
            {
                Id = 3,
                Nome = "Hospital Fêmina S/A (Unacon)",
                Endereco = "Rua Mostardeiro, 17",
                latitude = "-30.029233",
                longitude = "-51.206919",
                Site = "http://www.femina.com.br",
                Telefone = "(51)3314-5200"
            });

            lstHospitais.Add(new Hospital()
            {
                Id = 4,
                Nome = "Complexo Hospitalar Santa Casa",
                Endereco = "Rua Professor Annes Dias, 295",
                latitude = "-30.029761",
                longitude = "-51.220184",
                Site = "http://www.santacasa.org.br/pt",
                Telefone = "(51)3214-8000"
            });

            lstHospitais.Add(new Hospital()
            {
                Id = 5,
                Nome = "Hospital Nossa Senhora da Conceição S/A",
                Endereco = "Av. Francisco Trein, 596",
                latitude = "-30.015932",
                longitude = "-51.158867",
                Site = "http://www.ghc.com.br/default.asp?idMenu=unidades_hnsc",
                Telefone = "(51)3357-2000"
            });

        }

        public void VoluntarioMock()
        {
            var lst = new List<Voluntario>();

            lst.Add(new Voluntario
            {
                Id = 1,
                Nome = "João da Silva",
                Email = "joaodasilva@gmail.com",
                Eventos = new List<Evento>(),
                Senha = "12345",
                Foto = "1.jpg"
            });
        }

        public void ComentarioMock()
        {
            List<Comentario> lst = new List<Comentario>();

            lst.Add(new Comentario()
            {
                Id = 1,
                Nome = "Maria da Silva",
                Voluntario = null,
                Evento = null,
                Descricao = "Minutos antes de eu passar pela minha primeira quimioterapia, uma voluntária veio até mim, segurou forte na minha mão e disse: ‘vai dar tudo certo’. Aquilo me deu uma força enorme. A partir daquele momento, senti que tudo ia realmente dar certo."

            });
            lst.Add(new Comentario()
            {
                Id = 2,
                Nome = "João da Silva",
                Voluntario = null,
                Evento = null,
                Descricao = "Fiquei muito feliz ao receber a visita daquelas pessoas que vieram ao hospital e leram várias histórias legais."
            });

        }

        public void EventoMock()
        {
            var lst = new List<Evento>();
            
            lst.Add(new Evento
            {
                Id = 1,
                NroMaximoParticipantes = 5,               
                DataHora = DateTime.Now.AddDays(2),
                Descricao = "Aniversário do Joãozinho",
                Comentarios = null,
                Depoimentos = null,
                Fotos = null,
                IdHospital = 1,
                Participantes = null,
                TipoSituacao = TipoSituacaoEnum.Confirmado
            });
        }
    }
}

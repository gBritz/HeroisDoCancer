using HeroisDoCancer.Models;
using HeroisDoCancer.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroisDoCancer.Services
{
    public class VoluntarioService
    {
        private IContextoDados contexto;

        public VoluntarioService(IContextoDados contexto)
        {
            if (contexto == null)
                throw new ArgumentNullException("contexto");

            this.contexto = contexto;
        }

        public void Cadastra(Voluntario voluntario)
        {
            if (voluntario == null)
                throw new ArgumentNullException("voluntario");

            var campos = ValidarCampos(voluntario);
            if (campos.Count > 0)
                throw new CamposInvalidosException(campos);

            if (ExistePeloNome(voluntario))
                throw new Exception("Nome de voluntario já existe.");

            this.contexto.Adiciona(voluntario);
            this.contexto.Publica();
        }

        public Boolean PodeParticipar(Voluntario voluntario, Evento evento)
        {
            if (voluntario == null)
                throw new ArgumentNullException("voluntario");

            if (evento == null)
                throw new ArgumentNullException("evento");

            var result = true;

            if (ExisteParticipanteNo(voluntario, evento))
                result = false;

            else if (evento.NroParticipantesRestantes == evento.NroMaximoParticipantes)
                result = false;

            return result;
        }

        public Boolean ExisteParticipanteNo(Voluntario participante, Evento evento)
        {
            return this.contexto.Eventos
                .Any(ev => ev.Id == evento.Id && ev.Participantes.Any(p => p.Id == participante.Id));
        }

        public virtual Boolean ExistePeloNome(Voluntario voluntario)
        {
            return this.contexto.Voluntarios.Any(v => v.Nome.Equals(voluntario.Nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual IDictionary<String, String[]> ValidarCampos(Voluntario voluntario)
        {
            var campos = new Dictionary<String, String[]>();

            if (String.IsNullOrEmpty(voluntario.Nome))
                campos.Add("Nome", new []{ "Campo obrigatório." });

            if (String.IsNullOrEmpty(voluntario.Senha))
                campos.Add("Senha", new[] { "Campo obrigatório." });

            if (String.IsNullOrEmpty(voluntario.Email))
                campos.Add("Email", new[] { "Campo obrigatório." });

            return campos;
        }
    }
}
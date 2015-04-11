using HeroisDoCancer.Models;
using System;
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

        public void Cadastra(VoluntarioModel voluntario)
        {
            if (voluntario == null)
                throw new ArgumentNullException("voluntario");

            if (!ValidoCadastro(voluntario))
                throw new Exception("Dados incompletos.");

            if (ExistePeloNome(voluntario))
                throw new Exception("Nome de voluntario já existe.");

            this.contexto.Adiciona(voluntario);
            this.contexto.Publica();
        }

        public virtual Boolean ExistePeloNome(VoluntarioModel voluntario)
        {
            return this.contexto.Voluntarios.Any(v => v.Nome.Equals(voluntario.Nome, StringComparison.InvariantCultureIgnoreCase));
        }

        protected virtual Boolean ValidoCadastro(VoluntarioModel voluntario)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
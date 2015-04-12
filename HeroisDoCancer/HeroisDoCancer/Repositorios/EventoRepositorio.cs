using HeroisDoCancer.Models;
using System;
using System.Linq;

namespace HeroisDoCancer.Repositorios
{
    public class EventoRepositorio
    {
        private IContextoDados contexto;

        public EventoRepositorio(IContextoDados contexto)
        {
            if (contexto == null)
                throw new ArgumentNullException("contexto");

            this.contexto = contexto;
        }

        public Evento GetById(Int32 id)
        {
            return this.contexto.Eventos
                .SingleOrDefault(e => e.Id == id);
        }

        public Evento[] ObterTodosConfirmados()
        {
            return this.contexto.Eventos
                .Where(e => e.TipoSituacao == TipoSituacaoEnum.Confirmado)
                .OrderByDescending(e => e.CriadoEm)
                .ToArray();
        }
    }
}
using System;
using System.Collections.Generic;

namespace HeroisDoCancer.Models
{
    public class Evento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataHora { get; set; }

        public int NroMaximoParticipantes { get; set; }

        public int NroParticipantesRestantes { get; set; }

        public DateTime CriadoEm { get; set; }

        public string Descricao { get; set; }

        public int IdHospital { get; set; }

        public Hospital Hospital { get; set; }

        public ICollection<Voluntario> Participantes { get; set; }

        public TipoSituacaoEnum TipoSituacao { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        public ICollection<Comentario> Depoimentos { get; set; }

        public ICollection<string> Fotos { get; set; }
    }
}
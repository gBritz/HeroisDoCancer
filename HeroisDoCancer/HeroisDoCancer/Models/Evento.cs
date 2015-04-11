using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Hospital Hospital { get; set; }
        public int NroMaximoParticipantes { get; set; }
        public ICollection<Voluntario> Participante { get; set; }
        public TipoSituacaoEnum TipoSituacao { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<Comentario> Depoimentos { get; set; }
        public ICollection<string> Fotos { get; set; }
    }
}
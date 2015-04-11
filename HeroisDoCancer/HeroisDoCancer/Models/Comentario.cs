using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        /// <summary>
        /// Campo necessário caso o comentário não esteja atrelado a um "Voluntário".
        /// </summary>
        public string Nome { get; set; }                
        public string Descricao { get; set; }

        public int IdVoluntario { get; set; }
        public Voluntario Voluntario { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
    }
}
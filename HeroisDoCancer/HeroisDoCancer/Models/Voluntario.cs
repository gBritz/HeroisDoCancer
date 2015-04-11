using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Voluntario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
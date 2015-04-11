using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Voluntario
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Senha { get; set; }
        string Email { get; set; }
        string Foto { get; set; }
        ICollection<Evento> Eventos { get; set; }
    }
}
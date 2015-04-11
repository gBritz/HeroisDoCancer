using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Voluntario? Voluntario { get; set; }

        //nome da pessoa que está escrevedo o comentário, caso não esteja logado.
        public string Nome { get; set; } 
    }
}
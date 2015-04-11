using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Comentario
    {
        int Id { get; set; }
        string Descricao { get; set; }        
        Voluntario Voluntario { get; set; }

        //nome da pessoa que está escrevedo o comentário, caso não esteja logado.
        string Nome { get; set; } 
    }
}
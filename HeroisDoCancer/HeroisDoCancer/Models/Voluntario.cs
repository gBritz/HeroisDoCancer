using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroisDoCancer.Models
{
    public class Voluntario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Login { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
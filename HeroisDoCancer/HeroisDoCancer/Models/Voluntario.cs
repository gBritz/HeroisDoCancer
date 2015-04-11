using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroisDoCancer.Models
{
    public class Voluntario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Email { get; set; }
        
        public string Foto { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
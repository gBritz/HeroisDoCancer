using HeroisDoCancer.Models;
using System;

namespace HeroisDoCancer.ViewModels
{
    public class ItemEventoViewModel
    {
        public Evento Evento { get; set; }

        public Func<Boolean> UsuarioLogadoPodeParticipar { get; set; }
    }
}
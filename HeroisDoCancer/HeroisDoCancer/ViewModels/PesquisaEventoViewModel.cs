using HeroisDoCancer.Models;
using System;

namespace HeroisDoCancer.ViewModels
{
    public class PesquisaEventoViewModel
    {
        public Evento[] Eventos { get; set; }

        public Func<Evento, ItemEventoViewModel> CriarInstancia { get; set; }
    }
}
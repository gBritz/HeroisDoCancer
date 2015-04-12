using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroisDoCancer.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}


using System;
using System.Collections.Generic;

#nullable disable

namespace KAM.Models
{
    public partial class Falhaakd
    {
        public int Id { get; set; }
        public string Falha { get; set; }
        public string Mensagem { get; set; }
        public string Causa { get; set; }
        public string Solucao { get; set; }
    }
}

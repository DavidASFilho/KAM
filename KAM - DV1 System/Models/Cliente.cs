using System;
using System.Collections.Generic;

#nullable disable

namespace KAM.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Cliente1 { get; set; }
        public string Responsavel { get; set; }
        public string Departamento { get; set; }
        public string TelFixo { get; set; }
        public string Cel { get; set; }
        public string Email { get; set; }
    }
}

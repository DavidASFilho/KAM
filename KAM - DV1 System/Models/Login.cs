using System;
using System.Collections.Generic;

#nullable disable

namespace KAM.Models
{
    public partial class Login
    {
        public string Usuario { get; set; }
        public int Senha { get; set; }
        public string Email { get; set; }
        public string Apelido { get; set; }
    }
}

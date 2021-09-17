using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KAM.Models
{
    public partial class Equipamento
    {
        public int Os { get; set; }
        public string Data { get; set; }
        public string Empresa { get; set; }
        [Display(Name ="Nota Fiscal")]
        public string Nf { get; set; }
        [Display(Name = "Equipamento")]
        public string Equipamento1 { get; set; }
        [Display(Name = "Número de Série")]
        public string Sn { get; set; }

    }
    
}

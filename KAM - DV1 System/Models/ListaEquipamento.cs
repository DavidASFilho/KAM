using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAM.Models
{
    public class ListaEquipamento
    {
        public List<Equipamento> Equipamento { get; set; }
        public List<SelectListItem> ListItem { get; } = new List<SelectListItem>
        {
            new SelectListItem{Text="Os", Value="Os"},
            new SelectListItem{Text="Empresa", Value="Empresa"},
            new SelectListItem{Text="Equipamento", Value="Equipamento"},
            new SelectListItem{Text="Número de Série", Value="Sn"},
            new SelectListItem{Text="Nota Fiscal", Value="Nf"},
            new SelectListItem{Text="Data", Value="Data"},
        };
        public string Campo { get; set; }
    }
}

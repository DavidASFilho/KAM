using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KAM.Models;

namespace KAM.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly assistance_koll_brContext _context;

        public EquipamentoController(assistance_koll_brContext context)
        {
            _context = context;
        }

        // GET: Equipamento
        public IActionResult Index()
        {
            try
            {
                var lastId = (from e in _context.Equipamentos
                              orderby e.Os descending
                              select e).First();
                return View(lastId);
            }
            catch (Exception)
            {
                return View();
            } 
        }

        // GET: Equipamento/Search
        public async Task<IActionResult> Search(string campo, string pesq, string ano)
        {
            ViewBag.Pesq = pesq;
            ViewBag.Ano = ano;
            var equipOrderDesc = from e in _context.Equipamentos
                                 where 
                                 e.Data.EndsWith(ano)
                                 orderby e.Os descending
                                 select e;

            if (!String.IsNullOrEmpty(pesq))
            {
                equipOrderDesc = QueryStringPesq(campo, pesq, ano);
            }
            var listaEquipamento = new ListaEquipamento
            {
                Equipamento = new(await equipOrderDesc.ToListAsync())
            };
            return View(listaEquipamento);
        }
        // GET: Equipamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos
                .FirstOrDefaultAsync(m => m.Os == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // GET: Equipamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Os,Data,Empresa,Nf,Equipamento1,Sn")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
        }

        // GET: Equipamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return View(equipamento);
        }

        // POST: Equipamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Os,Data,Empresa,Nf,Equipamento1,Sn")] Equipamento equipamento)
        {
            if (id != equipamento.Os)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentoExists(equipamento.Os))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Search));
            }
            return View(equipamento);
        }

        // GET: Equipamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos
                .FirstOrDefaultAsync(m => m.Os == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // POST: Equipamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            _context.Equipamentos.Remove(equipamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamentos.Any(e => e.Os == id);
        }
        private IOrderedQueryable<Equipamento> QueryStringPesq(string campo, string pesq, string ano)
        {
            IOrderedQueryable<Equipamento> queryStringPesq; //(IOrderedQueryable<Equipamento>)(from e in _context.Equipamentos select e);
            switch (campo)
            {
                case "Os":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(ano) &&
                                      e.Os.ToString().Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                case "Data":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                case "Empresa":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(ano) &&
                                      e.Empresa.Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                case "Equipamento":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(ano) &&
                                      e.Equipamento1.Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                case "Sn":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(ano) &&
                                      e.Sn.Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                case "Nf":
                    queryStringPesq = from e in _context.Equipamentos
                                      where
                                      e.Data.Contains(ano) &&
                                      e.Nf.Contains(pesq)
                                      orderby e.Os descending
                                      select e;
                    break;
                default:
                    queryStringPesq = from e in _context.Equipamentos
                    where
                    e.Data.EndsWith(ano)
                    orderby e.Os descending
                    select e;
                    break;
            }
            return queryStringPesq;
        }
    }
}

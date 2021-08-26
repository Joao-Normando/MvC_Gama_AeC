using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aec_gama_api.Models;
using gama_aec.Servico;


namespace gama_aec.Controllers
{
    [Logado]
    public class PaisController : Controller
    {
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await ProfissaoServico.Todos(pagina));
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pai = await ProfissaoServico.BuscaPorId(id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pai pai)
        {
            if (ModelState.IsValid)
            {
                var p = await ProfissaoServico.Salvar(pai);
                return Redirect($"/Pais/Details/{p.Id}");
            }
            return View(pai);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pai = await ProfissaoServico.BuscaPorId(id);
            if (pai == null)
            {
                return NotFound();
            }
            return View(pai);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Pai pai)
        {
            if (id != pai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await ProfissaoServico.Salvar(pai);
                return RedirectToAction(nameof(Index));
            }
            return View(pai);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pai = await ProfissaoServico.BuscaPorId(id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ProfissaoServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
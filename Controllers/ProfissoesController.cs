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
    public class ProfissoesController : Controller
    {
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await ProfissaoServico.Todos(pagina));
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Profissao = await ProfissaoServico.BuscaPorId(id);
            if (Profissao == null)
            {
                return NotFound();
            }

            return View(Profissao);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profissao Profissao)
        {
            if (ModelState.IsValid)
            {
                var p = await ProfissaoServico.Salvar(Profissao);
                return Redirect($"/Profissoes/Details/{p.Id}");
            }
            return View(Profissao);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Profissao = await ProfissaoServico.BuscaPorId(id);
            if (Profissao == null)
            {
                return NotFound();
            }
            return View(Profissao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Profissao Profissao)
        {
            if (id != Profissao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await ProfissaoServico.Salvar(Profissao);
                return RedirectToAction(nameof(Index));
            }
            return View(Profissao);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Profissao = await ProfissaoServico.BuscaPorId(id);
            if (Profissao == null)
            {
                return NotFound();
            }

            return View(Profissao);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ProfissaoServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
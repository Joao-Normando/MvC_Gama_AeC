using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gama_aec.Models;
using gama_aec.Servico;


namespace gama_aec.Controllers
{
    [Logado]
    public class CandidatosController : Controller
    {
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await CandidatoServico.TodosPaginado(pagina));
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var candidato = await CandidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                var alun = await CandidatoServico.Salvar(candidato);
                return Redirect($"/Candidatos/Details/{alun.Id}");
            }
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var candidato = await CandidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(candidato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await CandidatoServico.Salvar(candidato);
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await CandidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await CandidatoServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
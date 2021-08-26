using System.Threading.Tasks;
using gama_aec.Helpers;
using gama_aec.Models;
using gama_aec.Servico.ServicoRefatorado.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gama_aec.Controllers
{
    [Logado]
    public class MateriaisController : Controller
    {
        private readonly IMaterialHttpClientService _servico;
        public MateriaisController(IMaterialHttpClientService service)
        {
            _servico = service;
        }
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await _servico.TodosPaginado(pagina));
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var material = await _servico.BuscaPorId(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            if (ModelState.IsValid)
            {
                var mat = await _servico.Salvar(material);
                return Redirect($"/Materiais/Details/{mat.Id}");
            }
            return View(material);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var material = await _servico.BuscaPorId(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _servico.Salvar(material);
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _servico.BuscaPorId(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
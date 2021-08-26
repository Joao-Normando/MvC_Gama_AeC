using System.Threading.Tasks;
using gama_aec.Helpers;
using gama_aec.Models;
using gama_aec.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace gama_aec.Controllers
{
    [Logado]
    public class AdministradoresController : Controller
    {
        // GET: Administradores
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await AdministradorServico.TodosPaginado(pagina));
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var administrador = await AdministradorServico.BuscaPorId(id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                var adm = await AdministradorServico.Salvar(administrador);
                return Redirect($"/Administradores/Details/{adm.Id}");
            }
            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var administrador = await AdministradorServico.BuscaPorId(id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha")] Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await AdministradorServico.Salvar(administrador);
                return RedirectToAction(nameof(Index));
            }
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var administrador = await AdministradorServico.BuscaPorId(id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await AdministradorServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
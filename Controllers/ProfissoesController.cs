using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gama_aec.Models;
using Microsoft.Extensions.Logging;
using gama_aec.Servico;
using System.Diagnostics;

namespace gama_aec.Controllers
{
    public class ProfissoesController : Controller
    {
        private readonly ILogger<ProfissoesController> _logger;

        public ProfissoesController(ILogger<ProfissoesController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        { 
            ViewBag.Profissoes = await APIService.GetProfissoes();
            ViewBag.Candidatos = await APIService.GetCandidatos();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
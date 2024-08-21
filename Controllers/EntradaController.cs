using Microsoft.AspNetCore.Mvc;
using MigracionControl.Data;
using MigracionControl.Models;
using System.Linq;
using System.Web.Mvc;

namespace MigracionControl.Controllers
{
    public class EntradaController : Controller
    {
        private readonly MigracionControlContext _context;

        public EntradaController(MigracionControlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var entradas = _context.Entradas.ToList();
            return View(entradas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Entradas.Add(entrada);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(entrada);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entrada = _context.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return View(entrada);
        }

        [HttpPost]
        public IActionResult Edit(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Entradas.Update(entrada);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(entrada);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entrada = _context.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return View(entrada);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var entrada = _context.Entradas.Find(id);
            _context.Entradas.Remove(entrada);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

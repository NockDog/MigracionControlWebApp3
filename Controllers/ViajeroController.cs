using Microsoft.AspNetCore.Mvc;
using MigracionControl.Data;
using MigracionControl.Models;
using System.Linq;
using System.Web.Mvc;

namespace MigracionControl.Controllers
{
    public class ViajeroController : Controller
    {
        private readonly MigracionControlContext _context;

        public ViajeroController(MigracionControlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viajeros = _context.Viajeros.ToList();
            return View(viajeros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                _context.Viajeros.Add(viajero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(viajero);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viajero = _context.Viajeros.Find(id);
            if (viajero == null)
            {
                return NotFound();
            }
            return View(viajero);
        }

        [HttpPost]
        public IActionResult Edit(Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                _context.Viajeros.Update(viajero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(viajero);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viajero = _context.Viajeros.Find(id);
            if (viajero == null)
            {
                return NotFound();
            }
            return View(viajero);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var viajero = _context.Viajeros.Find(id);
            _context.Viajeros.Remove(viajero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

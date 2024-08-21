using Microsoft.AspNetCore.Mvc;
using MigracionControl.Data;
using MigracionControl.Models;
using System.Linq;
using System.Web.Mvc;

namespace MigracionControl.Controllers
{
    public class SalidaController : Controller
    {
        private readonly MigracionControlContext _context;

        public SalidaController(MigracionControlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var salidas = _context.Salidas.ToList();
            return View(salidas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Salidas.Add(salida);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(salida);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var salida = _context.Salidas.Find(id);
            if (salida == null)
            {
                return NotFound();
            }
            return View(salida);
        }

        [HttpPost]
        public IActionResult Edit(Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Salidas.Update(salida);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(salida);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var salida = _context.Salidas.Find(id);
            if (salida == null)
            {
                return NotFound();
            }
            return View(salida);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var salida = _context.Salidas.Find(id);
            _context.Salidas.Remove(salida);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

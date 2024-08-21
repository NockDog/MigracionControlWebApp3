using MigracionControl.Models;
using System.Linq;

namespace MigracionControl.Data
{
    public class ViajeroData
    {
        private readonly MigracionControlContext _context;

        public ViajeroData(MigracionControlContext context)
        {
            _context = context;
        }

        public IQueryable<Viajero> ObtenerViajeros()
        {
            return _context.Viajeros.AsQueryable();
        }

        public void AgregarViajero(Viajero viajero)
        {
            _context.Viajeros.Add(viajero);
            _context.SaveChanges();
        }

        public void ActualizarViajero(Viajero viajero)
        {
            _context.Viajeros.Update(viajero);
            _context.SaveChanges();
        }

        public void EliminarViajero(int id)
        {
            var viajero = _context.Viajeros.Find(id);
            if (viajero != null)
            {
                _context.Viajeros.Remove(viajero);
                _context.SaveChanges();
            }
        }
    }
}

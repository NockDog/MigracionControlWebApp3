using MigracionControl.Models;
using System.Linq;

namespace MigracionControl.Data
{
    public class SalidaData
    {
        private readonly MigracionControlContext _context;

        public SalidaData(MigracionControlContext context)
        {
            _context = context;
        }

        public IQueryable<Salida> ObtenerSalidas()
        {
            return _context.Salidas.AsQueryable();
        }

        public void AgregarSalida(Salida salida)
        {
            _context.Salidas.Add(salida);
            _context.SaveChanges();
        }

        public void ActualizarSalida(Salida salida)
        {
            _context.Salidas.Update(salida);
            _context.SaveChanges();
        }

        public void EliminarSalida(int id)
        {
            var salida = _context.Salidas.Find(id);
            if (salida != null)
            {
                _context.Salidas.Remove(salida);
                _context.SaveChanges();
            }
        }
    }
}

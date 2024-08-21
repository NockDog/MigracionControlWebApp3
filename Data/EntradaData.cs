using MigracionControl.Models;
using System.Linq;

namespace MigracionControl.Data
{
    public class EntradaData
    {
        private readonly MigracionControlContext _context;

        public EntradaData(MigracionControlContext context)
        {
            _context = context;
        }

        public IQueryable<Entrada> ObtenerEntradas()
        {
            return _context.Entradas.AsQueryable();
        }

        public void AgregarEntrada(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            _context.SaveChanges();
        }

        public void ActualizarEntrada(Entrada entrada)
        {
            _context.Entradas.Update(entrada);
            _context.SaveChanges();
        }

        public void EliminarEntrada(int id)
        {
            var entrada = _context.Entradas.Find(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
                _context.SaveChanges();
            }
        }
    }
}

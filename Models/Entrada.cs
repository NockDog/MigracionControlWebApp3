using System;

namespace MigracionControl.Models
{
    public class Entrada
    {
        public int EntradaID { get; set; }
        public int ViajeID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string LugarEntrada { get; set; }
    }
}

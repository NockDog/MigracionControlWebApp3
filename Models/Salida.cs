using System;

namespace MigracionControl.Models
{
    public class Salida
    {
        public int SalidaID { get; set; }
        public int ViajeID { get; set; }
        public DateTime FechaSalida { get; set; }
        public string LugarSalida { get; set; }
    }
}

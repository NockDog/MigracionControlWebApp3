using Xunit;
using MigracionControl.Data;
using MigracionControl.Models;
using Moq;
using System;

namespace MigracionControl.Tests
{
    public class SalidaServiceTests
    {
        [Fact]
        public void RegistrarSalida_ConDatosValidos_DebeRegistrarSalida()
        {
            // Arrange
            var mockContext = new Mock<MigracionControlContext>();
            var service = new SalidaService(mockContext.Object);
            var nuevaSalida = new Salida { ViajeID = 1, FechaSalida = DateTime.Now, LugarSalida = "Aeropuerto Internacional" };

            // Act
            service.RegistrarSalida(nuevaSalida);

            // Assert
            mockContext.Verify(m => m.Salidas.Add(It.IsAny<Salida>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}

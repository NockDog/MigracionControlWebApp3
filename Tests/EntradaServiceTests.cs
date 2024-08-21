using MigracionControl.Data;
using MigracionControl.Models;
using System;
using Xunit;


namespace MigracionControl.Tests
{
    public class EntradaServiceTests
    {
        [Fact]
        public void RegistrarEntrada_ConDatosValidos_DebeRegistrarEntrada()
        {
            // Arrange
            var mockContext = new Mock<MigracionControlContext>();
            var service = new EntradaService(mockContext.Object);
            var nuevaEntrada = new Entrada { ViajeID = 1, FechaEntrada = DateTime.Now, LugarEntrada = "Aeropuerto Internacional" };

            // Act
            service.RegistrarEntrada(nuevaEntrada);

            // Assert
            mockContext.Verify(m => m.Entradas.Add(It.IsAny<Entrada>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}

using Xunit;
using MigracionControl.Data;
using MigracionControl.Models;
using Moq;

namespace MigracionControl.Tests
{
    public class ViajeroServiceTests
    {
        [Fact]
        public void RegistrarViajero_ConDatosValidos_DebeRegistrarViajero()
        {
            // Arrange
            var mockContext = new Mock<MigracionControlContext>();
            var service = new ViajeroService(mockContext.Object);
            var nuevoViajero = new Viajero { Nombre = "Juan Perez", Pasaporte = "A12345678", Nacionalidad = "Argentina" };

            // Act
            service.RegistrarViajero(nuevoViajero);

            // Assert
            mockContext.Verify(m => m.Viajeros.Add(It.IsAny<Viajero>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}

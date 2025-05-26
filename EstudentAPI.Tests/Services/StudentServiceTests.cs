using Xunit;
using EstudentAPI.Models;
using EstudentAPI.Services;

namespace EstudentAPI.Tests.Services
{
    public class StudentServiceTests
    {
        [Fact]
        public void HasApproved_NotaMayorIgual51_ReturnsTrue()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 1, Nombre = "Juan", Nota = 70 };
            var service = new StudentService();

            // Act
            var resultado = service.HasApproved(estudiante);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void HasApproved_NotaMenor51_ReturnsFalse()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 2, Nombre = "Ana", Nota = 45 };
            var service = new StudentService();

            // Act
            var resultado = service.HasApproved(estudiante);

            // Assert
            Assert.False(resultado);
        }
    }
}
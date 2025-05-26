using Xunit;
using Moq;
using EstudentAPI.Models;
using EstudentAPI.Controllers;
using EstudentAPI.Services;
using System.Collections.Generic;

namespace EstudentAPI.Tests.Controllers.EstudentController
{
    public class EstudentControllerWithMoqTests
    {
        [Fact]
        public void GetAll_ReturnsAllEstudiantes_FromMockedService()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetAll()).Returns(new List<Estudiante>
            {
                new Estudiante { CI = 123, Nombre = "Dariem", Nota = 85 },
                new Estudiante { CI = 456, Nombre = "Alessia", Nota = 49 }
            });

            var controller = new EstudentAPI.Controllers.EstudentController(mockService.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Dariem", result[0].Nombre);
            Assert.Equal("Alessia", result[1].Nombre);
        }

        [Fact]
        public void GetById_ReturnsCorrectEstudiante_FromMock()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var estudiante = new Estudiante { CI = 789, Nombre = "Alondra", Nota = 87 };

            mockService.Setup(s => s.GetById(789)).Returns(estudiante);

            var controller = new EstudentAPI.Controllers.EstudentController(mockService.Object);

            // Act
            var result = controller.GetById(789);

            // Assert
            Assert.NotNull(result); // <- esto garantiza que no sea null
            Assert.Equal("Alondra", result!.Nombre);
            Assert.Equal(87, result.Nota);
        }

        [Fact]
        public void HasApproved_ReturnsTrue_WhenNotaIsSufficient()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 101, Nombre = "Eric", Nota = 58 };
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.HasApproved(estudiante)).Returns(true);

            var result = mockService.Object.HasApproved(estudiante);

            // Assert
            Assert.True(result);
            mockService.Verify(s => s.HasApproved(estudiante), Times.Once); // se llamó al método 1 vez
        }
    }
}
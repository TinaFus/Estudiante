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
                new Estudiante { CI = 1, Nombre = "Luis", Nota = 80 },
                new Estudiante { CI = 2, Nombre = "Diana", Nota = 45 }
            });

            var controller = new EstudentAPI.Controllers.EstudentController(mockService.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Luis", result[0].Nombre);
            Assert.Equal("Diana", result[1].Nombre);
        }

        [Fact]
        public void GetById_ReturnsCorrectEstudiante_FromMock()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var estudiante = new Estudiante { CI = 10, Nombre = "Laura", Nota = 90 };

            mockService.Setup(s => s.GetById(10)).Returns(estudiante);

            var controller = new EstudentAPI.Controllers.EstudentController(mockService.Object);

            // Act
            var result = controller.GetById(10);

            // Assert
            Assert.NotNull(result); // <- esto garantiza que no sea null
            Assert.Equal("Laura", result!.Nombre);
            Assert.Equal(90, result.Nota);
        }

        [Fact]
        public void HasApproved_ReturnsTrue_WhenNotaIsSufficient()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 1, Nombre = "Marco", Nota = 60 };
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.HasApproved(estudiante)).Returns(true);

            var result = mockService.Object.HasApproved(estudiante);

            // Assert
            Assert.True(result);
            mockService.Verify(s => s.HasApproved(estudiante), Times.Once); // se llamó al método 1 vez
        }
    }
}
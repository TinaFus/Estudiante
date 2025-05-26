using Xunit;
using Moq;
using EstudentAPI.Models;
using EstudentAPI.Controllers;
using EstudentAPI.Services;
using System.Collections.Generic;

namespace EstudentAPI.Tests.Controllers.EstudentController
{
    public class EstudentGetMethodsTests
    {
        [Fact]
        public void GetAll_ReturnsAllEstudiantes()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetAll()).Returns(new List<Estudiante>
            {
                new Estudiante { CI = 1001, Nombre = "Dariem", Nota = 85 },
                new Estudiante { CI = 1002, Nombre = "Alessia", Nota = 45 }
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
        public void GetById_ExistingCI_ReturnsCorrectEstudiante()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var estudiante = new Estudiante { CI = 1004, Nombre = "Alondra", Nota = 87 };

            mockService.Setup(s => s.GetById(1004)).Returns(estudiante);

            var controller = new EstudentAPI.Controllers.EstudentController(mockService.Object);

            // Act
            var result = controller.GetById(1004);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Alondra", result!.Nombre);
            Assert.Equal(87, result.Nota);
        }
    }
}